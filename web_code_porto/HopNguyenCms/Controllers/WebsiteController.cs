using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HopNguyenModel;
using HopNguyenModel.General;
using PagedList;

namespace HopNguyenCms.Controllers
{
    public class WebsiteController : Controller
    {
        readonly TypeContent _typeContent = new TypeContent();
        readonly Content _content = new Content();
        readonly PageDetail _pageDetail = new PageDetail();
        //[OutputCache(CacheProfile = "CacheFrontEnd")]
        public ActionResult Index(string page, string alias, int p = 1, string q = "")
        {
            ViewBag.Meta = new GenerateMeta().AutoGenerateMeta(page, alias);
            var groupId = _typeContent.GetByAlias(page) != null ? _typeContent.GetByAlias(page).GroupId : 0;
            if (!string.IsNullOrEmpty(alias))
            {
                if (alias == "danh-sach")
                {
                    ViewBag.TypeContent = _typeContent.GetByAlias(page);
                    ViewBag.Page = "list news";
                    return View();
                }
                if (page == "tags")
                {
                    ViewBag.lstContent = _content.GetByTagName(alias).OrderByDescending(a => a.Id).ToPagedList(p, 15);
                    ViewBag.Page = "tags";
                    return View();
                }
                ViewBag.Content = _content.GetByAlias(alias);
                ViewBag.Page = "detail news";
                return View();
            }
            if (!string.IsNullOrEmpty(page))
            {
                if (page == "gioi-thieu")
                {
                    ViewBag.PageDetail = _pageDetail.GetByAlias(page);
                    ViewBag.Page = "page detail";
                    return View();
                }
                //if (page == "dich-thuat")
                //{
                //    ViewBag.PageDetail = _pageDetail.GetByAlias(page);
                //    ViewBag.Page = "page detail";
                //    return View();
                //}

                if (page == "phien-dich")
                {
                    ViewBag.PageDetail = _pageDetail.GetByAlias(page);
                    ViewBag.Page = "page detail";
                    return View();
                }
                if (page == "cong-chung-nhanh")
                {
                    ViewBag.PageDetail = _pageDetail.GetByAlias(page);
                    ViewBag.Page = "page detail";
                    return View();
                }
                if (page == "bao-gia")
                {

                    ViewBag.PageDetail = _pageDetail.GetByAlias(page);
                    ViewBag.Page = "page detail";
                    return View();
                }
                if (page == "tuyen-dung")
                {
                    ViewBag.PageDetail = _pageDetail.GetByAlias(page);
                    ViewBag.Page = "page detail";
                    return View();
                }
                if (page == "lien-he" || page == "mac-ca")
                {
                    ViewBag.PageDetail = _pageDetail.GetByAlias(page);
                    ViewBag.Page = "contact";
                    return View();
                }
                if (page == "tim-kiem")
                {
                    ViewBag.lstContent = _content.SearchByName(q).OrderByDescending(a => a.Id).ToPagedList(p, 15);
                    ViewBag.Page = "search";
                    return View();
                }
               
                if (page == "thong-bao")
                {
                    ViewBag.Page = "message";
                    return View();
                }
                if (page == "gio-hang")
                {
                    ViewBag.Page = "cart";
                    return View();
                }
                if (page == "san-pham")
                {
                    ViewBag.TypeContent = _typeContent.GetByAlias(page);
                    ViewBag.Page = "list product";
                    return View();
                }
                if (page == "tags")
                {
                    ViewBag.lstContent = _content.GetByTagName(alias).OrderByDescending(a => a.Id).ToPagedList(p, 15);
                    ViewBag.Page = "tags";
                    return View();
                }
                if (page=="error404")
                {
                    ViewBag.Page = "error404";
                    return View();
                }
                ViewBag.TypeContent = _typeContent.GetByAlias(page);
                ViewBag.Page = (groupId == 1 ? "list product" : "list news");
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult SendContact(string name, string email, string phone, string message)
        {
            var str = "<div><strong>Họ Tên</strong>: " + name + "<br /><strong>Điện thoại</strong>: " + phone
                + "<br /><strong>Email</strong>: " + email + "<br /><strong>Nội dung</strong>: " + message + "</div>";
            Email.SendMail("Thư liên hệ từ : " + name + " - " + Request.Url.Host, str);
            return Redirect("/thong-bao.html");
        }

        [HttpPost]
        public ActionResult AddCart(int id)
        {
            var order = new List<HopNguyenModel.Extensions.Order>();
            if (Session["order"] != null)
            {
                order = (List<HopNguyenModel.Extensions.Order>)Session["order"];
            }
            var obj = new HopNguyenModel.Extensions.Order();
            order = obj.AddCart(order, id, 1);
            Session["order"] = order;
            return Redirect("/gio-hang.html");
        }

        [HttpPost]
        public ActionResult UpdateCart(int id, int count)
        {
            var order = new List<HopNguyenModel.Extensions.Order>();
            if (Session["order"] != null)
            {
                order = (List<HopNguyenModel.Extensions.Order>)Session["order"];
            }
            var obj = new HopNguyenModel.Extensions.Order();
            order = obj.Update(order, id, count);
            Session["order"] = order;
            return Redirect("/gio-hang.html");
        }

        public ActionResult DeleteCart(int id)
        {
            var order = new List<HopNguyenModel.Extensions.Order>();
            if (Session["order"] != null)
            {
                order = (List<HopNguyenModel.Extensions.Order>)Session["order"];
            }
            var obj = new HopNguyenModel.Extensions.Order();
            order = obj.Delete(order, id);
            Session["order"] = order;
            return Redirect("/gio-hang.html");
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            if (Session["order"] != null)
            {
                order.DateCreate = DateTime.Now;
                order.Status = true;
                var lstOrder = (List<HopNguyenModel.Extensions.Order>)Session["Order"];
                new HopNguyenModel.Extensions.OrderDetail().InsertOrder(lstOrder, order);
            }
            Session["order"] = null;
            Email.SendMail("Đơn đặt hàng mới trên website: " + Request.Url.Host, "Khách hàng: "+ order.Name +" đã đặt hàng trên hệ thống website: " + Request.Url.Host + ". Vui lòng đăng nhập vào hệ thống quản trị website để xem chi tiết đơn hàng.");
            return Redirect("/thong-bao.html");
        }
    }
}
