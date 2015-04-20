using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPlus
{
    public class FacePost
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string ImageFile { get; set; }
        public string PostLink { get; set; }
        public string WebsiteLink { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
