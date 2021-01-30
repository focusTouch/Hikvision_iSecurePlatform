using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class BaseResponse<T>
    {
       public string code{get;set;}
       public string msg{get;set;}
       public T data{get;set;}
    }

}