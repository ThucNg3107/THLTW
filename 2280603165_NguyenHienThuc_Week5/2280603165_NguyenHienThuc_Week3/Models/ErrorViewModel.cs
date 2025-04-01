using System.ComponentModel.DataAnnotations;

namespace _2280603165_NguyenHienThuc_Week3.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
