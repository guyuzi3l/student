using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_ACCESS_EF.DTO
{
    public class StudentModel
    {
        public int Student_Id { get; set; }
        public bool? Is_Active { get; set; }
        public string Student_Name { get; set; }
        public Nullable<double> Avg_Grade { get; set; }
    }
}
