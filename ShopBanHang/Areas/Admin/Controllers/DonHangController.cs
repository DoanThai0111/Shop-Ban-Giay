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
    public class DonHangController : Controller
    {
        ShopGiayEntities db = new ShopGiayEntities();
        public ActionResult Index(int? page)
        {
            //if (Session["Admin"] == null || Session["Admin"].ToString() == "")
            //{
            //    return Redirect("~/Admin/Home/Login");
            //}
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.dondathangs.ToList().OrderBy(n => n.SoDH).ToPagedList(iPageNum, iPageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            //if (Session["Admin"] == null || Session["Admin"].ToString() == "")
            //{
            //    return Redirect("~/Admin/Home/Login");
            //}
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(dondathang ddh, FormCollection f)
        {
            if (ddh == null)
            {
                ViewBag.MaKH = int.Parse(f["sMaKH"]);
                ViewBag.NgayDH = string.Format("{0:MM/dd/yyyy}", f["sNgayDH"]);
                ViewBag.TriGia = decimal.Parse(f["sTriGia"]);
                ViewBag.DaGiao = f["sDaGiao"];
                ViewBag.NgayGiaoHang = string.Format("{0:MM/dd/yyyy}", f["sNgayGiaoHang"]);
                ViewBag.TenNguoiNhan = f["sTenNguoiNhan"];
                ViewBag.DiaChiNhan = f["sDiaChiNhan"];
                ViewBag.DienThoaiNhan = f["sDienThoaiNhan"];
                ViewBag.HTThanhToan = f["sHTThanhToan"];
                ViewBag.HTGiaoHang = f["sHTGiaoHang"];
                return View();
            }
            else
            {
                ddh.MaKH = int.Parse(f["sMaKH"]);
                ddh.NgayDH = DateTime.Parse(f["sNgayDH"]);
                ddh.TriGia = decimal.Parse(f["sTriGia"]);
                ddh.DaGiao = bool.Parse(f["sDaGiao"]);
                ddh.NgayGiaoHang = DateTime.Parse(f["sNgayGiaoHang"]);
                ddh.TenNguoiNhan = f["sTenNguoiNhan"];
                ddh.DiaChiNhan = f["sDiaChiNhan"];
                ddh.DienThoaiNhan = f["sDienThoaiNhan"];
                ddh.HTThanhToan = bool.Parse(f["sHTThanhToan"]);
                ddh.HTGiaoHang = bool.Parse(f["sHTGiaoHang"]);
                db.dondathangs.Add(ddh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            var ddh = db.dondathangs.SingleOrDefault(n => n.SoDH == id);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ddh);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ddh = db.dondathangs.SingleOrDefault(n => n.SoDH == id);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ddh);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var ddh = db.dondathangs.SingleOrDefault(n => n.SoDH == id);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var ctdh = db.ctdathangs.Where(ct => ct.SoDH == id);
            if (ctdh.Count() > 0)
            {
                ViewBag.ThongBao = "Đơn hàng này đang có trong bảng Chi tiết đặt hàng <br>" + " Nếu muốn xóa thì phải xóa hết số đơn hàng này trong bảng Chi tiết đặt hàng";

                return View(ddh);
            }
            db.dondathangs.Remove(ddh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ddh = db.dondathangs.SingleOrDefault(n => n.SoDH == id);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ddh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection f)
        {
            var ddh = db.dondathangs.SingleOrDefault(n => n.SoDH == id);
            if (ddh == null)
            {
                ddh.MaKH = int.Parse(f["sMaKH"]);
                ddh.NgayDH = DateTime.Parse(f["sNgayDH"]);
                ddh.TriGia = decimal.Parse(f["sTriGia"]);
                ddh.DaGiao = bool.Parse(f["sDaGiao"]);
                ddh.NgayGiaoHang = DateTime.Parse(f["sNgayGiaoHang"]);
                ddh.TenNguoiNhan = f["sTenNguoiNhan"];
                ddh.DiaChiNhan = f["sDiaChiNhan"];
                ddh.DienThoaiNhan = f["sDienThoaiNhan"];
                ddh.HTThanhToan = bool.Parse(f["sHTThanhToan"]);
                ddh.HTGiaoHang = bool.Parse(f["sHTGiaoHang"]);
                return View(ddh);
            }
            else
            {
                ddh.MaKH = int.Parse(f["sMaKH"]);
                ddh.NgayDH = DateTime.Parse(f["sNgayDH"]);
                ddh.TriGia = decimal.Parse(f["sTriGia"]);
                ddh.DaGiao = bool.Parse(f["sDaGiao"]);
                ddh.NgayGiaoHang = DateTime.Parse(f["sNgayGiaoHang"]);
                ddh.TenNguoiNhan = f["sTenNguoiNhan"];
                ddh.DiaChiNhan = f["sDiaChiNhan"];
                ddh.DienThoaiNhan = f["sDienThoaiNhan"];
                ddh.HTThanhToan = bool.Parse(f["sHTThanhToan"]);
                ddh.HTGiaoHang = bool.Parse(f["sHTGiaoHang"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
