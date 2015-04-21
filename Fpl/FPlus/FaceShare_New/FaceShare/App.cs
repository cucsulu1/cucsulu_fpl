using System.Xml;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FPlus
{
    public class App
    {
        public static List<FaceUser> LstFriends = new List<FaceUser>();
        public static List<FaceGroup> LstGroups = new List<FaceGroup>();
        public static List<FacePost> LstPosts = new List<FacePost>();
        public static  string CurrentVersion = "2.0";
        public static  string CurrentCpuId = "";
        public static  int AppId = 0;
        public static string Accesstoken;
        public static string SeverUrl = "http://plus24h.com/";
        public static int AppStatus =0;
        public static void SaveListGroup()
        {
            if (App.LstGroups.Count > 0)
            {
                var mySerializer = new XmlSerializer(typeof(List<FaceGroup>));
                //To write to a file, create a StreamWriter object.
                var myWriter = new StreamWriter(Path.Combine(Application.StartupPath, "list_group.xml"));
                mySerializer.Serialize(myWriter, LstGroups);
                myWriter.Close();
            }
        }

        public static void OpenListGroup()
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(List<FaceGroup>));
                // To write to a file, create a StreamWriter object.
                var myWriter = new XmlTextReader(Path.Combine(Application.StartupPath, "list_group.xml"));
                LstGroups = mySerializer.Deserialize(myWriter) as List<FaceGroup>;
                myWriter.Close();
            }
            catch
            {
            }
        }

        public static void SaveListFriend()
        {
            if (App.LstGroups.Count > 0)
            {
                var mySerializer = new XmlSerializer(typeof(List<FaceUser>));
                //To write to a file, create a StreamWriter object.
                var myWriter = new StreamWriter(Path.Combine(Application.StartupPath, "list_friend.xml"));
                mySerializer.Serialize(myWriter, LstFriends);
                myWriter.Close();
            }
        }
        public static void OpenListFriend()
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(List<FaceGroup>));
                // To write to a file, create a StreamWriter object.
                var reader = new XmlTextReader(Path.Combine(Application.StartupPath, "list_friend.xml"));
                LstFriends = mySerializer.Deserialize(reader) as List<FaceUser>;
                reader.Close();
            }
            catch
            {
            }
        }

        public static void SaveListPost()
        {
            if (App.LstPosts.Count > 0)
            {
                var mySerializer = new XmlSerializer(typeof(List<FacePost>));
                //To write to a file, create a StreamWriter object.
                var myWriter = new StreamWriter(Path.Combine(Application.StartupPath, "list_post.xml"));
                mySerializer.Serialize(myWriter, LstPosts);
                myWriter.Close();
            }
        }

        public static void OpenListPost()
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(List<FacePost>));
                // To write to a file, create a StreamWriter object.
                var myWriter = new XmlTextReader(Path.Combine(Application.StartupPath, "list_post.xml"));
                LstPosts = mySerializer.Deserialize(myWriter) as List<FacePost>;
                myWriter.Close();
            }
            catch
            {
            }
        }
    }
}
