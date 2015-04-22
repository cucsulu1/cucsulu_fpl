using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using HopNguyenModel.General;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 16/09/2013
    /// </summary>

    public class Admins
    {
        public const String CURRENT_ADMIN_SESSION_KEY = null;
        private readonly HopNguyenEntities _db = new HopNguyenEntities();
        
        public static Admin Current
        {
            get { return HttpContext.Current.Session[CURRENT_ADMIN_SESSION_KEY] as Admin; }
            set { HttpContext.Current.Session[CURRENT_ADMIN_SESSION_KEY] = value; }
        }

        //check login
        public bool Login(string user, string pass)
        {
            try
            {
                Current = _db.Admins.FirstOrDefault(u => u.Username.ToLower() == user.ToLower() && u.Password == pass);
                if (Current != null)
                {
                    var admin = _db.Admins.Find(Current.Id);
                    admin.LastLogin = admin.DateLogin;
                    admin.DateLogin = DateTime.Now;
                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
    }
    public partial class Admin
    {
        private readonly HopNguyenEntities _db = new HopNguyenEntities();
        private bool _curr = false;

        public List<Admin> GetAll()
        {
            try
            {
                return _db.Admins.Where(a => a.Id != 1).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public Admin GetById(int id)
        {
            try
            {
                return _db.Admins.SingleOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Create(Admin admin)
        {
            try
            {
                admin.Password = MD5.Encrypt(admin.Password);
                admin.Active = true;
                admin.Parent = Admins.Current.Id;
                admin.DateCreate = DateTime.Now;
                _db.Admins.Add(admin);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Admin admin)
        {
            try
            {
                var obj = _db.Admins.Find(admin.Id);
                if (obj != null)
                {
                    obj.Username = admin.Username;
                    if (admin.Password != null)
                    {
                        obj.Password = MD5.Encrypt(admin.Password);
                    }
                    obj.Email = admin.Email;
                    obj.Fullname = admin.Fullname;
                    obj.Phone = admin.Phone;
                    obj.Order = admin.Order;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void EditProfile(Admin admin)
        {
            try
            {
                var obj = _db.Admins.Find(admin.Id);
                if (obj != null)
                {
                    if (admin.Password != null)
                    {
                        obj.Password = MD5.Encrypt(admin.Password);
                    }
                    obj.Email = admin.Email;
                    obj.Fullname = admin.Fullname;
                    obj.Phone = admin.Phone;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        #region load menu by admin

        //load group menu
        public string LoadGroupMenu()
        {
            try
            {
                var builder = "<li" + (HttpContext.Current.Request.Url.Segments[2].ToLower() == "dashboard" ? " class='active'" : "") + "><a href=\"/cpanel/dashboard\"><i class=\"icon-dashboard\"></i><span class=\"menu-text\"> Trang chủ </span></a></li>";
                foreach (var item in _db.TypePages.Where(a => a.AdminId == Admins.Current.Id))
                {
                    var childMenu = LoadChildMenuByGroupMenu(item.Id);
                    if (!string.IsNullOrEmpty(childMenu))
                    {
                        builder += "<li" + (_curr ? " class='active open'" : "") + "><a href=\"javascript:;\" class=\"dropdown-toggle\">";
                        builder += "<i class=\"icon-cog\"></i>";
						builder += "<span class=\"menu-text\"> "+ item.Name +" </span><b class=\"arrow icon-angle-down\"></b></a>";
                        builder += "<ul class=\"submenu\">"+ childMenu +"</ul></li>";
                        _curr = false;
                    }
                }

                return builder;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        //load child menu by group menu
        private string LoadChildMenuByGroupMenu(int typeId)
        {
            try
            {
                var builder = new StringBuilder();
                var segments = HttpContext.Current.Request.Url.Segments;
                var lstPage = _db.Pages.Where(a => a.TypeId == typeId);
                foreach (var page in lstPage.Where(page => page.TypeId == typeId))
                {
                    if (segments[2].ToLower() == page.Link || segments[2].ToLower() == "create" + page.Link || segments[2].ToLower() == "edit" + page.Link)
                    {
                        builder.Append("<li class=\"active\"><a href=\"/cpanel/" + page.Link + (page.Parameter ?? "") + "\"><i class=\"icon-double-angle-right\"></i> " + page.Name + "</a></li>");
                        _curr = true;
                    }
                    else
                    {
                        builder.Append("<li><a href=\"/cpanel/" + page.Link + (page.Parameter ?? "") + "\"><i class=\"icon-double-angle-right\"></i> " + page.Name + "</a></li>");
                        
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public bool CheckPermission(int adminId)
        {
            try
            {
                var segments = HttpContext.Current.Request.Url.Segments;
                foreach (var item in _db.Pages.Where(a => a.AdminId == adminId))
                {
                    var link = item.Link.ToLower() + "/";
                    if (segments[2].ToLower() == item.Link || segments[2].ToLower() == "dashboard" || segments[2].ToLower() == link)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
