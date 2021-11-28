using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB05.Models
{
    public class NhanVienModel
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public bool GioiTinh { get; set; }
        public ICollection<NV_BTModel> NV_BTs { get; set; }
    }
}
