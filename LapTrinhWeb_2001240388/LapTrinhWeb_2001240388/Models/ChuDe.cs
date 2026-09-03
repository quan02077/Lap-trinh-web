using System;
using System.Collections.Generic;

namespace LapTrinhWeb_2001240388.Models;

public partial class ChuDe
{
    public int MaChuDe { get; set; }

    public string? TenChuDe { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
