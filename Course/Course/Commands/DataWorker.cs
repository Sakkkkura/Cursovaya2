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
        #region ПОЛУЧИТЬ ВСЕ ...
        //получить все дни
        public static List<Day> GetAllDays()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Days.ToList();
                return result;
            }
        }

        //получить все группы
        public static List<Group> GetAllGroups()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Groups.ToList();
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
        public static List<Teacher> GetAllTeachers()
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
        #endregion

        #region СОЗДАТЬ ...
        //создать день
        public static string CreateDay(Subject firstSubject, Subject secondSubject, Subject thirdSubject)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем существует ли день
                bool checkIsExist = db.Days.Any(el => el.FirstSubject == firstSubject && el.SecondSubject == secondSubject && el.ThirdSubject == thirdSubject);
                if (!checkIsExist)
                {
                    Day newDay = new Day
                    {
                        FirstSubjectId = firstSubject.Id,
                        SecondSubjectId = secondSubject.Id,
                        ThirdSubjectId = thirdSubject.Id
                    };
                    db.Days.Add(newDay);
                    db.SaveChanges();
                    result = "Сделано!";
                }
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
        public static string CreateWeek(string dayOfWeek, Day day)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли неделя
                bool checkIsExist = db.Weeks.Any(el => el.DayOfWeek == dayOfWeek && el.Day == day);
                if (!checkIsExist)
                {
                    Week newWeek = new Week
                    {
                        DayOfWeek = dayOfWeek,
                        DayId = day.Id
                    };
                    db.Weeks.Add(newWeek);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        #endregion

        #region УДАЛЕНИЕ ...
        //удаление дня
        public static string DeleteDay(Day day)
        {
            string result = "Такого дня не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Days.Remove(day);
                db.SaveChanges();
                result = "Сделано! День удален";
            }
            return result;
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
        #endregion

        #region РЕДАКТИРОВАНИЕ ...
        //редактирование дня
        public static string EditDay(Day oldDay, Subject newFirstSubject, Subject newSecondSubject, Subject newThirdSubject)
        {
            string result = "Такого дня не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Day day = db.Days.FirstOrDefault(p => p.Id == oldDay.Id);
                day.FirstSubjectId = newFirstSubject.Id;
                day.SecondSubjectId = newSecondSubject.Id;
                day.ThirdSubjectId = newThirdSubject.Id;
                db.SaveChanges();
                result = "Сделано! День изменен";
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
        public static string EditWeek(Week oldWeek, string newDayOfWeek, Day newDay)
        {
            string result = "Такой недели не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Week week = db.Weeks.FirstOrDefault(p => p.Id == oldWeek.Id);
                week.DayOfWeek = newDayOfWeek;
                week.DayId = newDay.Id;
                db.SaveChanges();
                result = "Сделано! Предмет" + week.DayOfWeek + " изменен";
            }
            return result;
        }
        #endregion

        #region ПОЛУЧЕНИЕ ... ПО ID ...
        //получение дня по id дня
        public static Day GetDayById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Day pos = db.Days.FirstOrDefault(p => p.Id == id);
                return pos;
            }
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
        #endregion

        #region ПОЛУЧЕНИЕ ВСЕХ ... ПО ID ...
        //получение всех дней по id предмета
        //public static List<Day> GetAllDaysBySubjectId(int firstId)
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        List<Day> days = (from day in GetAllDays() where day. == firstId select day).ToList();
        //        return days;
        //    }
        //}

        //получение всех расписаний по id группы
        public static List<Schedule> GetAllSchedulesByGroupId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Schedule> schedules = (from schedule in GetAllSchedules() where schedule.GroupId == id select schedule).ToList();
                return schedules;
            }
        }

        //получение всех расписаний по id недели
        public static List<Schedule> GetAllSchedulesByWeekId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Schedule> schedules = (from schedule in GetAllSchedules() where schedule.WeekId == id select schedule).ToList();
                return schedules;
            }
        }

        //получение всех предметов по id преподавателя
        public static List<Subject> GetAllSubjectsByTeacherId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Subject> subjects = (from subject in GetAllSubjects() where subject.TeacherId == id select subject).ToList();
                return subjects;
            }
        }

        //получение всех недель по id дня
        public static List<Week> GetAllWeeksByOrderId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Week> weeks = (from week in GetAllWeeks() where week.DayId == id select week).ToList();
                return weeks;
            }
        }
        #endregion 
    }
}
