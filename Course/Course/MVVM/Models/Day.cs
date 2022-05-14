using Course.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.MVVM.Models
{
    public class Day
    {
        public int Id { get; set; }
        public int FirstSubjectId { get; set; }
        public virtual Subject FirstSubject { get; set; } = null!;
        public int SecondSubjectId { get; set; }
        public virtual Subject SecondSubject { get; set; } = null!;
        public int ThirdSubjectId { get; set; }
        public virtual Subject ThirdSubject { get; set; } = null!;

        [NotMapped]
        public Subject DayFirstSubject
        {
            get
            {
                return DataWorker.GetSubjectById(FirstSubjectId);
            }
        }
        [NotMapped]
        public Subject DaySecondSubject
        {
            get
            {
                return DataWorker.GetSubjectById(SecondSubjectId);
            }
        }
        [NotMapped]
        public Subject DayThirdSubject
        {
            get
            {
                return DataWorker.GetSubjectById(ThirdSubjectId);
            }
        }
    }
}
