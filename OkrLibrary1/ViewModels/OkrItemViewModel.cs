using OkrLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkrLibrary1.ViewModels
{
    class OkrItemViewModel
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
    }
}
