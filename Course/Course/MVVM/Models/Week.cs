using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.MVVM.Models
{
    public class Week
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }
}
