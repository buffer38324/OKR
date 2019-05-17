using System;
using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using OkrLibrary1.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Okr
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //数据共享
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
        }

        //在这放一个New的ModelView
        public static OkrItemViewModel VM = new OkrItemViewModel();
        public static string OKRPlamPageTitle;
        public static string OKRTaskPageTitle;
        public static string MyFirstTask = "";
        public static string MySecondTask = "" ;
        public static string MyThirdTask  = "";
        public OkrItemViewModel ViewModel { get { return VM; } }

        /// <summary>
        /// 设置常量：把tag的字符串转化成Page类型
        /// </summary>


        private void MyASB_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //sender.ItemsSource = ReminderStrList.Where(i => i.Contains(sender.Text));
            }
        }

        private void MyASB_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string txt = args.QueryText;  //输入的文本
            if (args.ChosenSuggestion != null)
            {
                //从提示框中选择某一项时触发
            }
            else
            {
                //用户在输入时敲回车或者点击右边按钮确认输入时触发
            }
        }

        private void MyASB_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
        }

        

       

        /// <summary>
        /// 设置共享内容相关信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            request.Data.SetText("Hello world!");    //共享文本或改成其他信息
            request.Data.Properties.Title = "分享任务清单";
            request.Data.Properties.Description = "分享任务清单，让小伙伴来监督你吧！ ";
        }

        private void MyNavigation_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MyNavigation_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {

        }
        /// <summary>
        /// 页面加载失败时提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("加载" + e.SourcePageType.FullName+"页面失败");
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CenterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 启动共享UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        private void MyNavigation_SelectionChanged(NavigationView sender,NavigationViewSelectionChangedEventArgs args)
        {
                NavigationViewItem item =
                    args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "OKRPage":
                        ContentFrame.Navigate(typeof(OKRPage));
                        break;

                    case "TodoItemPage":
                        ContentFrame.Navigate(typeof(TodoItemPage));
                        break;

                    case "ProgressPage":
                        ContentFrame.Navigate(typeof(ProgressPage));
                        break;

                    case "CalendarPage":
                        ContentFrame.Navigate(typeof(CalendarPage));
                        break;
                }
        }
    }
}
    
