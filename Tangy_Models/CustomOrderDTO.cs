namespace Tangy_Models
{
    public class CustomOrderDTO
    {
        public CustomOrderHeaderDTO CustomOrderHeader { get; set; }
        public List<CustomOrderDetailDTO> CustomOrderDetails { get; set; }
    }
}