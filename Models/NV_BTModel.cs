using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB05.Models
{
    public class NV_BTModel
    {
        public string MaNhanVien { get; set; }
        public NhanVienModel nhanvien { get; set; }
        public string MaThietBi { get; set; }
        public ThietBiModel thietbi { get; set; }
        public string MaCanHo { get; set; }
        public CanHoModel canho { get; set; }
        public int LanThu { get; set; }
        public DateTime NgayBaoTri { get; set; }
    }
}
