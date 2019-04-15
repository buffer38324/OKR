using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.Models
{
    public class ClientItem
    {
        public string name { set; get; }//用户名
        public int level { set; get; }//用户等级
        public int Level_grade { set; get; }//当前分数（进度条）
        public int Times { set; get; }//当前抽奖次数

        public ClientItem(string name)
        {
            //新建一个用户，除了姓名其他的均默认为0
            this.name = name;
            this.Times = 0;
            this.level = 0;
            this.Level_grade = 0;
        }

        public ClientItem(string name,int level,int level_grade,int Times)
        {
            //从Service中读取一个用户的构造函数
            this.name = name;
            this.Times = Times;
            this.level = level;
            Level_grade = Level_grade;
        }
    }

}
