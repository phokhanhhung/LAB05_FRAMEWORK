using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB05.Models
{
    public class ThietBiModel
    {
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public ICollection<NV_BTModel> NV_BTs { get; set; }

    }
}
