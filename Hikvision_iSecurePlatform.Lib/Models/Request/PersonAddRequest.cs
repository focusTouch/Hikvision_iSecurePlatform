using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    public class PersonAddRequest
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        /// <value>可以指定人员personId，不允许与其他人员personId重复，包括已删除的人员。 为空时平台自动生成人员ID</value>
        public string personId { get; set; }
        public string personName { get; set; }
        public String gender { get; set; }
        public string orgIndexCode { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        /// <value>举例：1992-09-12</value>
        public string birthday { get; set; }


        public string phoneNo { get; set; }
        public string email { get; set; }
        public string certificateType { get; set; }
        public string certificateNo { get; set; }
        public string jobNo { get; set; }
        public List<FaceData> faces { get; set; }
    }

}