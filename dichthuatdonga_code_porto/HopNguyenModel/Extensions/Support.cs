using System;
using System.Collections.Generic;
using System.Linq;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 21/09/2013
    /// </summary>
    
    public partial class Support
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public Support GetFirst()
        {
            try
            {
                return _db.Supports.FirstOrDefault();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<Support> GetAll()
        {
            try
            {
                return _db.Supports.ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<Support> GetAllAndRepair()
        {
            try
            {
                 var lstSupport = _db.Supports.ToList();
                foreach (var item in lstSupport)
                {
                    item.Nick = item.TypeSupport.Pattern.Replace(item.TypeSupport.Parameter, item.Nick);
                }
                return lstSupport;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public Support GetById(int id)
        {
            try
            {
                return _db.Supports.SingleOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(Support support)
        {
            try
            {
                var obj = _db.Supports.Find(support.Id);
                if (obj != null)
                {
                    obj.TypeId = support.TypeId;
                    obj.Name = support.Name;
                    obj.Phone = support.Phone;
                    obj.Nick = support.Nick;
                    obj.Email = support.Email;
                    obj.Summary = support.Summary;
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
