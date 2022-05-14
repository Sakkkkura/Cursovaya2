using Course.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.MVVM.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; } = null!;

        [NotMapped]
        public string SubjectTeacherName =>$"{Name}: {SubjectTeacher.FullName}";

        [NotMapped]
        public Teacher SubjectTeacher
        {
            get
            {
                return DataWorker.GetTeacherById(TeacherId);
            }
        }
    }    
}
