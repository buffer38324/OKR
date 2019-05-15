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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Okr
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OKRPlanPage : Page
    {
        public OKRPlanPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 新建文本框和按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewPlan_Click(object sender, RoutedEventArgs e)
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
                Header = "计划4",
                Style = (Style)Application.Current.Resources["MyTextBox"]
            };
            AppBarButton AddTaskButton = new AppBarButton
            {
                Name = "AddTaskButton",
                Margin = new Thickness(5, 50, 0, 0),
                Icon = new SymbolIcon(Symbol.Add),
                MaxHeight=40
            };
            AddTaskButton.Click += AddTaskButton_Click;
            NewStackPanel.Children.Add(MyTextBox);
            NewStackPanel.Children.Add(AddTaskButton);
            OKRPlan.Children.Add(NewStackPanel);
        }

        /// <summary>
        /// 新建计划的添加任务按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OKRTaskPage));
        }

        private void AddTaskButton1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OKRTaskPage));
        }

        private void AddTaskButton2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OKRTaskPage));
        }

        private void AddTaskButton3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OKRTaskPage));
        }

        private void BackToOKRPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OKRPage));
        }

        private void SavePlan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OKRPlanPanel_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
