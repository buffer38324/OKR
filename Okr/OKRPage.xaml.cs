﻿using OkrLibrary1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Okr
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OKRPage : Page
    {
        public OKRPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// 计划首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OKRPlanPage), MyLongPlan.Text);
            var okrItem = new List<OkrItem>();
            okrItem.Add(new OkrItem ( 0, DateTimeOffset.Now, MyLongPlan.Text, 3));
            
        }
    }
}
