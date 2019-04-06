using OkrLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.ViewModels
{
    class OkrItemViewModel
    {
        public List<List<OkrItem>> AllOkrItems = new List<List<OkrItem>>();
        public void AddOkrItems(int level, DateTime time, string content, int id)
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
    }
}
