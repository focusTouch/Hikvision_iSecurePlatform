using System;
using System.Collections.Generic;
using System.Text;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    public class AuthDownloadShortcutReq
    {
        public int taskType { get; set; }

        public List<ResourceInfo> resourceInfos { get; set; }

        public class ResourceInfo
        {
            public string resourceIndexCode { get; set; }
            public string resourceType { get; set; }
            public List<int> channelNos { get; set; }
        }
    }
}
