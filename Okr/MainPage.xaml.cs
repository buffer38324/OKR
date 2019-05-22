using System;
using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using OkrLibrary1.ViewModels;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;
using Windows.System;
using Windows.Foundation.Collections;
using Windows.Storage;

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
            //VM.NewSevenDaysList();
        }


        //在这放一个New的ModelView
        public static OkrItemViewModel VM = new OkrItemViewModel();
        public static string OKRPlamPageTitle;
        public static string OKRTaskPageTitle;
        public static string MyFirstTask = "";
        public static string MySecondTask = "";
        public static string MyThirdTask = "";
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

        private async void Change_Click(object sender, RoutedEventArgs e)
        {
            // 创建和自定义 FileOpenPicker
            var picker = new Windows.Storage.Pickers.FileOpenPicker();

            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail; 
            //可通过使用图片缩略图创建丰富的视觉显示，以显示文件选取器中的文件

            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            //对文件夹进行筛选

            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".gif");

            //选取单个文件
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();

            //文件处理
            if (file != null)
            {
                //共享文件
                var inputFile = SharedStorageAccessManager.AddFile(file);

                //在应用文件夹中建立文件用来存储裁剪后的图像
                var destination = await ApplicationData.Current.LocalFolder.CreateFileAsync("Cropped.jpg", CreationCollisionOption.ReplaceExisting);
                
                var destinationFile = SharedStorageAccessManager.AddFile(destination);

                //启动器选项对象的新实例
                var options = new LauncherOptions();

                //应用于启动文件或URI的目标包的包名称
                options.TargetApplicationPackageFamilyName = "Microsoft.Windows.Photos_8wekyb3d8bbwe";

                //待会要传入的参数
                var parameters = new ValueSet();

                //输入文件
                parameters.Add("InputToken", inputFile);
                //输出文件
                parameters.Add("DestinationToken", destinationFile);
                //它允许我们显示一个按钮，以允许用户采取当场图象(但是好像并没有什么卵用)
                parameters.Add("ShowCamera", false);
                //截图区域显示为圆（最后截出来还是方形）

                parameters.Add("EllipticalCrop", true);                 
                parameters.Add("CropWidthPixals", 300);
                parameters.Add("CropHeightPixals", 300);

                //调用系统自带截图并返回结果
                var result = await Launcher.LaunchUriForResultsAsync(new Uri("microsoft.windows.photos.crop:"), options, parameters);

                //按理说下面这个判断应该没问题呀，但是如果裁剪界面点了取消的话后面会出现异常，所以后面我加了try catch
                if (result.Status == LaunchUriStatus.Success && result.Result != null)
                {
                    //对裁剪后图像的下一步处理
                    try
                    {
                        // 载入已保存的裁剪后图片
                        var stream = await destination.OpenReadAsync();
                        var bitmap = new BitmapImage();
                        await bitmap.SetSourceAsync(stream);

                        // 显示
                        MyPicture.ProfilePicture = bitmap;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + ex.StackTrace);
                    }
                }
            }
        }
    }
}
    
