using System;
using System.Collections.Generic;

namespace Nhom69MidTermDotNet.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            BangChamCong = new HashSet<BangChamCong>();
        }

        public int MaNv { get; set; }
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public int? MaPb { get; set; }
        public double? LuongCb { get; set; }

        public PhongBan MaPbNavigation { get; set; }
        public ICollection<BangChamCong> BangChamCong { get; set; }
    }
}
