using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class BaseBatchAddResponse<T> :BaseResponse<T>
    {
        public new BatchAddListData<T> data{get;set;}

    }

    public class BatchAddListData<T>
    {
        public List<T> successes{get;set;}
        public List<T> failures{get;set;}
    }

}