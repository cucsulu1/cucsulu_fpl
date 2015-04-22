using System;
using System.Collections.Generic;
using System.Linq;
using HopNguyenModel.General;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 21/09/2013
    /// </summary>
    
    public partial class PageDetail
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public List<PageDetail> GetAll()
        {
            try
            {
                return _db.PageDetails.ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public PageDetail GetById(int id)
        {
            try
            {
                return _db.PageDetails.Find(id) ?? new PageDetail();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public PageDetail GetByAlias(string alias)
        {
            try
            {
                return _db.PageDetails.FirstOrDefault(a => a.Alias == alias);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(PageDetail pageDetail)
        {
            try
            {
                var obj = _db.PageDetails.Find(pageDetail.Id);
                if (obj != null)
                {
                    if (pageDetail.Name != null)
                    {
                        obj.Name = pageDetail.Name;
                        obj.Alias = Tool.RemoveUnicode(pageDetail.Name);
                    }
                    obj.MetaTitle = pageDetail.MetaTitle;
                    obj.MetaKeyword = pageDetail.MetaKeyword;
                    obj.MetaDescription = pageDetail.MetaDescription;
                    obj.Detail = pageDetail.Detail;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
    }
}
