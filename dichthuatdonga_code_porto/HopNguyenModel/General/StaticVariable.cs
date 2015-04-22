using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HopNguyenModel.General
{
    public class StaticVariable
    {
        private static List<ImageContent> _imageContents;


        public static List<ImageContent> ImageContents
        {
            get { return _imageContents ?? (_imageContents = new List<ImageContent>()); }
            set { _imageContents = value; }
        }
    }
}
