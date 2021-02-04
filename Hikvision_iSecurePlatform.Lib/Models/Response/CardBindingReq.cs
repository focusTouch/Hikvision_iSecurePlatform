using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;
using Hikvision_iSecurePlatform.Lib.Models.Request;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class CardBindingReq
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
      
        public List<Card> cardList { get; set; }

    }

}
