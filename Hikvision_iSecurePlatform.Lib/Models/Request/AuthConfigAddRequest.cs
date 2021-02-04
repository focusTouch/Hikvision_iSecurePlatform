using System;
using System.Collections.Generic;
using System.Text;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    public class AuthConfigAddRequest
    {
        public List<PersonData> personDatas { get; set; }
        public List<RresourceInfo> resourceInfos { get; set; }

        public string startTime { get; set; }
        public string endTime { get; set; }

        public class PersonData
        {
            public List<String> indexCodes { get; set; }

            public string personDataType { get; set; }
        }

        public class RresourceInfo
        {
            public string resourceIndexCode { get; set; }
            public string resourceType { get; set; }
            public List<int> channelNos { get; set; }
        }

    }

 
}
