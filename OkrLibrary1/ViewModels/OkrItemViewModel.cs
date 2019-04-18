using OkrLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.ViewModels
{
    public class OkrItemViewModel
    {
        public List<OkrItem> AllOkrItems = new List<OkrItem>();
        public void AddOkrItems(int level, DateTimeOffset date, string title, int id)
        {
            AllOkrItems.Add(new OkrItem(level, date, title, id));
        }
        public string FindItem(DateTimeOffset date)
        {
            string MyTitle = "";
            foreach (OkrItem myitem in AllOkrItems)
            {
                if (date == myitem.Date)
                {
                    MyTitle += myitem.Title;
                }
            }
            return MyTitle;
        }
        public int[] FindLevel(DateTimeOffset date)
        {
            int[] MyLevel = new int[10];
            int i = 0;
            foreach (OkrItem myitem in AllOkrItems)
            {
                if (date == myitem.Date)
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
