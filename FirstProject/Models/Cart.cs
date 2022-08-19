namespace FirstProject.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems=new List<CartItem>();
        }
        public int OrderId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public void add(CartItem item)
        {
            if (CartItems.Exists(x=>x.Item.Id==item.Id))
            {
                CartItems.Find(x => x.Item.Id == item.Item.Id).Quantity += 1;
            }
            else
            {
                CartItems.Add(item);
            }

        }
        public void Remove(int itemid)
        {
            var ItemExist=CartItems.SingleOrDefault(x=>x.Item.Id==itemid);
            if (ItemExist?.Quantity<=1)
            {
                CartItems.Remove(ItemExist);
            }
            else if(ItemExist!=null)
            {
                ItemExist.Quantity-=1;
            }
        }
    }
}
