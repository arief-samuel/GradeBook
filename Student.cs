using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
        public char LetterGrade { get; set; }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grades must be between 0 and 100.");
            Grades.Add(grade);
        }
        public void RemoveGrade(double grade)
        {
            Grades.Remove(grade);
        }
    }
}
