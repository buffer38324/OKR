using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.Models
{
    public class OkrItem
    {
        public int Level { get; set; }//任务的等级
        public DateTime Time {get;set;}
        public string Content { get; set; }//内容
        public int Id { get; set; }//任务Id
    }

}
