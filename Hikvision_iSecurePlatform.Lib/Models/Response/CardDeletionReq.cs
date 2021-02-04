using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;
using Hikvision_iSecurePlatform.Lib.Models.Request;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class CardDeletionReq
    {
        public string cardNumber { get; set; }
        public string personId { get; set; }

    }

}

