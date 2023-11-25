using AudioBooksApp.Data.Cart;

namespace AudioBooksApp.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart? ShoppingCart { get; set; }
        public decimal? ShoppingCartTotal { get; set; }
    }
}
