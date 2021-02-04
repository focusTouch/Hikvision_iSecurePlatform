using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    public class CardQuery
    {
        public int pageNo { get; set; }

        public int pageSize { get; set; }


    }

}
