using System;
using System.Collections.Generic;
using System.Linq;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 22/09/2013
    /// </summary>
    
    public class Permission
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public void CreateTypePage(TypePage typePage)
        {
            try
            {
                _db.TypePages.Add(typePage);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void UpdateTypePage(TypePage typePage)
        {
            try
            {
                var obj = _db.TypePages.Find(typePage.Id);
                if (obj != null)
                {
                    obj.Name = typePage.Name;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void CreatePage(Page page, int pageId)
        {
            try
            {
                var objPage = _db.Pages.Find(pageId);
                if (objPage != null)
                {
                    page.Name = page.Name ??  objPage.Name;
                    page.Link = objPage.Link;
                    _db.Pages.Add(page);
                    _db.SaveChanges();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TypePage> GetGroupPageByAdminId(int adminid)
        {
            try
            {
                return _db.TypePages.Where(a => a.AdminId == adminid || a.AdminId == null).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<TypePage> GetAllTypePage()
        {
            try
            {
                return _db.TypePages.Where(a => a.AdminId == 1 || a.AdminId == null).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Page> GetPageByTypeId(int typeid)
        {
            try
            {
                return _db.Pages.Where(a => a.AdminId == 1 && a.TypeId == typeid).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Page> GetPageByTypeIdAndAdminId(int adminid)
        {
            try
            {
                return _db.Pages.Where(a => a.AdminId == adminid).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        } 
    }
}
