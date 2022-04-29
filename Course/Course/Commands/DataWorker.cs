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
        //редактирование отдел
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такого отела не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = "Сделано! Отдел " + department.Name + " изменен";
            }
            return result;
        }
        //редактирование позицию
        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                position.Name = newName;
                position.Salary = newSalary;
                position.MaxNumber = newMaxNumber;
                position.DepartmentId = newDepartment.Id;
                db.SaveChanges();
                result = "Сделано! Позиция " + position.Name + " изменена";
            }
            return result;
        }
        //редактирование сотрудника
        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check user is exist
                User user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);
                if (user != null)
                {
                    user.Name = newName;
                    user.SurName = newSurName;
                    user.Phone = newPhone;
                    user.PositionId = newPosition.Id;
                    db.SaveChanges();
                    result = "Сделано! Сотрудник " + user.Name + " изменен";
                }
            }
            return result;
        }

        //получение позиции по id позитиции
        public static Position GetPositionById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position pos = db.Positions.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение отдела по id отдела
        public static Department GetDepartmentById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department pos = db.Departments.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение всех пользователей по id позиции
        public static List<User> GetAllUsersByPositionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = (from user in GetAllUsers() where user.PositionId == id select user).ToList();
                return users;
            }
        }
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
