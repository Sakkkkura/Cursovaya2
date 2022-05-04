using Course.MVVM.Models;
using System;
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

namespace Course.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для EditWeekWindow.xaml
    /// </summary>
    public partial class EditWeekWindow : Window
    {
        public EditWeekWindow(Week week)
        {
            InitializeComponent();
        }
    }
}
