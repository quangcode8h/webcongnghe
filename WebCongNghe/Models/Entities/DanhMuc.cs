using System;
using System.Collections.Generic;

#nullable disable

namespace WebCongNghe.Models.Entities
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            DanhMucCons = new HashSet<DanhMucCon>();
        }

        public int MaDm { get; set; }
        public string TenDm { get; set; }

        public virtual ICollection<DanhMucCon> DanhMucCons { get; set; }
    }
}
