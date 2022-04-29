using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.MVVM.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public int TeacherId { get; set; }
        //public virtual Teacher Teacher { get; set; } = null!;
    }
}
