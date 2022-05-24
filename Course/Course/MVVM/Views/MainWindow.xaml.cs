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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Course.MVVM.Views
{
    public partial class MainWindow : Window
    {
        public static ListView MainWindowListView;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowListView = MainWindowLV;
            MainWindowComboBox = MainWindowCB;
        }

        public static ComboBox MainWindowComboBox;

    }
}
