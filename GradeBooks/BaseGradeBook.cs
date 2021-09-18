using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public void AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.FirstName))
                throw new ArgumentException("A Name is required to add a student to a gradebook.");
            Students.Add(student);
        }

        public void RemoveStudent(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to remove a student from a gradebook.");
            var student = Students.FirstOrDefault(e => e.FirstName == name);
            if (student == null)
            {
                Console.WriteLine("Student {0} was not found, try again.", name);
                return;
            }
            Students.Remove(student);
        }
        public void Save()
        {
            using(var file = new FileStream(Name + ".gdbk", FileMode.Create,FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    var json = JsonConvert.SerializeObject(this);
                    writer.Write(json);
                }
            }
        }

        public virtual void CalculateStatistics()
        {
            var allStudentsPoints = 0d;
            Console.WriteLine("Name\t\t LetterGrade\t Average Grade");
            foreach (var student in Students)
            {
                student.LetterGrade = GetLetterGrade(student.AverageGrade);
                Console.WriteLine($"{student.FirstName + " " + student.LastName}\t\t {student.LetterGrade}\t\t {student.AverageGrade}");
                allStudentsPoints += student.AverageGrade;

            }
            Console.WriteLine("Average Grade of all students is " + (allStudentsPoints / Students.Count));
        }


        public virtual char GetLetterGrade(double averageGrade)
        {
            if (averageGrade >= 90)
                return 'A';
            else if (averageGrade >= 80)
                return 'B';
            else if (averageGrade >= 70)
                return 'C';
            else if (averageGrade >= 60)
                return 'D';
            else
                return 'F';
        }
    }
}
