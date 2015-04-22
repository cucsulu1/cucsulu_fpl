using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Web;

namespace HopNguyenModel.General
{
    public class Tool
    {
        public static string RemoveUnicode(string s)
        {
            var stFormD = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var t in stFormD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if(uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }
            var str = sb.ToString().Normalize(NormalizationForm.FormC);
            str = str.Replace(' ', '-');
            str = str.Replace('/', '-');
            str = str.Replace('\\', '-');
            str = str.Replace('&', '-');
            str = str.Replace('Đ', 'D');
            str = str.Replace('đ', 'd');
            str = str.Replace('+', '-');
            str = str.Replace('#', '-');
            str = str.Replace('~', '-');
            str = str.Replace('*', '-');
            str = str.Replace('(', '-');
            str = str.Replace(')', '-');
            str = str.Replace('[', '-');
            str = str.Replace(']', '-');
            str = str.Replace('{', '-');
            str = str.Replace('}', '-');
            str = str.Replace('|', '-');
            str = str.Replace('%', '-');
            str = str.Replace('$', '-');
            str = str.Replace('^', '-');
            str = str.Replace(';', '-');
            str = str.Replace('\'', '-');
            str = str.Replace('"', '-');
            str = str.Replace('<', '-');
            str = str.Replace('>', '-');
            str = str.Replace('?', '-');
            str = str.Replace(':', '-');
            str = str.Replace('.', '-');
            str = str.Replace(',', '-');
            for(int i = 0; i < 20; i++)
                str = str.Replace("--", "-");
            return (str.ToLower());
        }

        public static string ReplaceSpace(string str)
        {
            str = str.Replace(' ', '-');
            return (str.ToLower());
        }

        public static string UploadImage(HttpPostedFileBase image)
        {
            try
            {
                if (image != null && image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var filepath = HttpContext.Current.Server.MapPath("~/Upload/Images/" + fileName);
                    int i = 0;
                    while (File.Exists(filepath))
                    {
                        i++;
                        fileName = i + fileName;
                        filepath = HttpContext.Current.Server.MapPath("~/Upload/Images/" + fileName);
                    }
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/Images/"), fileName);
                    image.SaveAs(path);
                    return "/upload/images/" + fileName;
                }
                return null;
            }
            catch (Exception ex)
            {
                SystemLog.WriteLog(ex);
                throw;
            }
        }

        public static void DeleteFile(string file)
        {
            try
            {
                var info = new FileInfo(HttpContext.Current.Server.MapPath(file));
                if (info.Exists)
                {
                    info.Delete();
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
