using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HopNguyenModel.Extensions
{
    public class Context
    {

        public CommonService CommonService
        {
            get
            {
                if (_commonService == null)
                    _commonService = new CommonService(this);

                return _commonService;
            }
        }
    }
}
