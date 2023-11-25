using AudioBooksApp.Data;
using AudioBooksApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AudioBooksApp.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context; 
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session=services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context=services.GetService<AppDbContext>();
            string cartId=session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Book book)
        {
            var shoppingCarItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCarItem == null) 
            {
                shoppingCarItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCarItem);
            }
            else
            {
                shoppingCarItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Book book)
        {
            var shoppingCarItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCarItem != null)
            {
                if(shoppingCarItem.Amount > 1)
                {
                    shoppingCarItem.Amount--;   
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCarItem);
                }
            } 
            _context.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems=_context.ShoppingCartItems.Where(n=>n.ShoppingCartId==ShoppingCartId).Include(n=>n.Book).ToList());
        }

        public decimal GetShoppingCartTotal()
        {
            var total=_context.ShoppingCartItems.Where(n=>n.ShoppingCartId==ShoppingCartId).Select(n=>n.Book.Price*n.Amount).Sum();
            return total;
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        
    }
}
