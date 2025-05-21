using System;
using System.Collections.Generic;

namespace DuAnTotNghiep.Models;

public partial class ChatLieu
{
    public Guid IdChatLieu { get; set; }

    public string ChatLieu1 { get; set; } = null!;

    public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; } = new List<SanPhamChiTiet>();
}
