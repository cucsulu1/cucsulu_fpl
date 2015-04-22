using System;
using System.Collections.Generic;
using System.Linq;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 21/09/2013
    /// </summary>
    
    public partial class TypeSupport
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public List<TypeSupport> GetAll()
        {
            try
            {
                return _db.TypeSupports.ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public TypeSupport GetById(int id)
        {
            try
            {
                return _db.TypeSupports.SingleOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(TypeSupport typeSupport)
        {
            try
            {
                var obj = _db.TypeSupports.Find(typeSupport.Id);
                if (obj != null)
                {
                    obj.Name = typeSupport.Name;
                    obj.Pattern = typeSupport.Pattern;
                    obj.Parameter = typeSupport.Parameter;
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
