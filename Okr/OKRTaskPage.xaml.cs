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

        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Task1Setting_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
        }

        private void Task2Setting_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
        }

        private void Task3Setting_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
        }

        private void AddNewTask_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetItemDays));
        }
    }
}
