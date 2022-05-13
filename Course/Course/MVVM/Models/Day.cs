using System;
using System.Collections.Generic;
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
    }
}
