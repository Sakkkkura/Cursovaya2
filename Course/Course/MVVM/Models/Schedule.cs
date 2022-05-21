using Course.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.MVVM.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; } = null!;
        public int WeekId { get; set; }
        public virtual Week Week { get; set; } = null!;

        [NotMapped]
        public string SceduleDay => $"{ScheduleWeek.DayOfWeek} 1: {ScheduleWeek.WeekDay.DayFirstSubject.Name}; 2:        {ScheduleWeek.WeekDay.DayFirstSubject.Name}; 3: {ScheduleWeek.WeekDay.DayFirstSubject.Name};";

        [NotMapped]
        public Group ScheduleGroup
        {
            get
            {
                return DataWorker.GetGroupById(GroupId);
            }
        }

        [NotMapped]
        public Week ScheduleWeek
        {
            get
            {
                return DataWorker.GetWeekById(WeekId);
            }
        }
    }
}
