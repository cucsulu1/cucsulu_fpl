using System;
using System.Web;

namespace HopNguyenModel
{
    public partial class SystemLog
    {
        public static void WriteLog(Exception ex)
        {
            using (var db = new HopNguyenEntities())
            {
                var log = new SystemLog
                              {
                                  AdminError = Admins.Current.Id,
                                  DateCreate = DateTime.Now,
                                  ErrorMessage = ex.ToString(),
                                  ErrorSource = ex.Source,
                                  ErrorStackTrace = ex.StackTrace,
                                  IpError = HttpContext.Current.Request.UserHostAddress
                              };
                db.SystemLogs.Add(log);
                db.SaveChanges();
            }
        }
    }
}
