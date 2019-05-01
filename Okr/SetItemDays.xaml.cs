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
using OkrLibrary1.Models;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Okr
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SetItemDays : Page
    {
        public SetItemDays()
        {
            this.InitializeComponent();
        }
        public static OkrItemViewModel VM = new OkrItemViewModel();
        public OkrItemViewModel ViewModel { get { return VM; } }
        string title = "";
        int level = 0;
        private void AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (MyDateName.Text == "")
                title = "Unknown";
            else title = MyDateName.Text;
            string nlevel = MyDateLevel.Text.ToString();
            level = int.Parse(nlevel);
            DateTimeOffset today = BeginDate.Date;
           //有问题，改完再放上来
        }
    }
}
