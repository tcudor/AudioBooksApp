using AudioBooksApp.Data.Cart;
using AudioBooksApp.Data.Services;
using AudioBooksApp.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace AudioBooksApp.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IBooksService _booksService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IBooksService booksService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _booksService = booksService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddItemShoppingCart(int id)
        {
            var item = await _booksService.GetBookByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveItemShoppingCart(int id)
        {
            var item = await _booksService.GetBookByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            string toAddress = userEmailAddress;
            string subject = "Order Confimation!";

            StringBuilder body = new StringBuilder();
            body.AppendLine("\nThank you for ordering on our eCinema website!");

            foreach (var item in items)
            {
                body.AppendLine($"- {item.Book.Title}");
            }
           
            body.AppendLine("\nYour download link:");
            foreach (var item in items)
            {
                body.AppendLine($"{item.Book.AudioFilePath}");
            }

            SendEmail(toAddress, subject, body.ToString());

            return View("OrderCompleted");
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId, userRole);

            return View(orders);
        }

        public void SendEmail(string toAddress, string subject, string body)
        {

            // Set the SMTP server details
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("tudorcristian.gheorghita@ulbsibiu.ro", "jqmifsfdshkupzlu");

            // Create a message to send
            MailMessage message = new MailMessage();
            message.From = new MailAddress("tudorcristian.gheorghita@ulbsibiu.ro");
            message.To.Add(toAddress);
            message.Subject = subject;
            message.Body = body;

            // Send the message
            client.Send(message);
        }
    }
}
