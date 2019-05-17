using OkrLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.ViewModels
{
    public class OkrItemViewModel
    {
        public List<OkrItem> AllOkrItems = new List<OkrItem>();
        
        //如果是叶子节点，调用此函数把Okr任务添加到List
        public void AddOkrItems(int level, DateTimeOffset date, string title,int need)
        {
            AllOkrItems.Add(new OkrItem(level, date, title, need));
        }

        //这两个函数需要改
        //返回某天的所有任务
        //返回格式还要改
        public string FindItem(DateTimeOffset date)
        {
            string MyTitle = "";
            foreach (OkrItem myitem in AllOkrItems)
            {
                if (date.Date == myitem.Date.Date)
                {
                    MyTitle += myitem.Title;
                    MyTitle += System.Environment.NewLine;
                }
            }
            return MyTitle;
        }
        /// <summary>
        /// 返回今天的待办任务
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string[] GetItemToday(DateTimeOffset date)
        {
            string[] ItemToday=new string [10];
            int i = 0;
            foreach(OkrItem myitem in AllOkrItems)
            {
                if(date.Date == myitem.Date.Date)
                {
                    ItemToday[i] = myitem.Title;
                    i++;
                }
            }
            return ItemToday;
        }
        /// <summary>
        /// 获得今日待办任务数
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetItemNum(DateTimeOffset date)
        {
            int ItemNum=0;
            foreach(OkrItem myitem in AllOkrItems)
            {
                if(date.Date==myitem.Date.Date)
                {
                    ItemNum++;
                }
            }
            return ItemNum;
        }
        //返回某一天所有任务的level
        public int[] FindLevel(DateTimeOffset date)
        {
            int[] MyLevel = new int[10];
            int i = 0;
            foreach (OkrItem myitem in AllOkrItems)
            {
                if (date.Date == myitem.Date.Date)
                {
                    MyLevel[i++] = myitem.Level;
                }
            }
            return MyLevel;
        }

        public int Monitor(ClientItem clientItem)
        {
            //用来监测是否有任务完成
            //实际上返回值应该为int型，但是不知道为什么返回值为int就警告
            //当有任务完成时判断任务等级，加相应的分数

            return clientItem.Level_grade;
        }
    }
}
