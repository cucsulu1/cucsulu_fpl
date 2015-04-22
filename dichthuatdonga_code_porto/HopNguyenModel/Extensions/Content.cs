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

    public partial class Content
    {
        readonly HopNguyenEntities _db = new HopNguyenEntities();

        #region field
        List<Content> _other; 
        public List<Content> GetOther
        {
            get{
                return _other ?? (_other=_db.Contents.Where(a => a.Id != Id && a.TypeId == TypeId).ToList());
            }
        }

        private string _url;
        public string Url
        {
            get { return _url??("/" + TypeContent.Alias + "/" + Alias + ".html"); }
            set { _url = value; }
        }

        public string TypeUrl
        {
            get { return "/" + TypeContent.Alias + ".html"; }
        }

        #endregion

        #region method
        public List<Content> GetAll(int groupId)
        {
            try
            {
                return _db.Contents.Where(a => a.GroupId == groupId).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<Content> GetByTypeId(int typeid)
        {
            try
            {
                return _db.Contents.Where(a => a.TypeId == typeid && a.Status == true).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public IEnumerable<Content> GetMenuByTypeId(int typeid)
        {
            try
            {
                return _db.Contents.Where(a => a.TypeId == typeid && a.Status == true);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }
        public List<Content> GetByStatusId(int statusid)
        {
            try
            {
                return _db.Status.SingleOrDefault(a => a.Id == statusid).Contents.ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<Content> GetByTypeAlias(string alias)
        {
            try
            {
                return _db.Contents.Where(a => a.TypeContent.Alias == alias && a.Status == true).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<Content> GetAllChildByType(string typeAlias)
        {
            try
            {
                return _db.Contents.Where(a => a.TypeContent.Alias.Equals(typeAlias) ||
                        (a.TypeContent.TypeContent2 != null && a.TypeContent.TypeContent2.Alias.Equals(typeAlias)) ||
                        (a.TypeContent.TypeContent2.TypeContent2 != null &&
                         a.TypeContent.TypeContent2.TypeContent2.Alias.Equals(typeAlias)) ||
                        (a.TypeContent.TypeContent2.TypeContent2.TypeContent2 != null &&
                         a.TypeContent.TypeContent2.TypeContent2.TypeContent2.Alias.Equals(typeAlias)) &&
                        a.Status == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Content> GetAllChildByTypeId(int typeId)
        {
            try
            {
                return _db.Contents.Where(a => a.TypeContent.Id.Equals(typeId) ||
                        (a.TypeContent.TypeContent2 != null && a.TypeContent.TypeContent2.Id.Equals(typeId)) ||
                        (a.TypeContent.TypeContent2.TypeContent2 != null &&
                         a.TypeContent.TypeContent2.TypeContent2.Id.Equals(typeId)) ||
                        (a.TypeContent.TypeContent2.TypeContent2.TypeContent2 != null &&
                         a.TypeContent.TypeContent2.TypeContent2.TypeContent2.Id.Equals(typeId)) &&
                        a.Status == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Content> SearchByName(string name)
        {
            try
            {
                return _db.Contents.Where(a => (a.Name.Contains(name) || a.TypeContent.Name.Contains(name) || a.Summary.Contains(name)) && a.Status == true).ToList();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public List<Content> GetByTagName(string name)
        {
            try
            {
                var tags = _db.Tags.ToList();
                var contents = new List<Content>();
                foreach (var tag in tags)
                {
                    if (Tool.ReplaceSpace(tag.Name).Equals(name.ToLower()))
                    {
                        contents.AddRange(tag.Contents.ToList());
                    }
                }
                return contents;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void SetHit(int number, string alias)
        {
            try
            {
                var obj = _db.Contents.FirstOrDefault(a => a.Alias == alias);
                if (obj != null)
                {
                    if (obj.Hit != null)
                        obj.Hit += number;
                    else
                        obj.Hit = 1;
                }
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public Content GetById(int id)
        {
            try
            {
                return _db.Contents.Find(id);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public Content GetByAlias(string alias)
        {
            try
            {
                SetHit(1, alias);
                return _db.Contents.FirstOrDefault(a => a.Alias == alias);
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public string CheckAlias(string alias)
        {
            try
            {
                var i = 0;
                while (_db.Contents.FirstOrDefault(a => a.Alias.Equals(alias)) != null)
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

        public string CheckAliasUpdate(string alias, int id)
        {
            try
            {
                var i = 0;
                while (_db.Contents.FirstOrDefault(a => a.Id != id && a.Alias.Equals(alias)) != null)
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

        public Tag CheckTag(string tagName)
        {
            try
            {
                return _db.Tags.FirstOrDefault(a => a.Name.Equals(tagName));
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public void CreateContent(HttpPostedFileBase image, Content content, int groupId, string tags)
        {
            try
            {
                content.Alias = CheckAlias(Tool.RemoveUnicode(content.Name));
                content.Image = Tool.UploadImage(image);
                content.CreateByAdminId = Admins.Current.Id;
                content.GroupId = groupId;
                content.CreateDate = DateTime.Now;
                foreach (var item in tags.Split(','))
                {
                    var tag = CheckTag(item);
                    if (tag != null)
                    {
                        content.Tags.Add(tag);
                    }
                    else
                    {
                        content.Tags.Add(new Tag { Name = item });
                    }
                }
                foreach (var item in _db.Status.Where(a => a.GroupId == 1))
                {
                    int statusId = Convert.ToInt32(HttpContext.Current.Request["status" + item.Id] ?? "0");
                    if (statusId > 0)
                    {
                        content.Status1.Add(_db.Status.FirstOrDefault(a => a.Id == statusId));
                    }
                }
                _db.Contents.Add(content);
                _db.SaveChanges();

                var lstImages = StaticVariable.ImageContents;

                if (lstImages.Any())
                {
                    foreach (var item in lstImages)
                    {
                        var obj = _db.ImageContents.Find(item.Id);
                        obj.ContentId = content.Id;
                    }
                }
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Content content, HttpPostedFileBase file, string tags)
        {
            try
            {
                var obj = _db.Contents.Find(content.Id);
                if (obj != null)
                {
                    obj.Name = content.Name;
                    obj.Alias = CheckAliasUpdate(Tool.RemoveUnicode(content.Name), content.Id);
                    obj.TypeId = content.TypeId;
                    if (file != null)
                    {
                        obj.Image = Tool.UploadImage(file);
                    }
                    obj.Price = content.Price;
                    obj.Status = content.Status;
                    obj.Summary = content.Summary;
                    obj.Detail = content.Detail;
                    obj.MetaTitle = content.MetaTitle;
                    obj.MetaDescription = content.MetaDescription;
                    obj.MetaKeyword = content.MetaKeyword;

                    var lstTags = tags.Split(',');
                    foreach (var i in obj.Tags.ToList())
                    {
                        var countTags = lstTags.Count(x => x == i.Name);
                        if (countTags == 0)
                        {
                            obj.Tags.Remove(i);
                        }
                    }
                    foreach (var item in lstTags)
                    {
                        var tag = CheckTag(item);
                        if (tag != null)
                        {
                            obj.Tags.Add(tag);
                        }
                        else
                        {
                            obj.Tags.Add(new Tag { Name = item });
                        }
                    }
                    foreach (var item in obj.Status1.ToList())
                    {
                        obj.Status1.Remove(item);
                    }
                    foreach (var item in _db.Status.Where(a => a.GroupId == 1))
                    {
                        if (HttpContext.Current.Request["status" + item.Id] != null)
                        {
                            int statusId = Convert.ToInt32(HttpContext.Current.Request["status" + item.Id]);
                            obj.Status1.Add(_db.Status.FirstOrDefault(a => a.Id == statusId));
                        }
                    }
                    _db.SaveChanges();

                    var lstImages = StaticVariable.ImageContents;

                    if (lstImages.Any())
                    {
                        foreach (var item in lstImages)
                        {
                            var objImage = _db.ImageContents.Find(item.Id);
                            objImage.ContentId = content.Id;
                        }
                    }

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
        #endregion
}
