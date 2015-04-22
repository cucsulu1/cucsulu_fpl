using System;
using System.Collections.Generic;
using System.Linq;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 13/10/2013
    /// </summary>
    
    public partial class Status
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public List<Status> GetAll(int groupid)
        {
            try
            {
                return _db.Status.Where(a => a.GroupId == groupid).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public Status GetById(int id)
        {
            try
            {
                return _db.Status.SingleOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(Status status)
        {
            try
            {
                var obj = _db.Status.Find(status.Id);
                if (obj != null)
                {
                    obj.Name = status.Name;
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
