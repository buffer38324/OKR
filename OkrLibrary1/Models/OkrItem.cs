using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.Models
{
    public class OkrItem
    {
        public int Level { get; set; }//任务的等级
        public DateTimeOffset Date {get;set;}
        public string Title { get; set; }//内容
        public int Id { get; set; }//任务Id
        public Boolean Finish_flag { get; set; }//任务是否完成标志，true为完成任务

        public OkrItem(int level, DateTimeOffset date, string title, int id)
        {
            Level = level;
            Title = title;
            Date = date;
            Id = id;
            Finish_flag = false;//任务初始化均为未完成
        }
    }

}
