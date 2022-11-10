using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanHang.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace ShopBanHang.Areas.Admin.Controllers
{
    public class GiayController : Controller
    {
        ShopGiayEntities db = new ShopGiayEntities();
        // GET: Admin/Sach
        public ActionResult Index(int? page)
        {       
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.giays.ToList().OrderBy(n => n.MaGiay).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {         
            ViewBag.MaCD = new SelectList(db.chudes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.nhaxuatbans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(giay giay, FormCollection f, HttpPostedFileBase fFileUpload)
        {
            ViewBag.MaCD = new SelectList(db.chudes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.nhaxuatbans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            if (fFileUpload == null)
            {
                ViewBag.ThongBao = "Hãy chọn ảnh bìa.";
                ViewBag.TenSach = f["sTenSach"];
                ViewBag.MoTa = f["sMoTa"];
                ViewBag.SoLuong = int.Parse(f["iSoLuong"]);
                ViewBag.GiaBan = decimal.Parse(f["mGiaBan"]);
                ViewBag.MaCD = new SelectList(db.chudes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe", int.Parse(f["MaCD"]));
                ViewBag.MaNXB = new SelectList(db.nhaxuatbans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", int.Parse(f["MaNXB"]));
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var sFileName = Path.GetFileName(fFileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images/Giay"), sFileName);
                    if (!System.IO.File.Exists(path))
                    {
                        fFileUpload.SaveAs(path);
                    }
                    giay.TenGiay = f["sTenSach"];
                    giay.MoTa = f["sMoTa"].Replace("<p>", "").Replace("</p>", "\n");
                    giay.HinhMinhHoa = sFileName;
                    giay.NgayCapNhat = Convert.ToDateTime(f["dNgayCapNhat"]);
                    giay.SoLuongBan = int.Parse(f["iSoLuong"]);
                    giay.DonGia = decimal.Parse(f["mGiaBan"]);
                    giay.MaCD = int.Parse(f["MaCD"]);
                    giay.MaNXB = int.Parse(f["MaNXB"]);
                    db.giays.Add(giay);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var giay = db.giays.SingleOrDefault(n => n.MaGiay == id);
            if (giay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(giay);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var giay = db.giays.SingleOrDefault(n => n.MaGiay == id);
            if (giay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(giay);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var giay = db.giays.SingleOrDefault(n => n.MaGiay == id);
            if (giay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var ctdh = db.ctdathangs.Where(ct => ct.MaGiay == id);
            if (ctdh.Count() > 0)
            {
                ViewBag.ThongBao = "Sách này đang có trong bảng Chi tiết đặt hàng <br>" + " Nếu muốn xóa thì phải xóa hết mã sách này trong bảng Chi tiết đặt hàng";

                return View(giay);
            }
            var vietsach = db.vietgiays.Where(vs => vs.MaGiay == id).ToList();
            //if (vietsach != null)
            //{
            //    db.VIETSACHes.RemoveRange(vietsach);
            //    db.SaveChanges();
            //}
            db.giays.Remove(giay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sach = db.giays.SingleOrDefault(n => n.MaGiay == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCD = new SelectList(db.chudes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.nhaxuatbans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection f, HttpPostedFile fFileUpload)
        {
            var giay = db.giays.SingleOrDefault(n => n.MaGiay == id);
            ViewBag.MaCD = new SelectList(db.chudes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe", giay.MaCD);
            ViewBag.MaNXB = new SelectList(db.nhaxuatbans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", giay.MaNXB);
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    var sFileName = Path.GetFileName(fFileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images/Giay"), sFileName);
                    if (!System.IO.File.Exists(path))
                    {
                        fFileUpload.SaveAs(path);
                    }
                    giay.HinhMinhHoa = sFileName;
                }
                giay.MaGiay = int.Parse(f["iMaSach"]);
                giay.TenGiay = f["sTenSach"];
                giay.MoTa = f["sMoTa"].Replace("<p>", "").Replace("</p>", "\n");
                giay.NgayCapNhat = Convert.ToDateTime(f["dNgayCapNhat"]);
                giay.DonGia = decimal.Parse(f["mGiaBan"]);
                giay.SoLuongBan = int.Parse(f["iSoLuong"]);
                giay.MaCD = int.Parse(f["MaCD"]);
                giay.MaNXB = int.Parse(f["MaNXB"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giay);
        }
    }
}
