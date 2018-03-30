﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListProject
{
    /// <summary>
    /// Interaction logic for Win2AddItem.xaml
    /// </summary>
    public partial class Win2AddItem : Window
    {
        public Win2AddItem()
        {
            InitializeComponent();
        }

        private void uxButton_ConfirmAddItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void uxButton_ConfirmAddItemCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
