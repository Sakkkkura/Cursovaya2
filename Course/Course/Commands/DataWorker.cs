using Course.MVVM.Models;
using Course.MVVM.Models.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Commands
{
    public static class DataWorker
    {
        //получить все группы
        public static List<Group> GetAllGroups()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Groups.ToList();
                return result;
            }
        }

        //получить весь порядок
        public static List<Order> GetAllOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Orders.ToList();
                return result;
            }
        }

        //получить все расписание
        public static List<Schedule> GetAllSchedules()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Schedules.ToList();
                return result;
            }
        }

        //получить все предметы
        public static List<Subject> GetAllSubjects()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Subjects.ToList();
                return result;
            }
        }

        //получить всех преподавателей
        public static List<Teacher> GetAlTeachers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Teachers.ToList();
                return result;
            }
        }

        //получить все дни недели
        public static List<Week> GetAllWeeks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Weeks.ToList();
                return result;
            }
        }

        //создать группу
        public static string CreateGroup(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли группа
                bool checkIsExist = db.Groups.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Group newGroup = new Group { Name = name };
                    db.Groups.Add(newGroup);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        //содать порядок
        public static string CreateOrder(int queue, Subject subject)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли порядок
                bool checkIsExist = db.Orders.Any(el => el.Queue == queue && el.Subject == subject);
                if (!checkIsExist)
                {
                    Order newOrder = new Order
                    {
                        Queue = queue,
                        SubjectId = subject.Id
                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        //создать расписание
        public static string CreateSchedule(Group group, Week week)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли расписание
                bool checkIsExist = db.Schedules.Any(el => el.Group == group && el.Week == week);
                if (!checkIsExist)
                {
                    Schedule newSchedule = new Schedule
                    {
                        GroupId = group.Id,
                        WeekId = week.Id
                    };
                    db.Schedules.Add(newSchedule);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }

        }

        //создать предмет
        public static string CreateSubject(string name, Teacher teacher)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли предмет
                bool checkIsExist = db.Subjects.Any(el => el.Name == name && el.Teacher == teacher);
                if (!checkIsExist)
                {
                    Subject newSubject = new Subject
                    {
                        Name = name,
                        TeacherId = teacher.Id
                    };
                    db.Subjects.Add(newSubject);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        //создать преподавателя
        public static string CreateTeacher(string fullName)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли преподаватель
                bool checkIsExist = db.Teachers.Any(el => el.FullName == fullName);
                if (!checkIsExist)
                {
                    Teacher newTeacher = new Teacher
                    {
                        FullName = fullName,
                    };
                    db.Teachers.Add(newTeacher);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        //создать неделю
        public static string CreateWeek(string dayOfWeek, Order order)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли неделя
                bool checkIsExist = db.Weeks.Any(el => el.DayOfWeek == dayOfWeek && el.Order == order);
                if (!checkIsExist)
                {
                    Week newWeek = new Week
                    {
                        DayOfWeek = dayOfWeek,
                        OrderId = order.Id
                    };
                    db.Weeks.Add(newWeek);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        //удаление групп
        public static string DeleteGroup(Group group)
        {
            string result = "Такой группы не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Groups.Remove(group);
                db.SaveChanges();
                result = "Сделано! Группы " + group.Name + " удалена";
            }
            return result;
        }

        //удаление порядка
        public static string DeleteOrder(Order order)
        {
            string result = "Такого порядка не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                result = "Сделано! День удален";
            }
            return result;
        }

        //удаление расписания
        public static string DeleteSchedule(Schedule schedule)
        {
            string result = "Такого расписания не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Schedules.Remove(schedule);
                db.SaveChanges();
                result = "Сделано! Расписание для группы" + schedule.Group.Name + " удалено";
            }
            return result;
        }

        //удаление предмета
        public static string DeleteSubject(Subject subject)
        {
            string result = "Такого предмета не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Subjects.Remove(subject);
                db.SaveChanges();
                result = "Сделано! Предмет" + subject.Name + " удален";
            }
            return result;
        }

        //удаление преподавателя
        public static string DeleteTeacher(Teacher teacher)
        {
            string result = "Такого преподавателя не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Teachers.Remove(teacher);
                db.SaveChanges();
                result = "Сделано! Преподаватель" + teacher.FullName + " удален";
            }
            return result;
        }

        //удаление недели
        public static string DeleteWeek(Week week)
        {
            string result = "Такой недели не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Weeks.Remove(week);
                db.SaveChanges();
                result = "Сделано! Неделя удалена";
            }
            return result;
        }

        //редактирование группы
        public static string EditGroup(Group oldGroup, string newName)
        {
            string result = "Такой группы не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Group group = db.Groups.FirstOrDefault(d => d.Id == oldGroup.Id);
                group.Name = newName;
                db.SaveChanges();
                result = "Сделано! Группа " + group.Name + " изменена";
            }
            return result;
        }

        //редактирование порядка
        public static string EditOrder(Order oldOrder, int newQueue, Subject newSubject)
        {
            string result = "Такого дня не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Order order = db.Orders.FirstOrDefault(p => p.Id == oldOrder.Id);
                order.Queue = newQueue;
                order.SubjectId = newSubject.Id;
                db.SaveChanges();
                result = "Сделано! День изменен";
            }
            return result;
        }

        //редактирование расписания
        public static string EditSchedule(Schedule oldSchedule, Group newGroup, Week newWeek)
        {
            string result = "Такого расписания не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Schedule schedule = db.Schedules.FirstOrDefault(p => p.Id == oldSchedule.Id);
                if (schedule != null)
                {
                    schedule.GroupId = newGroup.Id;
                    schedule.WeekId = newWeek.Id;
                    db.SaveChanges();
                    result = "Сделано! Расписание " + schedule.Group.Name + " изменено";
                }
            }
            return result;
        }

        //редактирование предмета
        public static string EditSubject(Subject oldSubject, string newName, Teacher newTeacher)
        {
            string result = "Такого предмета не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Subject subject = db.Subjects.FirstOrDefault(p => p.Id == oldSubject.Id);
                subject.Name = newName;
                subject.TeacherId = newTeacher.Id;
                db.SaveChanges();
                result = "Сделано! Предмет" + subject.Name + " изменен";
            }
            return result;
        }

        //редактирование преподавателя
        public static string EditTeacher(Teacher oldTeacher, string newFullName)
        {
            string result = "Такого преподавателя не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Teacher teacher = db.Teachers.FirstOrDefault(p => p.Id == oldTeacher.Id);
                teacher.FullName = newFullName;
                db.SaveChanges();
                result = "Сделано! Предмет" + teacher.FullName + " изменен";
            }
            return result;
        }

        //редактирование недели
        public static string EditWeek(Week oldWeek, string newDayOfWeek, Order newOrder)
        {
            string result = "Такой недели не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Week week = db.Weeks.FirstOrDefault(p => p.Id == oldWeek.Id);
                week.DayOfWeek = newDayOfWeek;
                week.OrderId = newOrder.Id;
                db.SaveChanges();
                result = "Сделано! Предмет" + week.DayOfWeek + " изменен";
            }
            return result;
        }

        //получение группы по id группы
        public static Group GetGroupById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Group pos = db.Groups.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        //получение дня по id дня
        public static Order GetOrderById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order pos = db.Orders.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        //получение расписания по id расписания
        public static Schedule GetScheduleById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Schedule pos = db.Schedules.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        //получение предмета по id предмета
        public static Subject GetSubjectById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Subject pos = db.Subjects.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        //получение преподавателя по id преподавателя
        public static Teacher GetTeacherById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Teacher pos = db.Teachers.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        //получение недели по id недели
        public static Week GetWeekById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Week pos = db.Weeks.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        //получение всех групп по id группы
        //public static List<Group> GetAllGroupsByGroupId(int id)
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        List<Group> groups = (from group in GetAllGroups() where group.GroupId == id select group).ToList();
        //        return groups;
        //    }
        //}

        //получение всех позиций по id отдела
        public static List<Position> GetAllPositionsByDepartmentId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Position> positions = (from position in GetAllPositions() where position.DepartmentId == id select position).ToList();
                return positions;
            }
        }
    }
}
