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
    
    public partial class TypeImage
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        public List<TypeImage> GetAll()
        {
            try
            {
                return _db.TypeImages.ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<TypeImage> GetByParent(int parent)
        {
            try
            {
                return _db.TypeImages.Where(a => a.Parent == parent).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public TypeImage GetById(int id)
        {
            try
            {
                return _db.TypeImages.Find(id) ?? new TypeImage();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(TypeImage typeImage, HttpPostedFileBase file)
        {
            try
            {
                var obj = _db.TypeImages.Find(typeImage.Id);
                if (obj != null)
                {
                    obj.Name = typeImage.Name;
                    obj.Parent = typeImage.Parent;
                    if (file != null)
                    {
                        obj.Image = Tool.UploadImage(file);
                    }
                    obj.Summary = typeImage.Summary;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        #region load multi level combobox
        public List<TypeImage> GetMultiLevel()
        {
            try
            {
                var list = new List<TypeImage>();
                foreach (var item in GetParentNull())
                {
                    list.AddRange(GetAllTypeByParent(item));
                }
                foreach (var item in list)
                {
                    var list3 = GetAllParentOfType(item.Id);
                    if (list3 != null && list3.Count > 1)
                    {
                        for (int j = 0; j < (list3.Count - 1); j++)
                        {
                            item.Name = " - - " + item.Name;
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<TypeImage> GetParentNull()
        {
            try
            {
                return _db.TypeImages.Where(a => a.Parent == null).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        IEnumerable<TypeImage> GetAllTypeByParent(TypeImage parent)
        {
            try
            {
                var list = new List<TypeImage>();
                var source = _db.TypeImages.Where(a => a.Parent == parent.Id && a.Status == true);
                list.Add(parent);
                if (source.Any())
                {
                    foreach (var item in source)
                    {
                        list.AddRange(GetAllTypeByParent(item));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }

        }
        List<TypeImage> GetAllParentOfType(int typeproductid)
        {
            try
            {
                var list = new List<TypeImage>();
                var item = _db.TypeImages.SingleOrDefault(a => a.Id.Equals(typeproductid));
                if (item != null && item.Parent.HasValue)
                {
                    list = GetAllParentOfType(item.Parent.Value);
                    list.Add(item);
                }
                else
                {
                    list.Add(item);
                }
                return list;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        #endregion
    }
}
