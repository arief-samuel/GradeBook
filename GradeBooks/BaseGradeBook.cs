using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class BaseGradeBook
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public BaseGradeBook(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
    }
}
