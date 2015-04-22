using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HopNguyenModel.General;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 20/09/2013
    /// </summary>
    
    public partial class Image
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public List<Image> GetAll()
        {
            try
            {
                return _db.Images.ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<Image> GetByTypeId(int typeId)
        {
            try
            {
                return _db.Images.Where(a => a.TypeId == typeId).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public Image GetById(int id)
        {
            try
            {
                return _db.Images.SingleOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(Image image, HttpPostedFileBase file)
        {
            try
            {
                var obj = _db.Images.Find(image.Id);
                if (obj != null)
                {
                    obj.Name = image.Name;
                    obj.Link = image.Link;
                    obj.TypeId = image.TypeId;
                    if (file != null)
                    {
                        obj.Image1 = Tool.UploadImage(file);
                    }
                    obj.Summary = image.Summary;
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
