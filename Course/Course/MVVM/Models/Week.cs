using Course.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.MVVM.Models
{
    public class Week
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public int DayId { get; set; }
        public virtual Day Day { get; set; } = null!;

        [NotMapped]
        public Day WeekDay
        {
            get 
            { 
                return DataWorker.GetDayById(DayId); 
            }
        }
    }
}
