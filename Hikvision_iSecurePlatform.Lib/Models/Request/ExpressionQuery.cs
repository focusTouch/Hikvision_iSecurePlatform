using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    public class ExpressionQuery
    {
       public String key{get;set;}

       public int? @operator{get;set;}

       public List<String> values{get;set;}

    }

}