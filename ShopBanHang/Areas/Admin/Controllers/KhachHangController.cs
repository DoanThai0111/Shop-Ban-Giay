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
    public class KhachHangController : Controller
    {
        ShopGiayEntities db = new ShopGiayEntities();
        public ActionResult Index(int? page)
        {           
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.khachhangs.ToList().OrderBy(n => n.MaKH).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {           
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(khachhang kh, FormCollection f)
        {
            if (kh == null)
            {
                ViewBag.HoTenKH = f["sHoTenKH"];
                ViewBag.DiaChiKH = f["sDiaChiKH"];
                ViewBag.DienThoaiKH = f["sDienThoaiKH"];
                ViewBag.TenDN = f["sTenDN"];
                ViewBag.MatKhau = f["sMatKhau"];
                ViewBag.NgaySinh = string.Format("{0:MM/dd/yyyy}", f["sNgaySinh"]);
                ViewBag.GioiTinh = f["sGioiTinh"];
                ViewBag.Email = f["sEmail"];
                return View();
            }
            else
            {
                kh.HoTenKH = f["sHoTenKH"];
                kh.DiaChiKH = f["sDiaChiKH"];
                kh.DienThoaiKH = f["sDienThoaiKH"];
                kh.TenDN = f["sTenDN"];
                kh.MatKhau = f["sMatKhau"];
                kh.NgaySinh = DateTime.Parse(f["sNgaySinh"]);
                kh.GioiTinh = bool.Parse(f["sGioiTinh"]);
                kh.Email = f["sEmail"];
                db.khachhangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            var kh = db.khachhangs.SingleOrDefault(n => n.MaKH == id);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var kh = db.khachhangs.SingleOrDefault(n => n.MaKH == id);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var kh = db.khachhangs.SingleOrDefault(n => n.MaKH == id);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.khachhangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kh = db.khachhangs.SingleOrDefault(n => n.MaKH == id);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection f)
        {
            var kh = db.khachhangs.SingleOrDefault(n => n.MaKH == id);
            if (kh == null)
            {
                kh.HoTenKH = f["sHoTenKH"];
                kh.DiaChiKH = f["sDiaChiKH"];
                kh.DienThoaiKH = f["sDienThoaiKH"];
                kh.TenDN = f["sTenDN"];
                kh.MatKhau = f["sMatKhau"];
                kh.NgaySinh = DateTime.Parse(f["sNgaySinh"]);
                kh.GioiTinh = bool.Parse(f["sGioiTinh"]);
                kh.Email = f["sEmail"];
                return View(kh);
            }
            else
            {
                kh.HoTenKH = f["sHoTenKH"];
                kh.DiaChiKH = f["sDiaChiKH"];
                kh.DienThoaiKH = f["sDienThoaiKH"];
                kh.TenDN = f["sTenDN"];
                kh.MatKhau = f["sMatKhau"];
                kh.NgaySinh = DateTime.Parse(f["sNgaySinh"]);
                kh.GioiTinh = bool.Parse(f["sGioiTinh"]);
                kh.Email = f["sEmail"];
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}