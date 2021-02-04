using System;
using System.Collections.Generic;
using System.Text;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class Resource
    {
        public string indexCode { get; set; }
        public string name { get; set; }
        public string resourceType { get; set; }
        public string doorNo { get; set; }
        public string description { get; set; }
        public string parentIndexCodes { get; set; }
        public string regionIndexCode { get; set; }
        public string regionPath { get; set; }
        public string channelType { get; set; }
        public string channelNo { get; set; }
        public string installLocation { get; set; }
        public string capabilitySet { get; set; }
        public string controlOneId { get; set; }
        public string controlTwoId { get; set; }
        public string readerInId { get; set; }
        public string readerOutId { get; set; }
        public string comId { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
    }
}
