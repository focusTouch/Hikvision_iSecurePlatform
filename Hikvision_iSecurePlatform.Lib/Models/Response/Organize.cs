using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class Organize
    {
       public string orgIndexCode{get;set;}
       public string orgNo{get;set;}
       public string orgName{get;set;}
       public string orgPath{get;set;}
       public string parentOrgIndexCode{get;set;}
       public string parentOrgName{get;set;}
       public string updateTime{get;set;}
    }

}