﻿using Course.Commands;
using Course.MVVM.Models;
using Course.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Course.MVVM.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        //все группы
        private List<Group> allGroups = DataWorker.GetAllGroups();
        public List<Group> AllGroups
        {
            get { return allGroups; }
            set
            {
                allGroups = value;
                NotifyPropertyChanged("AllGroups");
            }
        }

        //все дни
        private List<Order> allOrders = DataWorker.GetAllOrders();
        public List<Order> AllOrders
        {
            get { return allOrders; }
            private set
            {
                allOrders = value;
                NotifyPropertyChanged("AllOrders");
            }
        }

        //все расписание
        private List<Schedule> allSchedules = DataWorker.GetAllSchedules();
        public List<Schedule> AllSchedules
        {
            get { return allSchedules; }
            private set
            {
                allSchedules = value;
                NotifyPropertyChanged("AllSchedules");
            }
        }

        //все предметы
        private List<Subject> allSubjects = DataWorker.GetAllSubjects();
        public List<Subject> AllSubjects
        {
            get { return allSubjects; }
            private set
            {
                allSubjects = value;
                NotifyPropertyChanged("AllSubjects");
            }
        }

        //все преподаватели
        private List<Teacher> allTeachers = DataWorker.GetAllTeachers();
        public List<Teacher> AllTeachers
        {
            get { return allTeachers; }
            private set
            {
                allTeachers = value;
                NotifyPropertyChanged("AllTeachers");
            }
        }

        //все недели
        private List<Week> allWeeks = DataWorker.GetAllWeeks();
        public List<Week> AllWeeks
        {
            get { return allWeeks; }
            private set
            {
                allWeeks = value;
                NotifyPropertyChanged("AllWeeks");
            }
        }

        //свойства для группы
        public static int GroupId { get; set; }
        public static string GroupName { get; set; } = null!;
        //свойства для дня
        public static int OrderId { get; set; }
        public static int OrderQueue { get; set; }
        public static Subject OrderSubject { get; set; } = null!;
        //свойства для расписания
        public static int ScheduleId { get; set; }
        public static Group ScheduleGroup { get; set; } = null!;
        public static Week ScheduleWeek { get; set; } = null!;
        //свойства для предмета
        public static int SubjectId { get; set; }
        public static string SubjectName { get; set; } = null!;
        public static Teacher SubjectTeacher { get; set; } = null!;
        //свойства для преподавателя
        public static int TeacherId { get; set; }
        public static string TeacherFullName { get; set; } = null!;
        //свойства для недели
        public static int WeekId { get; set; }
        public static string WeekDayOfWeek { get; set; } = null!;
        public static Order WeekOrder { get; set; } = null!;
        //свойства для выбора
        public TabItem SelectedTabItem{ get; set; } = null!;
        public static Group SelectedGroup { get; set; } = null!;
        public static Order SelectedOrder { get; set; } = null!;
        public static Schedule SelectedSchedule { get; set; } = null!;
        public static Subject SelectedSubject { get; set; } = null!;
        public static Week SelectedWeek { get; set; } = null!;
        public static Teacher SelectedTeacher { get; set; }=null!;

        #region COMMANDS TO ADD
        private RelayCommand addNewGroup;
        public RelayCommand AddNewGroup
        {
            get
            {
                return addNewGroup ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (GroupName == null || GroupName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateGroup(GroupName);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewOrder;
        public RelayCommand AddNewOrder
        {
            get
            {
                return addNewOrder ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (OrderQueue == 0)
                    {
                        SetRedBlockControll(wnd, "QueueBlock");
                    }
                    if (OrderSubject == null)
                    {
                        SetRedBlockControll(wnd, "SubjectBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateOrder(OrderQueue, OrderSubject);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewSchedule;
        public RelayCommand AddNewSchedule
        {
            get
            {
                return addNewSchedule ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (ScheduleGroup == null)
                    {
                        SetRedBlockControll(wnd, "GroupBlock");
                    }
                    if (ScheduleWeek == null)
                    {
                        SetRedBlockControll(wnd, "WeekBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateSchedule(ScheduleGroup, ScheduleWeek);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewSubject;
        public RelayCommand AddNewSubject
        {
            get
            {
                return addNewSubject ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (SubjectName == null || SubjectName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    if (SubjectTeacher == null)
                    {
                        SetRedBlockControll(wnd, "TeacherBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateSubject(SubjectName, SubjectTeacher);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewTeacher;
        public RelayCommand AddNewTeacher
        {
            get
            {
                return addNewTeacher ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (TeacherFullName == null || TeacherFullName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "FullNameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateTeacher(TeacherFullName);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewWeek;
        public RelayCommand AddNewWeek
        {
            get
            {
                return addNewWeek ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (WeekDayOfWeek == null || WeekDayOfWeek.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "DayOfWeekBlock");
                    }
                    if (WeekOrder == null)
                    {
                        SetRedBlockControll(wnd, "OrderBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateWeek(WeekDayOfWeek, WeekOrder);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        #endregion

        #region COMMANDS TO DELETE
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если группа
                    if (SelectedTabItem.Name == "GroupsTab" && SelectedGroup != null)
                    {
                        resultStr = DataWorker.DeleteGroup(SelectedGroup);
                        UpdateAllDataView();
                    }
                    //если день
                    if (SelectedTabItem.Name == "OrdersTab" && SelectedOrder != null)
                    {
                        resultStr = DataWorker.DeleteOrder(SelectedOrder);
                        UpdateAllDataView();
                    }
                    //если расписание
                    if (SelectedTabItem.Name == "SchedulesTab" && SelectedSchedule != null)
                    {
                        resultStr = DataWorker.DeleteSchedule(SelectedSchedule);
                        UpdateAllDataView();
                    }
                    //если предмет
                    if (SelectedTabItem.Name == "SubjectsTab" && SelectedSubject != null)
                    {
                        resultStr = DataWorker.DeleteSubject(SelectedSubject);
                        UpdateAllDataView();
                    }
                    //если учитель
                    if (SelectedTabItem.Name == "TeachersTab" && SelectedTeacher != null)
                    {
                        resultStr = DataWorker.DeleteTeacher(SelectedTeacher);
                        UpdateAllDataView();
                    }
                    //если неделя
                    if (SelectedTabItem.Name == "WeeksTab" && SelectedWeek != null)
                    {
                        resultStr = DataWorker.DeleteWeek(SelectedWeek);
                        UpdateAllDataView();
                    }
                    //обновление
                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }
        #endregion

        #region EDIT COMMANDS
        private RelayCommand editOrder;
        public RelayCommand EditOrder
        {
            get
            {
                return editOrder ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран день";
                    string noSubjectStr = "Не выбран новый предмет";
                    if (SelectedOrder != null)
                    {
                        if (OrderSubject != null)
                        {
                            resultStr = DataWorker.EditOrder(SelectedOrder, OrderQueue, OrderSubject);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        }
                        else ShowMessageToUser(noSubjectStr);
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }
        }
        private RelayCommand editSchedule;
        public RelayCommand EditSchedule
        {
            get
            {
                return editSchedule ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбрано расписание";
                    string noGroupStr = "Не выбрана новая группа";
                    string noWeekStr = "Не выбрана новая неделя";
                    if (SelectedSchedule != null)
                    {
                        if (ScheduleGroup != null && ScheduleWeek!= null)
                        {
                            resultStr = DataWorker.EditSchedule(SelectedSchedule, ScheduleGroup, ScheduleWeek);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        }
                        else ShowMessageToUser(noGroupStr);
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }

        }
        private RelayCommand editSubject;
        public RelayCommand EditSubject
        {
            get
            {
                return editSubject ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран предмет";
                    string noTeacherStr = "Не выбран новый преподаватель";
                    if (SelectedSubject != null)
                    {
                        if (SubjectTeacher != null)
                        {
                            resultStr = DataWorker.EditSubject(SelectedSubject, SubjectName, SelectedTeacher);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        }
                        else ShowMessageToUser(noTeacherStr);
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }

        }
        private RelayCommand editWeek;
        public RelayCommand EditWeek
        {
            get
            {
                return editWeek ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран предмет";
                    string noOrderStr = "Не выбран новый преподаватель";
                    if (SelectedWeek != null)
                    {
                        if (WeekOrder != null)
                        {
                            resultStr = DataWorker.EditWeek(SelectedWeek, WeekDayOfWeek, WeekOrder);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        }
                        else ShowMessageToUser(noOrderStr);
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }

        }
        #endregion

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openAddNewGroupWnd;
        public RelayCommand OpenAddNewGroupWnd
        {
            get
            {
                return openAddNewGroupWnd ?? new RelayCommand(obj =>
                {
                    OpenAddGroupWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewOrderWnd;
        public RelayCommand OpenAddNewOrderWnd
        {
            get
            {
                return openAddNewOrderWnd ?? new RelayCommand(obj =>
                {
                    OpenAddOrderWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewScheduleWnd;
        public RelayCommand OpenAddNewScheduleWnd
        {
            get
            {
                return openAddNewScheduleWnd ?? new RelayCommand(obj =>
                {
                    OpenAddScheduleWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewSubjectWnd;
        public RelayCommand OpenAddNewSubjectWnd
        {
            get
            {
                return openAddNewSubjectWnd ?? new RelayCommand(obj =>
                {
                    OpenAddSubjectWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewTeacherWnd;
        public RelayCommand OpenAddNewTeacherWnd
        {
            get
            {
                return openAddNewTeacherWnd ?? new RelayCommand(obj =>
                {
                    OpenAddTeacherWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewWeekWnd;
        public RelayCommand OpenAddNewWeekWnd
        {
            get
            {
                return openAddNewWeekWnd ?? new RelayCommand(obj =>
                {
                    OpenAddWeekWindowMethod();
                }
                );
            }
        }
        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если группа
                    if (SelectedTabItem.Name == "GroupTab" && SelectedGroup != null)
                    {
                        OpenEditGroupWindowMethod(SelectedGroup);
                    }
                    //если день
                    if (SelectedTabItem.Name == "OrderTab" && SelectedOrder != null)
                    {
                        OpenEditOrderWindowMethod(SelectedOrder);
                    }
                    //если расписание
                    if (SelectedTabItem.Name == "ScheduleTab" && SelectedSchedule != null)
                    {
                        OpenEditScheduleWindowMethod(SelectedSchedule);
                    }
                    //если предмет
                    if (SelectedTabItem.Name == "SubjectTab" && SelectedSubject != null)
                    {
                        OpenEditSubjectWindowMethod(SelectedSubject);
                    }
                    //если преподаватель
                    if (SelectedTabItem.Name == "TeacherTab" && SelectedTeacher != null)
                    {
                        OpenEditTeacherWindowMethod(SelectedTeacher);
                    }
                    //если неделя
                    if (SelectedTabItem.Name == "WeekTab" && SelectedWeek != null)
                    {
                        OpenEditWeekWindowMethod(SelectedWeek);
                    }
                }
                    );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOW
        //методы открытия окон
        private void OpenAddGroupWindowMethod()
        {
            
            AddNewGroupWindow newGroupWindow = new AddNewGroupWindow();
            SetCenterPositionAndOpen(newGroupWindow);
        }
        private void OpenAddOrderWindowMethod()
        {
            AddNewOrderWindow newOrderWindow = new AddNewOrderWindow();
            SetCenterPositionAndOpen(newOrderWindow);
        }
        private void OpenAddScheduleWindowMethod()
        {
            AddNewScheduleWindow newScheduleWindow = new AddNewScheduleWindow();
            SetCenterPositionAndOpen(newScheduleWindow);
        }
        private void OpenAddSubjectWindowMethod()
        {
            AddNewSubjectWindow newSubjectWindow = new AddNewSubjectWindow();
            SetCenterPositionAndOpen(newSubjectWindow);
        }
        private void OpenAddTeacherWindowMethod()
        {
            AddNewTeacherWindow newTeacherWindow = new AddNewTeacherWindow();
            SetCenterPositionAndOpen(newTeacherWindow);
        }
        private void OpenAddWeekWindowMethod()
        {
            AddNewWeekWindow newWeekWindow = new AddNewWeekWindow();
            SetCenterPositionAndOpen(newWeekWindow);
        }

        //окна редактирования
        private void OpenEditGroupWindowMethod(Group group)
        {
            EditGroupWindow editGroupWindow = new EditGroupWindow(group);
            SetCenterPositionAndOpen(editGroupWindow);
        }
        private void OpenEditOrderWindowMethod(Order order)
        {
            EditOrderWindow editOrderWindow = new EditOrderWindow(order);
            SetCenterPositionAndOpen(editOrderWindow);
        }
        private void OpenEditScheduleWindowMethod(Schedule schedule)
        {
            EditScheduleWindow editScheduleWindow = new EditScheduleWindow(schedule);
            SetCenterPositionAndOpen(editScheduleWindow);
        }
        private void OpenEditSubjectWindowMethod(Subject subject)
        {
            EditSubjectWindow editSubjectWindow = new EditSubjectWindow(subject);
            SetCenterPositionAndOpen(editSubjectWindow);
        }
        private void OpenEditTeacherWindowMethod(Teacher teacher)
        {
            EditTeacherWindow editTeacherWindow = new EditTeacherWindow(teacher);
            SetCenterPositionAndOpen(editTeacherWindow);
        }
        private void OpenEditWeekWindowMethod(Week week)
        {
            EditWeekWindow editWeekWindow = new EditWeekWindow(week);
            SetCenterPositionAndOpen(editWeekWindow);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        #region UPDATE VIEWS
        private void SetNullValuesToProperties()
        {
            //для группы
            GroupName = null;
            //для дня
            OrderQueue = 0;
            OrderSubject = null;
            //для расписания
            ScheduleGroup = null;
            ScheduleWeek = null;
            //для предмета
            SubjectName = null;
            SubjectTeacher = null;
            //для преподавателя
            TeacherFullName = null;
            //для недели
            WeekDayOfWeek = null;
            WeekOrder = null;
        }
        private void UpdateAllDataView()
        {
            UpdateAllSchedulesView();
        }


        private void UpdateAllSchedulesView()
        {
            AllSchedules = DataWorker.GetAllSchedules();
            MainWindow.MainWindowListView.ItemsSource = null;
            MainWindow.MainWindowListView.Items.Clear();
            MainWindow.MainWindowListView.ItemsSource = AllSchedules;
            MainWindow.MainWindowListView.Items.Refresh();
        }
        
        #endregion

        private void ShowMessageToUser(string message)
        {

            MessageBox.Show(message, "Уведомление",MessageBoxButton.OK);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}