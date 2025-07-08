using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Areas.Admin.ViewModels
{
    /// <summary>
    /// ViewModel này đóng gói tất cả dữ liệu được gửi từ form tạo hóa đơn ở giao diện.
    /// </summary>
    public class AdminCreateHoaDonViewModel
    {
        [Required(ErrorMessage = "Tên khách hàng là bắt buộc.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public string ShippingAddress { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public double ShippingFee { get; set; }
        public double Discount { get; set; }
        public string Note { get; set; }

        public List<CartItemViewModel> CartItems { get; set; }
    }

    public class CartItemViewModel
    {
        // ID_Spct từ bảng SanPhamChiTiet
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
