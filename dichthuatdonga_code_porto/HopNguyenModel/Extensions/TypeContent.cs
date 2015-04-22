using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HopNguyenModel.General;

namespace HopNguyenModel
{
    /// <summary>
    /// Create by Hop Nguyen 18/09/2013
    /// </summary>
    
    public partial class TypeContent
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        #region field

        public string Url
        {
            get { return "/" + Alias + ".html"; }
        }

        #endregion

        public List<TypeContent> GetAll(int groupId)
        {
            try
            {
                return _db.TypeContents.Where(a => a.GroupId == groupId).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public TypeContent GetById(int id)
        {
            try
            {
                return _db.TypeContents.Find(id);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public TypeContent GetByAlias(string alias)
        {
            try
            {
                return _db.TypeContents.FirstOrDefault(a => a.Alias == alias);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<TypeContent> GetByParent(int parent)
        {
            try
            {
                return _db.TypeContents.Where(a => a.Parent == parent && a.Status == true).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public string CheckAlias(string alias, int groupId)
        {
            try
            {
                var i = 0;
                while (_db.TypeContents.FirstOrDefault(a => a.Alias.Equals(alias)) != null)
                {
                    alias = alias + i;
                    i++;
                }
                return alias;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public string CheckAliasUpdate(string alias, int groupId, int id)
        {
            try
            {
                var i = 0;
                while (_db.TypeContents.FirstOrDefault(a => a.Id != id && a.Alias.Equals(alias) && a.GroupId == groupId) != null)
                {
                    alias = alias + i;
                    i++;
                }
                return alias;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void Update(TypeContent typeContent, HttpPostedFileBase file)
        {
            try
            {
                var obj = _db.TypeContents.Find(typeContent.Id);
                if (obj != null)
                {
                    obj.Name = typeContent.Name;
                    obj.Alias = CheckAliasUpdate(Tool.RemoveUnicode(typeContent.Name), typeContent.GroupId, typeContent.Id);
                    obj.Parent = typeContent.Parent;
                    if (file != null)
                    {
                        obj.Image = Tool.UploadImage(file);
                    }
                    obj.Status = typeContent.Status;
                    obj.Sort = typeContent.Sort;
                    obj.Summary = typeContent.Summary;
                    obj.MetaTitle = typeContent.MetaTitle;
                    obj.MetaDescription = typeContent.MetaDescription;
                    obj.MetaKeyword = typeContent.MetaKeyword;
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
        public List<TypeContent> GetMultiLevel(int groupId)
        {
            try
            {
                var list = new List<TypeContent>();
                foreach (var item in GetParentNull(groupId))
                {
                    list.AddRange(GetAllTypeByParent(item));
                }
                foreach (var item in list)
                {
                    var list3 = GetAllParentOfTypeProduct(item.Id);
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

        public List<TypeContent> GetParentNull(int groupId)
        {
            try
            {
                return _db.TypeContents.Where(a => a.Parent == null && a.GroupId == groupId && a.Status == true).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        List<TypeContent> GetAllTypeByParent(TypeContent parent)
        {
            try
            {
                var list = new List<TypeContent>();
                var source = _db.TypeContents.Where(a => a.Parent == parent.Id && a.Status == true);
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
        List<TypeContent> GetAllParentOfTypeProduct(int typeproductid)
        {
            try
            {
                var list = new List<TypeContent>();
                var item = _db.TypeContents.SingleOrDefault(a => a.Id.Equals(typeproductid));
                if (item != null && item.Parent.HasValue)
                {
                    list = GetAllParentOfTypeProduct(item.Parent.Value);
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
