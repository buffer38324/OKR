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
        public static string now_title = "";

        public class Task
        {
            public string name;
            public bool is_save; 
            public Task(string Name,bool Is_save)
            {
                name = Name;
                is_save = Is_save;
            }
        }
        List<Task> all_tasks = new List<Task>();

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
                //这边一直是任务4
                Header = "任务4",
                Style = (Style)Application.Current.Resources["MyTextBox"]
            };
            AppBarButton NewTask1Setting = new AppBarButton
            {
                Name = "AddTaskButton",
                Margin = new Thickness(5, 56, 0, 0),
                Icon = new SymbolIcon(Symbol.Edit),
                MaxHeight=40
            };
            NewTask1Setting.Click += NewTask1Setting_Click; ; 
            NewStackPanel.Children.Add(MyTextBox);
            NewStackPanel.Children.Add(NewTask1Setting);
            OKRTask.Children.Add(NewStackPanel);
        }

        //这边保存的时候事件名称会出现问题
        private void NewTask1Setting_Click(object sender, RoutedEventArgs e)
        {
            now_title = "";
            Frame.Navigate(typeof(SetItemDays));
            all_tasks.Add(new Task(now_title, true));
        }

        private void Task1Setting_Click(object sender, RoutedEventArgs e)
        {
            now_title = "";
            Frame.Navigate(typeof(SetItemDays));
            now_title = MyFirstTask.Text;
            all_tasks.Add(new Task(now_title, true));
        }

        private void Task2Setting_Click(object sender, RoutedEventArgs e)
        {
            now_title = "";
            Frame.Navigate(typeof(SetItemDays));
        }

        private void Task3Setting_Click(object sender, RoutedEventArgs e)
        {
            now_title = "";
            Frame.Navigate(typeof(SetItemDays));
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            if(!all_tasks.Exists((Task a)=>a.name==MyFirstTask.Text))
                Frame.Navigate(typeof(SetItemDays));
            if (!all_tasks.Exists((Task a) => a.name == MySecondTask.Text))
                Frame.Navigate(typeof(SetItemDays));
            if (!all_tasks.Exists((Task a) => a.name == MyThirdTask.Text))
                Frame.Navigate(typeof(SetItemDays));
            //Frame.Navigate(typeof(SetItemDays));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string value1 = (string)e.Parameter;
            OKRTaskPageTitle.Text = value1;
        }
    }
}
