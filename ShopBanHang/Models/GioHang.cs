using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Models
{   
    public class GioHang
    {
        ShopGiayEntities db = new ShopGiayEntities();
        public int iMaGiay { get; set; }
        public string sTenGiay { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien { get { return dDonGia * iSoLuong; } }
        public GioHang(int ms)
        {
            iMaGiay = ms;
            giay s = db.giays.Single(n => n.MaGiay == iMaGiay);
            sTenGiay = s.TenGiay;
            sAnhBia = s.HinhMinhHoa;
            dDonGia = double.Parse(s.DonGia.ToString());
            iSoLuong = 1;

        }
    }
}