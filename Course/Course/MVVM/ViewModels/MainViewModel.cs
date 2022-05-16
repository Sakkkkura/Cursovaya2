using Course.Commands;
using Course.MVVM.Models;
using Course.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Course.MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {

        public RelayCommand SortGroupList
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    UpdateListView();
                }
                );
            }
        }
        private void UpdateListView()
        {
            MainWindow.MainWindowListView.ItemsSource = null;
            MainWindow.MainWindowListView.Items.Clear();
            MainWindow.MainWindowListView.ItemsSource = DataWorker.GetAllSchedulesByGroupId(SelectedGroup.Id);
            MainWindow.MainWindowListView.Items.Refresh();
        }
    }
}
