using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.Models
{
    public class OkrItem
    {
        public int Level { get; set; }//任务的等级
        public DateTimeOffset Time {get;set;}
        public string Content { get; set; }//内容
        public int Id { get; set; }//任务Id
        public Boolean Finish_flag { get; set; }//任务是否完成标志，true为完成任务

        public OkrItem(int level, DateTimeOffset time, string content, int id)
        {
            Level = level;
            Time = time;
            Content = content;
            Id = id;
            Finish_flag = false;//任务初始化均为未完成
        }
    }

}
