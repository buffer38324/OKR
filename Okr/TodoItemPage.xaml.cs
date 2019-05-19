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
            for (int i = 0; i < ItemNum; i++)
            {
                ToggleButton ItemButton = new ToggleButton();
                ItemButton.Name = "Item0";
                ItemButton.Content = ItemToday[i];
                ItemButton.Margin = new Thickness(0, 15, 0, 0);
                ItemButton.IsThreeState = false;
                ItemButton.Click += ItemButton_Click ;
                ItemList.Children.Add(ItemButton);
            }
        }

        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton ItemButton = (ToggleButton)sender;
            ItemButton.Content = ItemButton.Content+ " 已打卡";
            ItemButton.IsEnabled = false;
        }

        private void MyToggleButton_Click(object sender, RoutedEventArgs e)
        {
            MyToggleButton.Content = "已打卡";
            MyToggleButton.IsEnabled = false;
        }
    }
}
