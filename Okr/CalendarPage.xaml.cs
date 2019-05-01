using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OkrLibrary1.ViewModels;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Okr
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            this.InitializeComponent();
        }
        
        private void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            //加上只能选择今天以后的日期
            if (ListMyDates == null)
                return;
            ListMyDates.Text = MainPage.VM.FindItem(sender.SelectedDates.First());
        }

        private void MyDateLook_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            //int[] myLevel = MainPage.VM.FindLevel(MyDateLook.SelectedDates.First());
            //foreach(var date in VM.AllDateTime)
            //{
            int[] myLevel = MainPage.VM.FindLevel(args.Item.Date);
            List<Color> densityColors = new List<Color>();
            foreach (var level in myLevel)
            {
                if (level == 0)
                    break;
                else if (level == 1)
                    densityColors.Add(Colors.Red);
                else if (level == 2)
                    densityColors.Add(Colors.Orange);
                else if (level == 3)
                    densityColors.Add(Colors.Yellow);
                else if (level >= 4)
                    densityColors.Add(Colors.Blue);
                else { }
            }
            args.Item.SetDensityColors(densityColors);
            //}
        }
    }
}
