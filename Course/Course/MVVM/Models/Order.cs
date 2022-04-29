using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.MVVM.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Queue { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; } = null!;
    }
}
