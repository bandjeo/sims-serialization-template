using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.model
{
    class StudentSubject: Serializable
    {
        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public StudentSubject() { }

        public StudentSubject(int studentId, int subjectId)
        {
            StudentId = studentId;
            SubjectId = subjectId;
        }

        public void fromCSV(string[] values)
        {
            StudentId = int.Parse(values[0]);
            SubjectId = int.Parse(values[1]);
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                StudentId.ToString(),
                SubjectId.ToString()
            };
            return csvValues;
        }
    }
}
