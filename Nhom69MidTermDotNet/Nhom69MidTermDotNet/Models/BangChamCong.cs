using System;
using System.Collections.Generic;

namespace Nhom69MidTermDotNet.Models
{
    public partial class BangChamCong
    {
        public int MaCc { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? MaNv { get; set; }
        public int? Songay { get; set; }
        public double? Luongthang { get; set; }

        public NhanVien MaNvNavigation { get; set; }
    }
}
