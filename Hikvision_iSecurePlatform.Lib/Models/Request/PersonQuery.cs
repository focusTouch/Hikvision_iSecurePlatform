using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;
using Hikvision_iSecurePlatform.Lib.Models.Request;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    public class PersonQuery : PageQuery
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        /// <value>可以指定人员personId，不允许与其他人员personId重复，包括已删除的人员。 为空时平台自动生成人员ID</value>
       public string personIds{get;set;}
       public string personName{get;set;}
       public int? gender{get;set;}
       public string orgIndexCodes{get;set;}
 
       public int? certificateType{get;set;}
       public string certificateNo{get;set;}
       public bool? isSubOrg{get;set;}
       public string cardNo{get;set;}
       public string plateNo{get;set;}
       public string orderBy{get;set;}
       public string orderType{get;set;}
       public string orgIndexCode{get;set;}
       public List<ExpressionQuery> expressions{get;set;}
    }

}