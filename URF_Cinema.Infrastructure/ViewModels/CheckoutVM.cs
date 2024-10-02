namespace URF_Cinema.Infrastructure.ViewModels
{
    public class CheckoutVM
    {
        public bool GiongKhachHang { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string DepartmentName { get; set; }
        public string? GhiChu { get; set; }
        public double TotalPrice { get; set; }
        public Guid filmID { get; set; }
        public Guid BillId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid BookingId { get; set; }

    }
}
