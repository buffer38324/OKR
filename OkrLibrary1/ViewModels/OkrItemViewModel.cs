﻿using OkrLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.ViewModels
{
    public class OkrItemViewModel
    {
        public List<OkrItem> AllOkrItems = new List<OkrItem>();
        public List<OkrItem> AllNeeds = new List<OkrItem>();
        public List<OkrItem> SevenDays = new List<OkrItem>();
        public ClientItem clientItem = new ClientItem("icy", 2, 40, 0);
        int flag = 0;
        //如果是叶子节点，调用此函数把Okr任务添加到List
        public void AddOkrItems(int level, DateTimeOffset date, string title,int need)
        {
            AllOkrItems.Add(new OkrItem(level, date, title, need));
        }
        public void AddNeedItems(string title, int need)
        {
            AllNeeds.Add(new OkrItem(0, DateTimeOffset.Now, title, need));
        }

        public void AddSevenDays(DateTimeOffset date)
        {
            //不设初始值默认都是0
            int need = FintNeed(date);
            int done=FindDone(date);
            OkrItem myitem = new OkrItem(0, date, "", need);
            myitem.Done = done;
            SevenDays.Add(myitem);
        }
        public void NewSevenDaysList()
        {
            AddSevenDays(DateTimeOffset.Now.AddDays(-6));
            AddSevenDays(DateTimeOffset.Now.AddDays(-5));
            AddSevenDays(DateTimeOffset.Now.AddDays(-4));
            AddSevenDays(DateTimeOffset.Now.AddDays(-3));
            AddSevenDays(DateTimeOffset.Now.AddDays(-2));
            AddSevenDays(DateTimeOffset.Now.AddDays(-1));
            AddSevenDays(DateTimeOffset.Now);
        }
        //近七天的任务里的做过次数加一
        public void SetDone(DateTimeOffset date)
        {
            foreach(OkrItem myitem in SevenDays)
            {
                if(myitem.Date.Date==date.Date)
                {
                    myitem.Done++;
                }
            }
        }
        //查看今天的任务是否做完
        public void SetFlag(string title)
        {
            DateTimeOffset date = DateTimeOffset.Now;
            foreach(OkrItem myitem in AllOkrItems)
            {
                if (myitem.Date.Date == date.Date && myitem.Title == title)
                {
                    myitem.Finish_flag = true;
                    flag++;
                }
            }
        }

        public int progress_grade()
        {
            clientItem.Level_grade = clientItem.Level_grade + 10 * flag;
            int grade = clientItem.Level_grade;
            flag = 0;
            return grade;
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

        //返回某一天需要完成的任务数字
        public int FintNeed(DateTimeOffset date)
        {
            int need = 0;
            foreach (OkrItem myitem in AllOkrItems)
            {
                if (date.Date == myitem.Date.Date)
                {
                    need++;
                }
            }
            return need;
        }
        //返回某一天做完的任务数
        public int FindDone(DateTimeOffset date)
        {
            int done = 0;
            foreach (OkrItem myitem in AllOkrItems)
            {
                if (date.Date == myitem.Date.Date)
                {
                    if (myitem.Finish_flag == true)
                        done++;
                }
            }
            return done;
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

        //打卡调用的函数，全部需要做的任务里做过次数加一
        public void TaskProcessGo(string title)
        {
            foreach (OkrItem myitem in AllNeeds)
            {
                if (title == myitem.Title)
                    myitem.Done++;
            }
        }

        //判断打过卡没有
        public bool JudgeFlag(string title)
        {
            bool flag=false;
            DateTimeOffset date = DateTimeOffset.Now;
            foreach (OkrItem myitem in AllOkrItems)
            {
                if (myitem.Date.Date == date.Date && myitem.Title == title)
                    flag = myitem.Finish_flag;
            }
            return flag;
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
