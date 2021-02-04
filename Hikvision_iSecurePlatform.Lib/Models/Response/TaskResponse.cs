using System;
using System.Collections.Generic;
using System.Text;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
   public class TaskResponse
    {
        public string code { get; set; }
        public string msg { get; set; }
        public TaskInfo data { get; set; }

        public class TaskInfo
        {
            public string taskId { get; set; }
        }
    }
}
