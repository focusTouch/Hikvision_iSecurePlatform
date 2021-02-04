using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;
using Hikvision_iSecurePlatform.Lib.Models.Request;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class Person
    {
        public string personId { get; set; }
        public string personName { get; set; }
        public int? gender { get; set; }
        public string orgPath { get; set; }
        public string orgIndexCode { get; set; }
        public int? certificateType { get; set; }
        public string orgPathName { get; set; }
        public string certificateNo { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
        public string phoneNo { get; set; }
        public string jobNo { get; set; }
        public string personPhotoIndexCode { get; set; }
        public string picUri { get; set; }
        public string pageNo{ get; set; }
        public string pageSize{ get; set; }
        
        public string serverIndexCode { get; set; }
        public List<FaceData> faces { get; set; }

    }

}