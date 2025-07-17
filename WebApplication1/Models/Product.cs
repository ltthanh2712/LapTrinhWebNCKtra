using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string? NamePro { get; set; }

        [DisplayName("Mô tả sản phẩm")]
        public string? DecriptionPro { get; set; }

        [DisplayName("Loại")]
        [Required(ErrorMessage = "Vui lòng chọn loại sản phẩm")]
        public string? Category { get; set; }

        [DisplayName("Giá tiền")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public decimal? Price { get; set; }

        [DisplayName("Ảnh sản phẩm")]
        public string? ImagePro { get; set; }

        [DisplayName("Tải ảnh lên")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile? ImageUpload { get; set; }

        [DisplayName("Ngày sản xuất")]
        [Required(ErrorMessage = "Vui lòng chọn ngày sản xuất")]
        [DateLessThanToday(ErrorMessage = "Ngày sản xuất phải nhỏ hơn ngày hiện tại")]
        public DateOnly ManufacturingDate { get; set; }
    }
}
