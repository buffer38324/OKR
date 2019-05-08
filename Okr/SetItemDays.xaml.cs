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
        string title = "";
        int level = 0;
        private void AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (MyDateName.Text == "")
                title = "Unknown";
            else title = MyDateName.Text;
            string nlevel = MyDateLevel.Text.ToString();
            level = int.Parse(nlevel);
            int need = 0;
            if (Option1CheckBox.IsChecked == true)
            {
                DateTimeOffset today1 = BeginDate.Date;
                while (today1 <= EndDate.Date)
                {
                    if (today1.DayOfWeek == DayOfWeek.Monday)
                    {
                        need++;
                        today1 = today1.AddDays(7);
                    }
                    else today1 = today1.AddDays(1);
                }
            }
            if (Option2CheckBox.IsChecked == true)
            {
                DateTimeOffset today1 = BeginDate.Date;
                while (today1 <= EndDate.Date)
                {
                    if (today1.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        need++;
                        today1 = today1.AddDays(7);
                    }
                    else today1 = today1.AddDays(1);
                }
            }
            if (Option3CheckBox.IsChecked == true)
            {
                DateTimeOffset today1 = BeginDate.Date;
                while (today1 <= EndDate.Date)
                {
                    if (today1.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        need++;
                        today1 = today1.AddDays(7);
                    }
                    else today1 = today1.AddDays(1);
                }
            }
            if (Option4CheckBox.IsChecked == true)
            {
                DateTimeOffset today1 = BeginDate.Date;
                while (today1 <= EndDate.Date)
                {
                    if (today1.DayOfWeek == DayOfWeek.Thursday)
                    {
                        need++;
                        today1 = today1.AddDays(7);
                    }
                    else today1 = today1.AddDays(1);
                }
            }
            if (Option5CheckBox.IsChecked == true)
            {
                DateTimeOffset today1 = BeginDate.Date;
                while (today1 <= EndDate.Date)
                {
                    if (today1.DayOfWeek == DayOfWeek.Friday)
                    {
                        need++;
                        today1 = today1.AddDays(7);
                    }
                    else today1 = today1.AddDays(1);
                }
            }
            if (Option6CheckBox.IsChecked == true)
            {
                DateTimeOffset today1 = BeginDate.Date;
                while (today1 <= EndDate.Date)
                {
                    if (today1.DayOfWeek == DayOfWeek.Saturday)
                    {
                        need++;
                        today1 = today1.AddDays(7);
                    }
                    else today1 = today1.AddDays(1);
                }
            }
            if (Option7CheckBox.IsChecked == true)
            {
                DateTimeOffset today1 = BeginDate.Date;
                while (today1 <= EndDate.Date)
                {
                    if (today1.DayOfWeek == DayOfWeek.Sunday)
                    {
                        need++;
                        today1 = today1.AddDays(7);
                    }
                    else today1 = today1.AddDays(1);
                }
            }
            DateTimeOffset today = BeginDate.Date;
            while (today <= EndDate.Date)
            {
                if (Option1CheckBox.IsChecked == true && today.DayOfWeek == DayOfWeek.Monday)
                    MainPage.VM.AddOkrItems(level, today, title, need);
                else if (Option2CheckBox.IsChecked == true && today.DayOfWeek == DayOfWeek.Tuesday)
                    MainPage.VM.AddOkrItems(level, today, title, need);
                else if (Option3CheckBox.IsChecked == true && today.DayOfWeek == DayOfWeek.Wednesday)
                    MainPage.VM.AddOkrItems(level, today, title, need);
                else if (Option4CheckBox.IsChecked == true && today.DayOfWeek == DayOfWeek.Thursday)
                    MainPage.VM.AddOkrItems(level, today, title, need);
                else if (Option5CheckBox.IsChecked == true && today.DayOfWeek == DayOfWeek.Friday)
                    MainPage.VM.AddOkrItems(level, today, title, need);
                else if (Option6CheckBox.IsChecked == true && today.DayOfWeek == DayOfWeek.Saturday)
                    MainPage.VM.AddOkrItems(level, today, title, need);
                else if (Option7CheckBox.IsChecked == true && today.DayOfWeek == DayOfWeek.Sunday)
                    MainPage.VM.AddOkrItems(level, today, title, need);
                today = today.AddDays(1);
            }
        }
        private void BeginDate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (BeginDate.Date < DateTimeOffset.Now)
            {
                FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);

                //添加锁定，不能让他成功
            }
        }

        private void EndDate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (EndDate.Date < BeginDate.Date || EndDate.Date == BeginDate.Date)
            {
                FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
                //添加锁定+1
                //等于有问题
            }
        }
        //全选的不确定状态还有问题
        private void OptionsAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = Option4CheckBox.IsChecked
                = Option5CheckBox.IsChecked = Option6CheckBox.IsChecked = Option7CheckBox.IsChecked = true;
        }

        private void OptionsAllCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = Option4CheckBox.IsChecked
                = Option5CheckBox.IsChecked = Option6CheckBox.IsChecked = Option7CheckBox.IsChecked = false;
        }

        private void OptionsAllCheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            if (Option1CheckBox.IsChecked == true &&
                Option2CheckBox.IsChecked == true &&
                Option3CheckBox.IsChecked == true &&
                Option4CheckBox.IsChecked == true &&
                Option5CheckBox.IsChecked == true &&
                Option6CheckBox.IsChecked == true &&
                Option7CheckBox.IsChecked == true)
            {
                OptionsAllCheckBox.IsChecked = false;
            }
        }

        private void SetCheckedState()
        {
            // Controls are null the first time this is called, so we just 
            // need to perform a null check on any one of the controls.
            if (Option1CheckBox != null)
            {
                if (Option1CheckBox.IsChecked == true &&
                    Option2CheckBox.IsChecked == true &&
                    Option3CheckBox.IsChecked == true &&
                    Option4CheckBox.IsChecked == true &&
                    Option5CheckBox.IsChecked == true &&
                    Option6CheckBox.IsChecked == true &&
                    Option7CheckBox.IsChecked == true)
                {
                    OptionsAllCheckBox.IsChecked = true;
                }
                else if (Option1CheckBox.IsChecked == false &&
                    Option2CheckBox.IsChecked == false &&
                    Option3CheckBox.IsChecked == false &&
                    Option4CheckBox.IsChecked == false &&
                    Option5CheckBox.IsChecked == false &&
                    Option6CheckBox.IsChecked == false &&
                    Option7CheckBox.IsChecked == false)
                {
                    OptionsAllCheckBox.IsChecked = false;
                }
                else
                {
                    // Set third state (indeterminate) by setting IsChecked to null.
                    OptionsAllCheckBox.IsChecked = null;
                }
            }
        }

        private void Option1CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option2CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option3CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option4CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option5CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option6CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option7CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option1CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Option2CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
