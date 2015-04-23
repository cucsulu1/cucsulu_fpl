using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HopNguyenModel;
using HopNguyenModel.General;
using PagedList;

namespace HopNguyenCms.Controllers
{
    public class CPanelController : Controller
    {
        private readonly HopNguyenEntities _db = new HopNguyenEntities();
        private readonly TypeContent _typeContent = new TypeContent();
        private readonly TypeImage _typeImage = new TypeImage();
        private readonly Content _content = new Content();
        private readonly Image _image = new Image();
        private readonly TypeSupport _typeSupport = new TypeSupport();
        private readonly Support _support = new Support();
        private readonly PageDetail _pageDetail = new PageDetail();
        private readonly Module _module = new Module();
        private readonly Admin _admin = new Admin();
        private readonly Permission _permission = new Permission();
        private readonly Status _status = new Status();


        public ActionResult Index()
        {
            if (Session[Admins.CURRENT_ADMIN_SESSION_KEY] == null)
            {
                if (Request.Cookies["_uid"] != null)
                {
                    if (new Admins().Login(Request.Cookies["_uid"]["username"], Request.Cookies["_uid"]["password"]))
                    {
                        return RedirectToAction("Dashboard");
                    }
                    return View("Login");
                }
                return View("Login");
            }
            return RedirectToAction("Dashboard");
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        #region System logs
        public ActionResult Logs()
        {
            var systemlogs = _db.SystemLogs.Include(s => s.Admin);
            return View(systemlogs.ToList());
        }

        public ActionResult LogDetail(int id = 0)
        {
            var systemlog = _db.SystemLogs.Find(id);
            if (systemlog == null)
            {
                return HttpNotFound();
            }
            return View(systemlog);
        }

        #endregion

        #region type product
        public ActionResult TypeProducts(int parent = 0)
        {
            var lstTypeContent = _typeContent.GetAll(1).OrderByDescending(a => a.Id).ToList();
            if (parent > 0)
            {
                lstTypeContent = lstTypeContent.Where(a => a.Parent == parent).ToList();
            }
            ViewBag.Parent = new SelectList(new TypeContent().GetMultiLevel(1), "Id", "Name", parent);
            return View(lstTypeContent);
        }

        public ActionResult CreateTypeProduct(int parent = 0)
        {
            ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(1), "Id", "Name");
            var lstTypeContent = _typeContent.GetAll(1).OrderByDescending(a => a.Id).ToList();
            if (parent > 0)
            {
                lstTypeContent = lstTypeContent.Where(a => a.Parent == parent).ToList();
            }
            return View(lstTypeContent);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateTypeProduct(HttpPostedFileBase image, TypeContent tContent)
        {
            try
            {
                tContent.Alias = _typeContent.CheckAlias(Tool.RemoveUnicode(tContent.Name), 1);
                tContent.Image = Tool.UploadImage(image);
                tContent.CreateByAdminId = Admins.Current.Id;
                tContent.GroupId = 1;
                tContent.DateCreate = DateTime.Now;
                _db.TypeContents.Add(tContent);
                _db.SaveChanges();
                return Redirect("/cpanel/createtypeproduct?msg=success");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditTypeProduct(int? id, int parent = 0)
        {
            try
            {
                if (id != null)
                {
                    var tContent = _db.TypeContents.Find(id);
                    if (tContent == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(1), "Id", "Name", tContent.Parent);
                    var lstTypeContent = _typeContent.GetAll(1).OrderByDescending(a => a.Id).ToList();
                    if (parent > 0)
                    {
                        lstTypeContent = lstTypeContent.Where(a => a.Parent == parent).ToList();
                    }
                    ViewBag.lstTypeProduct = lstTypeContent;
                    return View(tContent);
                }
                return RedirectToAction("TypeProducts");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditTypeProduct(TypeContent typeContent, HttpPostedFileBase image)
        {
            try
            {
                _typeContent.Update(typeContent, image);
                return Redirect("/cpanel/edittypeproduct/" + typeContent.Id + "?msg=success");

            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(1), "Id", "Name", typeContent.Parent);
                ViewBag.Error = ex.Message;
                return View(typeContent);
            }
        }

        public ActionResult DeleteTypeProduct(int id)
        {
            try
            {
                var tContent = _db.TypeContents.Find(id);
                if (tContent == null)
                {
                    return RedirectToAction("Error404");
                }
                foreach (var item in _db.Contents.Where(a => a.TypeId == id))
                {
                    _db.Contents.Remove(item);
                }
                foreach (var item in _db.TypeContents.Where(a => a.Parent == id))
                {
                    _db.TypeContents.Remove(item);
                }
                _db.TypeContents.Remove(tContent);
                _db.SaveChanges();

                return RedirectToAction("TypeProducts", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region product

        public ActionResult Products(int typeid = 0)
        {
            ViewBag.TypeId = new SelectList(_typeContent.GetMultiLevel(1), "Id", "Name", typeid);
            var lstProduct = _db.Contents.Where(a => a.GroupId == 1).OrderByDescending(a => a.Id).ToList();
            if (typeid > 0)
            {
                lstProduct = lstProduct.Where(a => a.TypeId == typeid).ToList();
            }
            return View(lstProduct);
        }

        public ActionResult CreateProduct(int typeid = 0)
        {
            StaticVariable.ImageContents = new List<ImageContent>();
            ViewBag.TypeId = new SelectList(_typeContent.GetMultiLevel(1), "Id", "Name");
            ViewBag.Status = _db.Status.Where(a => a.GroupId == 1).ToList();
            var lstProduct = _db.Contents.Where(a => a.GroupId == 1).OrderByDescending(a => a.Id).ToList();
            if (typeid > 0)
            {
                lstProduct = lstProduct.Where(a => a.TypeId == typeid).ToList();
            }
            return View(lstProduct);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateProduct(HttpPostedFileBase image, Content content, string tags)
        {
            try
            {
                _content.CreateContent(image, content, 1, tags);
                return Redirect("/Cpanel/CreateProduct?typeid=" + content.TypeId + "&msg=success");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditProduct(int? id, int typeid = 0)
        {
            try
            {
                if (id != null)
                {
                    var content = _db.Contents.Find(id);
                    if (content == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    foreach (var item in content.Tags.ToList())
                    {
                        ViewBag.Tags += item.Name + ",";
                    }
                    ViewBag.TypeId = new SelectList(_typeContent.GetMultiLevel(1), "Id", "Name", content.TypeId);
                    ViewBag.Status = _db.Status.Where(a => a.GroupId == 1).ToList();

                    var lstProduct = _db.Contents.Where(a => a.GroupId == 1).OrderByDescending(a => a.Id).ToList();
                    if (typeid > 0)
                    {
                        lstProduct = lstProduct.Where(a => a.TypeId == typeid).ToList();
                    }
                    ViewBag.lstProduct = lstProduct;
                    return View(content);
                }
                return RedirectToAction("Products");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditProduct(Content content, HttpPostedFileBase image, string tags)
        {
            try
            {
                foreach (var item in _db.Contents.Find(content.Id).Tags.ToList())
                {
                    ViewBag.Tags += item.Name + ",";
                }
                _content.Update(content, image, tags);
                return Redirect("/cpanel/editproduct/" + content.Id + "?msg=success");

            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw ;
            }
        }

        public ActionResult DeleteProduct(int id = 0)
        {
            try
            {
                var content = _db.Contents.Find(id);
                if (content == null)
                {
                    return RedirectToAction("Error404");
                }
                foreach (var item in content.ImageContents.ToList())
                {
                    _db.ImageContents.Remove(item);
                }
                _db.SaveChanges();
                _db.Contents.Remove(content);
                _db.SaveChanges();

                return RedirectToAction("Products", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        #endregion

        #region type news
        public ActionResult TypeNews(int parent = 0)
        {
            var lstTypeContent = _typeContent.GetAll(2).OrderByDescending(a => a.Id).ToList();
            if (parent > 0)
            {
                lstTypeContent = lstTypeContent.Where(a => a.Parent == parent).ToList();
            }
            ViewBag.Parent = new SelectList(new TypeContent().GetMultiLevel(2), "Id", "Name", parent);
            return View(lstTypeContent);
        }

        public ActionResult CreateTypeNews()
        {
            ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name");
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateTypeNews(HttpPostedFileBase image, TypeContent tContent)
        {
            try
            {
                tContent.Alias = _typeContent.CheckAlias(Tool.RemoveUnicode(tContent.Name), 2);
                tContent.Image = Tool.UploadImage(image);
                tContent.CreateByAdminId = Admins.Current.Id;
                tContent.GroupId = 2;
                tContent.DateCreate = DateTime.Now;
                _db.TypeContents.Add(tContent);
                _db.SaveChanges();
                ViewBag.msg = "success";
                ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name", tContent.Parent);
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name");
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult EditTypeNews(int? id)
        {
            try
            {
                if (id != null)
                {
                    var tContent = _db.TypeContents.Find(id);
                    if (tContent == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name", tContent.Parent);
                    return View(tContent);
                }
                return View("TypeNews");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditTypeNews(TypeContent typeContent, HttpPostedFileBase image)
        {
            try
            {
                _typeContent.Update(typeContent, image);
                ViewBag.msg = "success";
                ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name", typeContent.Parent);
                return View(typeContent);

            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                ViewBag.Parent = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name", typeContent.Parent);
                ViewBag.Error = ex.Message;
                return View(typeContent);
            }
        }
        public ActionResult DeleteTypeNews(int id)
        {
            try
            {
                var tContent = _db.TypeContents.Find(id);
                if (tContent == null)
                {
                    return RedirectToAction("Error404");
                }
                foreach (var item in _db.Contents.Where(a => a.TypeId == id))
                {
                    _db.Contents.Remove(item);
                }
                foreach (var item in _db.TypeContents.Where(a => a.Parent == id))
                {
                    _db.TypeContents.Remove(item);
                }
                _db.TypeContents.Remove(tContent);
                _db.SaveChanges();

                return RedirectToAction("TypeNews", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region news

        public ActionResult News(int typeid = 0)
        {
            ViewBag.TypeId = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name", typeid);
            var lstNews = _db.Contents.Where(a => a.GroupId == 2).OrderByDescending(a => a.Sort).ThenByDescending(a => a.Id).ToList();
            if (typeid > 0)
            {
                lstNews = lstNews.Where(a => a.TypeId == typeid).ToList();
            }
            return View(lstNews);
        }

        public ActionResult CreateNews(int typeid = 0)
        {
            ViewBag.TypeId = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name");
            var lstNews = _db.Contents.Where(a => a.GroupId == 2).OrderByDescending(a => a.Sort).ThenByDescending(a => a.Id).ToList();
            if (typeid > 0)
            {
                lstNews = lstNews.Where(a => a.TypeId == typeid).ToList();
            }
            return View(lstNews);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateNews(HttpPostedFileBase image, Content content, string tags)
        {
            try
            {
                _content.CreateContent(image, content, 2, tags);
                return Redirect("/Cpanel/CreateNews?typeid=" + content.TypeId + "&msg=success");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw ;
            }
        }

        public ActionResult EditNews(int? id, int typeid = 0)
        {
            try
            {
                if (id != null)
                {
                    var content = _db.Contents.Find(id);
                    if (content == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    foreach (var item in content.Tags.ToList())
                    {
                        ViewBag.Tags += item.Name + ",";
                    }
                    ViewBag.TypeId = new SelectList(_typeContent.GetMultiLevel(2), "Id", "Name", content.TypeId);

                    var lstNews = _db.Contents.Where(a => a.GroupId == 2).OrderByDescending(a => a.Sort).ThenByDescending(a => a.Id).ToList();
                    if (typeid > 0)
                    {
                        lstNews = lstNews.Where(a => a.TypeId == typeid).ToList();
                    }
                    ViewBag.lstNews = lstNews;
                    return View(content);
                }
                return RedirectToAction("News");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditNews(Content content, HttpPostedFileBase file, string tags)
        {
            try
            {
                _content.Update(content, file, tags);
                return Redirect("/Cpanel/EditNews/" + content.Id + "?msg=success");

            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult DeleteNews(int id = 0)
        {
            try
            {
                var content = _db.Contents.Find(id);
                if (content == null)
                {
                    return RedirectToAction("Error404");
                }
                _db.Contents.Remove(content);
                _db.SaveChanges();

                return RedirectToAction("News", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        #endregion

        #region type image
        public ActionResult TypeImage(int parent = 0)
        {
            var lstTypeImage = _typeImage.GetAll().OrderByDescending(a => a.Id).ToList();
            if (parent > 0)
            {
                lstTypeImage = lstTypeImage.Where(a => a.Parent == parent).ToList();
            }
            ViewBag.Parent = new SelectList(new TypeImage().GetMultiLevel(), "Id", "Name", parent);
            return View(lstTypeImage);
        }

        public ActionResult CreateTypeImage()
        {
            ViewBag.Parent = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name");
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateTypeImage(HttpPostedFileBase image, TypeImage tImage)
        {
            try
            {
                tImage.Image = Tool.UploadImage(image);
                _db.TypeImages.Add(tImage);
                _db.SaveChanges();
                ViewBag.msg = "success";
                ViewBag.Parent = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name", tImage.Parent);
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw ;
            }
        }

        public ActionResult EditTypeImage(int? id)
        {
            try
            {
                if (id != null)
                {
                    var tImage = _db.TypeImages.Find(id);
                    if (tImage == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    ViewBag.Parent = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name", tImage.Parent);
                    return View(tImage);
                }
                return View("TypeImage");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditTypeImage(TypeImage typeImage, HttpPostedFileBase file)
        {
            try
            {
                _typeImage.Update(typeImage, file);
                ViewBag.msg = "success";
                ViewBag.Parent = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name", typeImage.Parent);
                return View(typeImage);

            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw ;
            }
        }
        public ActionResult DeleteTypeImage(int id)
        {
            try
            {
                var tImage = _db.TypeImages.Find(id);
                if (tImage == null)
                {
                    return RedirectToAction("Error404");
                }
                foreach (var item in _db.Images.Where(a => a.TypeId == id))
                {
                    _db.Images.Remove(item);
                }
                _db.TypeImages.Remove(tImage);
                _db.SaveChanges();

                return RedirectToAction("TypeImage", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region images
        public ActionResult Images(int typeid = 0)
        {
            var lstImage = _image.GetAll().OrderByDescending(a => a.Id).ToList();
            if (typeid > 0)
            {
                lstImage = lstImage.Where(a => a.TypeId == typeid).ToList();
            }
            ViewBag.TypeId = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name");
            return View(lstImage);
        }

        public ActionResult CreateImage()
        {
            ViewBag.TypeId = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name");
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateImage(HttpPostedFileBase image, Image objImage)
        {
            try
            {
                objImage.Image1 = Tool.UploadImage(image);
                _db.Images.Add(objImage);
                _db.SaveChanges();
                ViewBag.msg = "success";
                ViewBag.TypeId = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name", objImage.TypeId);
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditImage(int? id)
        {
            try
            {
                if (id != null)
                {
                    var image = _db.Images.Find(id);
                    if (image == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    ViewBag.TypeId = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name", image.TypeId);
                    return View(image);
                }
                return View("Images");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditImage(Image objImage, HttpPostedFileBase image)
        {
            try
            {
                _image.Update(objImage, image);
                ViewBag.msg = "success";
                ViewBag.TypeId = new SelectList(_typeImage.GetMultiLevel(), "Id", "Name", objImage.TypeId);
                return View(objImage);

            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public ActionResult DeleteImage(int id)
        {
            try
            {
                var tImage = _db.Images.Find(id);
                if (tImage == null)
                {
                    return RedirectToAction("Error404");
                }
                _db.Images.Remove(tImage);
                _db.SaveChanges();

                return RedirectToAction("Images", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region type support

        public ActionResult TypeSupport()
        {
            return View(_typeSupport.GetAll());
        }

        public ActionResult CreateTypeSupport()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateTypeSupport(TypeSupport tSupport)
        {
            try
            {
                _db.TypeSupports.Add(tSupport);
                _db.SaveChanges();
                ViewBag.msg = "success";
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditTypeSupport(int? id)
        {
            try
            {
                if (id != null)
                {
                    var tSupport = _db.TypeSupports.Find(id);
                    if (tSupport == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    return View(tSupport);
                }
                return View("TypeSupport");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditTypeSupport(TypeSupport tSupport)
        {
            try
            {
                _typeSupport.Update(tSupport);
                ViewBag.msg = "success";
                return View(tSupport);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public ActionResult DeleteTypeSupport(int id)
        {
            try
            {
                var tSupport = _db.TypeSupports.Find(id);
                if (tSupport == null)
                {
                    return RedirectToAction("Error404");
                }
                foreach (var item in _db.Supports.Where(a => a.TypeId == id))
                {
                    _db.Supports.Remove(item);
                }
                _db.TypeSupports.Remove(tSupport);
                _db.SaveChanges();

                return RedirectToAction("TypeSupport", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region support

        public ActionResult Supports()
        {
            return View(_support.GetAll());
        }

        public ActionResult CreateSupport()
        {
            ViewBag.TypeId = new SelectList(_db.TypeSupports, "Id", "Name");
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateSupport(Support support)
        {
            try
            {
                _db.Supports.Add(support);
                _db.SaveChanges();
                ViewBag.msg = "success";
                ViewBag.TypeId = new SelectList(_db.TypeSupports, "Id", "Name");
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditSupport(int? id)
        {
            try
            {
                if (id != null)
                {
                    var support = _db.Supports.Find(id);
                    if (support == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    ViewBag.TypeId = new SelectList(_db.TypeSupports, "Id", "Name", support.TypeId);
                    return View(support);
                }
                return View("Supports");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditSupport(Support support)
        {
            try
            {
                _support.Update(support);
                ViewBag.msg = "success";
                ViewBag.TypeId = new SelectList(_db.TypeSupports, "Id", "Name", support.TypeId);
                return View(support);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public ActionResult DeleteSupport(int id)
        {
            try
            {
                var support = _db.Supports.Find(id);
                if (support == null)
                {
                    return RedirectToAction("Error404");
                }
                _db.Supports.Remove(support);
                _db.SaveChanges();

                return RedirectToAction("Supports", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region page detail

        public ActionResult PageDetails()
        {
            return View(_pageDetail.GetAll());
        }

        public ActionResult CreatePageDetail()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreatePageDetail(PageDetail pageDetail)
        {
            try
            {
                pageDetail.Alias = Tool.RemoveUnicode(pageDetail.Name);
                _db.PageDetails.Add(pageDetail);
                _db.SaveChanges();
                ViewBag.msg = "success";
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditPageDetail(int? id)
        {
            try
            {
                if (id != null)
                {
                    var pageDetail = _db.PageDetails.Find(id);
                    if (pageDetail == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    return View(pageDetail);
                }
                return View("PageDetails");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditPageDetail(PageDetail pageDetail)
        {
            try
            {
                _pageDetail.Update(pageDetail);
                ViewBag.msg = "success";
                return View(pageDetail);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public ActionResult DeletePageDetail(int id)
        {
            try
            {
                var pageDetail = _db.PageDetails.Find(id);
                if (pageDetail == null)
                {
                    return RedirectToAction("Error404");
                }
                _db.PageDetails.Remove(pageDetail);
                _db.SaveChanges();

                return RedirectToAction("PageDetails", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region module

        public ActionResult Modules()
        {
            return View(_module.GetAll());
        }

        public ActionResult CreateModule()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateModule(Module module)
        {
            try
            {
                _db.Modules.Add(module);
                _db.SaveChanges();
                ViewBag.msg = "success";
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditModule(int? id)
        {
            try
            {
                if (id != null)
                {
                    var module = _db.Modules.Find(id);
                    if (module == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    return View(module);
                }
                return View("Modules");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditModule(Module module)
        {
            try
            {
                _module.Update(module);
                ViewBag.msg = "success";
                return View(module);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public ActionResult DeleteModule(int id)
        {
            try
            {
                var module = _db.Modules.Find(id);
                if (module == null)
                {
                    return RedirectToAction("Error404");
                }
                _db.Modules.Remove(module);
                _db.SaveChanges();

                return RedirectToAction("Modules", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region admin

        [HttpPost]
        public ActionResult Login(string username, string password, string remember)
        {
            try
            {
                password = MD5.Encrypt(password);
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View("Login");
                }
                if (!new Admins().Login(username, password))
                {
                    ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View("Login");
                }
                if (remember == "on")
                {
                    Response.Cookies["_uid"]["username"] = username;
                    Response.Cookies["_uid"]["password"] = password;
                    Response.Cookies["_uid"].Expires = DateTime.Now.AddYears(1);
                }
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }

        }
        public ActionResult Logout()
        {
            Session[Admins.CURRENT_ADMIN_SESSION_KEY] = null;
            Admins.Current = null;
            Response.Cookies["_uid"].Expires = DateTime.Now.AddDays(-1);
            return View("Login");
        }

        public ActionResult Accounts()
        {
            return View(_admin.GetAll());
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateAccount(Admin admin)
        {
            try
            {
                _admin.Create(admin);
                ViewBag.msg = "success";
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditAccount(int? id)
        {
            try
            {
                if (id != null)
                {
                    var admin = _db.Admins.Find(id);
                    if (admin == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    return View(admin);
                }
                return View("Accounts");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditAccount(Admin admin)
        {
            try
            {
                _admin.Update(admin);
                ViewBag.msg = "success";
                return View(admin);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditProfile()
        {
            try
            {
                var admin = _db.Admins.Find(Admins.Current.Id);
                    if (admin == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    return View(admin);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditProfile(Admin admin)
        {
            try
            {
                _admin.EditProfile(admin);
                ViewBag.msg = "success";
                return View(admin);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult ActiveAccount(int id)
        {
            try
            {
                var admin = _db.Admins.Find(id);
                if (admin == null)
                {
                    return RedirectToAction("Error404");
                }
                admin.Active = admin.Active != true;
                _db.SaveChanges();
                return RedirectToAction("Accounts", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region permission

        public ActionResult AddGroupPage(int id)
        {
            ViewBag.lstTypePage = _permission.GetGroupPageByAdminId(id);
            return View(_db.Admins.Find(id));
        }
        
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddGroupPage(TypePage typePage, int aid)
        {
            try
            {
                _permission.CreateTypePage(typePage);
                ViewBag.msg = "success";
                ViewBag.lstTypePage = _permission.GetGroupPageByAdminId(aid);
                return RedirectToAction("AddGroupPage",new{id = aid});
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditGroupPage(int? id)
        {
            try
            {
                if (id != null)
                {
                    var typePage = _db.TypePages.Find(id);
                    if (typePage == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    return View(typePage);
                }
                return View("Accounts");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditGroupPage(TypePage typePage)
        {
            try
            {
                _permission.UpdateTypePage(typePage);
                ViewBag.msg = "success";
                return View(typePage);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public ActionResult DeleteGroupPage(int id, int adminid)
        {
            try
            {
                var typePage = _db.TypePages.Find(id);
                if (typePage == null)
                {
                    return RedirectToAction("Error404");
                }
                foreach (var item in _db.Pages.Where(a => a.TypeId == id))
                {
                    _db.Pages.Remove(item);
                }
                _db.TypePages.Remove(typePage);
                _db.SaveChanges();

                return Redirect("/Cpanel/AddGroupPage/" + adminid);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }


        public ActionResult AddPage(int id, int? typeid, int? groupid)
        {
            try
            {
                var admin = _db.Admins.Find(id);
                ViewBag.GroupId = new SelectList(_permission.GetAllTypePage(), "Id", "Name", groupid ?? null);
                ViewBag.PageId = new SelectList(_permission.GetPageByTypeId(groupid ?? _permission.GetAllTypePage().FirstOrDefault().Id), "Id", "Name");
                ViewBag.lstPage = _permission.GetPageByTypeIdAndAdminId(id);
                ViewBag.TypeId = new SelectList(_permission.GetGroupPageByAdminId(id), "Id", "Name", typeid);
                return View(admin);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddPage(Page page, int pageid, int groupid)
        {
            try
            {
                _permission.CreatePage(page, pageid);
                return RedirectToAction("AddPage", new { id = page.AdminId, typeid = page.TypeId, groupid = groupid });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult DeletePage(int id)
        {
            try
            {
                var page = _db.Pages.Find(id);
                if (page == null)
                {
                    return RedirectToAction("Error404");
                }
                var admin = page.AdminId;
                _db.Pages.Remove(page);
                _db.SaveChanges();
                return Redirect("/cpanel/addpage/" + admin);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region status

        public ActionResult Status()
        {
            return View(_status.GetAll(1));
        }

        public ActionResult CreateStatus()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateStatus(Status status)
        {
            try
            {
                _db.Status.Add(status);
                _db.SaveChanges();
                ViewBag.msg = "success";
                return View();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public ActionResult EditStatus(int? id)
        {
            try
            {
                if (id != null)
                {
                    var status = _db.Status.Find(id);
                    if (status == null)
                    {
                        return RedirectToAction("Error404");
                    }
                    return View(status);
                }
                return View("Status");
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditStatus(Status status)
        {
            try
            {
                _status.Update(status);
                ViewBag.msg = "success";
                return View(status);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public ActionResult DeleteStatus(int id)
        {
            try
            {
                var status = _db.Status.Find(id);
                if (status == null)
                {
                    return RedirectToAction("Error404");
                }
                _db.Status.Remove(status);
                _db.SaveChanges();

                return RedirectToAction("Status", new { msg = "success" });
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion

        #region images content

        public ActionResult AddImages(int? contentid)
        {
            StaticVariable.ImageContents.AddRange(_db.ImageContents.Where(a => a.ContentId == contentid));
            ViewBag.ContentId = contentid;
            return View();
        }

        [HttpPost]
        public ActionResult AddImages(HttpPostedFileBase image, ImageContent imageContent)
        {
            imageContent.Image = Tool.UploadImage(image);
            _db.ImageContents.Add(imageContent);
            _db.SaveChanges();
            StaticVariable.ImageContents.Add(imageContent);
            return Redirect("/cpanel/addimages" + (imageContent.ContentId == null ? "" : "?contentid=" + imageContent.ContentId));
        }

        public ActionResult DeleteImageContent(int id, int? contentid)
        {
            var image = _db.ImageContents.Find(id);
            _db.ImageContents.Remove(image);
            _db.SaveChanges();
            StaticVariable.ImageContents.Remove(StaticVariable.ImageContents.FirstOrDefault(a => a.Id == id));
            return Redirect("/cpanel/addimages" + (contentid == null ? "" : "?contentid=" + contentid));
        }

        #endregion

    }
}
