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

        
        //这边保存的时候事件名称会出现问题
        private void NewTask1Setting_Click(object sender, RoutedEventArgs e)
        {
            now_title = "";
            Frame.Navigate(typeof(SetItemDays));
            all_tasks.Add(new Task(now_title, true));
        }

        private void Task1Setting_Click(object sender, RoutedEventArgs e)
        {
            MainPage.MyFirstTask = MyFirstTask.Text;
            now_title = "";
            Frame.Navigate(typeof(SetItemDays),MyFirstTask.Text);
            now_title = MyFirstTask.Text;
            all_tasks.Add(new Task(now_title, true));
        }

        private void Task2Setting_Click(object sender, RoutedEventArgs e)
        {
            MainPage.MySecondTask = MySecondTask.Text;
            //now_title = "";
            //now_title = MySecondTask.Text;
            Frame.Navigate(typeof(SetItemDays),MySecondTask.Text);
        }

        private void Task3Setting_Click(object sender, RoutedEventArgs e)
        {
            MainPage.MyThirdTask = MyThirdTask.Text;
            //now_title = "";
            //now_title = MyThirdTask.Text;
            Frame.Navigate(typeof(SetItemDays),MyThirdTask.Text);
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            /*if(!all_tasks.Exists((Task a)=>a.name==MyFirstTask.Text))
                Frame.Navigate(typeof(SetItemDays));
            if (!all_tasks.Exists((Task a) => a.name == MySecondTask.Text))
                Frame.Navigate(typeof(SetItemDays));
            if (!all_tasks.Exists((Task a) => a.name == MyThirdTask.Text))
                Frame.Navigate(typeof(SetItemDays));*/
            //Frame.Navigate(typeof(SetItemDays));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            if(e.Parameter != null)
            {
                string value1 = (string)e.Parameter;
                OKRTaskPageTitle.Text = value1;
            }
            else
            {
                OKRTaskPageTitle.Text = MainPage.OKRTaskPageTitle;
                MyFirstTask.Text = MainPage.MyFirstTask;
                MySecondTask.Text = MainPage.MySecondTask;
                MyThirdTask.Text = MainPage.MyThirdTask;
            }
        }
    }
}
