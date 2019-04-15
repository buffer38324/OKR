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

        public OkrItem(int level, DateTimeOffset date, string title, int id)
        {
            Level = level;
            Title = title;
            Date = date;
            Id = id;
        }
    }

}
