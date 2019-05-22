using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class TodoItemPage : Page
    {
        public TodoItemPage()
        {
            this.InitializeComponent();
        }

        
        private void TodoItemGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DateTimeOffset today = DateTimeOffset.Now;
            int ItemNum = MainPage.VM.FintNeed(today.LocalDateTime);
            string[] ItemToday = MainPage.VM.GetItemToday(today.LocalDateTime);
            int[] myLevel = MainPage.VM.FindLevel(today.LocalDateTime);
            for (int i = 0; i < ItemNum; i++)
            {
                ToggleButton ItemButton = new ToggleButton();
                ItemButton.Name = "Item0";
                ItemButton.Content = ItemToday[i];
                ItemButton.Margin = new Thickness(0, 15, 0, 0);
                ItemButton.Width = 300;
                ItemButton.IsThreeState = false;
                //设置打卡按钮背景颜色
                int level = myLevel[i];
                if(level==1)
                    ItemButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255,134,227,206)); 
                else if(level==2)
                    ItemButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 208, 230, 165)); 
                else if(level==3)
                    ItemButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 250, 137, 120));
                else if(level>=4)
                    ItemButton.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 221, 148)); 
                ItemButton.Click += ItemButton_Click ;
                ItemList.Children.Add(ItemButton);
            }
        }

        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton ItemButton = (ToggleButton)sender;
            bool flag = MainPage.VM.JudgeFlag(ItemButton.Content.ToString());
            if(!flag)  //是一个还未打过卡的任务
            {
                MainPage.VM.TaskProcessGo(ItemButton.Content.ToString()); //全部需要做的次数加一
                MainPage.VM.SetDone(DateTimeOffset.Now);  //近七天任务里做过次数加一
                MainPage.VM.SetFlag(ItemButton.Content.ToString());  //设置已经打过卡了
            }
            else
            {
                Flyout fly = new Flyout();
                TextBlock flytext = new TextBlock();
                flytext.Text = "该任务已经打过卡了";
                fly.Content = flytext;
                fly.ShowAt(ItemButton);
            }
            ItemButton.Content = ItemButton.Content+ " 已打卡";
            ItemButton.IsEnabled = false;
        }
    }
}
