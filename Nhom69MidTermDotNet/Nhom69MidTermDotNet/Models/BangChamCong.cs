using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nhom69MidTermDotNet.Models
{
    public partial class BangChamCong
    {
        public int MaCc { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? MaNv { get; set; }
        [Required]
        [Range(0, 22)]
        public int? Songay { get; set; }
        public double? Luongthang { get; set; }

        public NhanVien MaNvNavigation { get; set; }
        //public double? LuongThang => ((MaNvNavigation.LuongCb) / 22 + Songay);
    }
}
