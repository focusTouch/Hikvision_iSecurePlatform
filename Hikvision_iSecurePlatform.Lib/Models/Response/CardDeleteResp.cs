using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;
using Hikvision_iSecurePlatform.Lib.Models.Request;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class CardDeleteResp
    {
        public string code { get; set; }
        public string msg { get; set; }
        public string data { get; set; }

    }

}
