using System;
using System.Collections.Generic;

#nullable disable

namespace WebCongNghe.Models.Entities
{
    public partial class DanhMucCon
    {
        public int MaDmcon { get; set; }
        public string TenDmcon { get; set; }
        public int MaDm { get; set; }

        public virtual DanhMuc MaDmNavigation { get; set; }
    }
}
