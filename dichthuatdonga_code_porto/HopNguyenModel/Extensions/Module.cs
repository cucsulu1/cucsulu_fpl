using System;
using System.Collections.Generic;
using System.Linq;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 22/09/2013
    /// </summary>
    
    public partial class Module
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public List<Module> GetAll()
        {
            try
            {
                return _db.Modules.ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public Module GetById(int id)
        {
            try
            {
                return _db.Modules.Find(id) ?? new Module();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(Module module)
        {
            try
            {
                var obj = _db.Modules.Find(module.Id);
                if (obj != null)
                {
                    obj.Name = module.Name;
                    obj.Detail = module.Detail;
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
