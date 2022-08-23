namespace FirstProject.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems=new List<CartItem>();
        }

        public List<CartItem> CartItems { get; set; }
        public decimal OrderTotal { get; set; }

        public List<CartItem> Sorting()
        {
            return CartItems.OrderByDescending(x => x.Quantity).ToList();
        }
    }
}
