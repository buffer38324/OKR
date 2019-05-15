using OkrLibrary1.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Okr
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OKRTaskPage : Page
    {
        public OKRTaskPage()
        {
            this.InitializeComponent();
        }

        private void BackToOKRPlanPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OKRPlanPage));
        }

        /// <summary>
        /// 添加新任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            //新建文本框和按钮
            StackPanel NewStackPanel = new StackPanel
            {
                Orientation =
                (Orientation)Enum.Parse(typeof(Orientation), "Horizontal")
            };
            TextBox MyTextBox = new TextBox
            {
                Name = "MyPlan",
                FontSize = 18,
                Header = "任务4",
                Style = (Style)Application.Current.Resources["MyTextBox"]
            };
            AppBarButton NewTask1Setting = new AppBarButton
            {
                Name = "AddTaskButton",
                Margin = new Thickness(15, 56, 0, 0),
                Icon = new SymbolIcon(Symbol.Edit)
            };
            NewTask1Setting.Click += NewTask1Setting_Click; ; 
            NewStackPanel.Children.Add(MyTextBox);
            NewStackPanel.Children.Add(NewTask1Setting);
            OKRTask.Children.Add(NewStackPanel);
        }

        private void NewTask1Setting_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
        }

        private void Task1Setting_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
            var okrItem = new List<OkrItem>();
            okrItem.Add(new OkrItem(2, DateTimeOffset.Now, MyFirstTask.Text, 3));
        }

        private void Task2Setting_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
            var okrItem = new List<OkrItem>();
            okrItem.Add(new OkrItem(2, DateTimeOffset.Now, MySecondTask.Text, 3));
        }

        private void Task3Setting_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
            var okrItem = new List<OkrItem>();
            okrItem.Add(new OkrItem(2, DateTimeOffset.Now, MyThirdTask.Text, 3));
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string value1 = (string)e.Parameter;
            OKRTaskPageTitle.Text = value1;
        }
    }
}
