using System;
using System.Collections.Generic;

namespace LapTrinhWeb_2001240388.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public string? TenSach { get; set; }

    public decimal? GiaBan { get; set; }

    public string? MoTa { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? AnhBia { get; set; }

    public int? SoLuongTon { get; set; }

    public int? MaChuDe { get; set; }

    public int? MaNxb { get; set; }

    public int? Moi { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ChuDe? MaChuDeNavigation { get; set; }

    public virtual NhaXuatBan? MaNxbNavigation { get; set; }

    public virtual ICollection<ThamGium> ThamGia { get; set; } = new List<ThamGium>();
}
