using System;
using System.Linq;
using System.Web;

namespace HopNguyenModel.General
{
    public class GenerateMeta
    {

        public string AutoGenerateMeta(string page, string alias)
        {
            try
            {
                var db = new HopNguyenEntities();
                var title = "";
                var keyword = "";
                var description = "";
                var image = @"/upload/editor/images/dich-thuat-dong-a-logo.png";
                if (!string.IsNullOrEmpty(alias) && alias!="danh-sach")
                {
                    var content = db.Contents.FirstOrDefault(a => a.Alias == alias);
                    if (content != null)
                    {
                        title = !string.IsNullOrEmpty(content.MetaTitle) ? content.MetaTitle : content.Name;
                        keyword = content.MetaKeyword;
                        description = !string.IsNullOrEmpty(content.MetaDescription) ? content.MetaDescription : content.Summary;
                        image = content.Image;
                        return Meta(title, keyword, description, image);
                    }
                } 
                else 
                if (!string.IsNullOrEmpty(page))
                {
                    var pageDetail = db.PageDetails.FirstOrDefault(a => a.Alias == page);
                    if (pageDetail != null)
                    {
                        title = !string.IsNullOrEmpty(pageDetail.MetaTitle) ? pageDetail.MetaTitle : pageDetail.Name;
                        keyword = pageDetail.MetaKeyword;
                        description = pageDetail.MetaDescription;
                        return Meta(title, keyword, description, image);
                    }
                }
                else 
                {
                    var homePage = db.PageDetails.FirstOrDefault();
                    if (homePage != null)
                    {
                        title = homePage.MetaTitle;
                        keyword = homePage.MetaKeyword;
                        description = homePage.MetaDescription;
                    }
                }
                return Meta(title, keyword, description,image);
            }
            catch (Exception)
            {

                throw;
            }
        }

        static string Meta(string title, string keyword, string description,string image)
        {
            var meta = "<title>" + title + "</title>" + Environment.NewLine;
            if (!string.IsNullOrEmpty(keyword))
            {
                meta += "    <meta name=\"keywords\" content=\"" + keyword + "\" />" + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(description))
            {
                meta += "    <meta name=\"description\" content=\"" + description + "\" />" + Environment.NewLine;
            }
            meta += "    <link rel=\"canonical\" href=\"" + HttpContext.Current.Request.Url + "\" />";
            if (!string.IsNullOrEmpty(image))
            {
                meta += "<meta itemprop='image' content='"+image+"'>";
            }
            meta += "<meta property=\"og:title\" content=\"" + title + "\" />" +
            "<meta property=\"og:type\" content=\"article\" /> "+
            "<meta property=\"og:url\" content=\"http://dichthuatdonga.com/\" />" +
            "<meta property=\"og:image\" content=\"" + image + "\" /> " +
            "<meta property=\"og:description\" content=\"" + (string.IsNullOrEmpty(description) ? "" : (description.Length > 160 ? description .Substring(0,159): description)) + "\" />";
            return meta;
        }
    }
}
