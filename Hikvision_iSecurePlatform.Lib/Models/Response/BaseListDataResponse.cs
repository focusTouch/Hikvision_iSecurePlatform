using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class BaseListDataResponse<T> 
    {
        public string code{get;set;}
       public string msg{get;set;}
        public listData<T> data{get;set;}

    }

    public class listData<T>
    {
        public int total{get;set;}
        public int pageNo{get;set;}
        public int pageSize{get;set;}

        public List<T> list{get;set;}
    }

}