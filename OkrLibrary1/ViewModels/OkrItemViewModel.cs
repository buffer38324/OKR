using OkrLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.ViewModels
{
    class OkrItemViewModel
    {
        public List<List<OkrItem>> AllOkrItems = new List<List<OkrItem>>();
        public void AddOkrItems(int level, DateTimeOffset time, string content, int id)
        {
            AllOkrItems[level].Add(new OkrItem(level, time, content, id));
            //这里需要调用service保存
        }
        //这里需要从UI得到第几级别
        public void CoutItem(int level)
        {
            //这里需要调用service读取
            foreach (OkrItem MyItem in AllOkrItems[level])
            {
                //这里输出到Main Page，然鹅在另一个项目，还不会
                //可能需要数据绑定
            }
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
