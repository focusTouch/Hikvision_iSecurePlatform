using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class Area
    {
       public string indexCode{get;set;}
       public string name{get;set;}
       public string parentIndexCode{get;set;}
       public string treeCode{get;set;}
    }

}