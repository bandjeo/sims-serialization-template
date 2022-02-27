using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.model
{
    class Student: Serializable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; }


        public Student()
        {
            Subjects = new List<Subject>();
        }
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
            Subjects = new List<Subject>();
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Name
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
        }
    }
}
