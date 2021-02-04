using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;
using Hikvision_iSecurePlatform.Lib.Models.Request;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class Card
    {
        public string cardNo { get; set; }
        public string personId { get; set; }

        public string orgIndexCode { get; set; }
        public string cardType { get; set; }

    }

}
