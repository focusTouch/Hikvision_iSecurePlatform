using System;
using System.Collections.Generic;
using System.Text;

namespace Hikvision_iSecurePlatform.Lib.Models.Response
{
    public class TaskProgressResponse
    {
        public String tagId { get; set; }
        public String taskId { get; set; }
        public String startTime { get; set; }
        public String endTime { get; set; }
        public int percent { get; set; }
        public int leftTime { get; set; }
        public bool isFinished { get; set; }
        public int totalNum { get; set; }
        public int successedNum { get; set; }
        public int failedNum { get; set; }
        public int repeatedNum { get; set; }
    }
}
