using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ShopGiayEntities data = new ShopGiayEntities();       

        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, khachhang kh)
        {
            var hoten = collection["HoTen"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var matkhaunhaplai = collection["MatKhauNL"];
            var diachi = collection["DiaChi"];
            var email = collection["Email"];
            var dienthoai = collection["DienThoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["err1"] = "Họ tên khách hàng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["err2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["err3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["err4"] = "Phải nhập lại mật khẩu";
            }
            else if (matkhau != matkhaunhaplai)
            {
                ViewData["err4"] = "Mật khẩu nhập lại không đúng";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["err5"] = "Email không được bỏ trống";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["err6"] = "Phải nhập điện thoại";
            }
            else if (data.khachhangs.SingleOrDefault(n => n.TenDN == tendn) != null)
            {
                ViewBag.Thongbao = "Tên đăng nhập đã tồn tại";
            }
            else if (data.khachhangs.SingleOrDefault(n => n.Email == email) != null)
            {
                ViewBag.Thongbao = "Email đã được sử dụng";
            }
            else
            {
                kh.HoTenKH = hoten;
                kh.TenDN = tendn;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.DiaChiKH = diachi;
                kh.DienThoaiKH = dienthoai;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                data.khachhangs.Add(kh);
                data.SaveChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            //int state = int.Parse(Request.QueryString["id"]);
            var sTenDN = collection["TenDN"];
            var sMatKhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(sTenDN))
            {
                ViewData["Err1"] = "Bạn chưa nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(sMatKhau))
            {
                ViewData["Err1"] = "Phải nhập mật khẩu";
            }
            else
            {
                khachhang kh = data.khachhangs.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    //if (state == 1)                   
                    return RedirectToAction("Index", "Home");                                         
                }
                else
                {                
                ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return RedirectToAction("DatHang", "GioHang");
                }
            }
            return View();
        }

    }
}