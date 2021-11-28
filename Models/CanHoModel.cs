using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB05.Models
{
    public class CanHoModel
    {
        public string MaCanHo { get; set; }
        public string TenChuHo { get; set; }
        public ICollection<NV_BTModel> NV_BTs { get; set; }
        public object MaChuHo { get; internal set; }
    }
}
