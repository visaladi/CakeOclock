namespace Tangy_DataAccess.ViewModel
{
    public class CustomOrder
    {
        public CustomOrderHeader CustomOrderHeader { get; set; }
        public IEnumerable<CustomOrderDetail> CustomOrderDetails { get; set; }
    }
}
