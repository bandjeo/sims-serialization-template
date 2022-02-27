using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.model
{
    class Subject: Serializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Espb { get; set; }

        // Id professora se serijalizuje
        public int ProfessorId { get; set; }

        // Professor se ne serijalizuje
        public Professor Professor { get; set; }

        public List<Student> Students { get; set; }

        public Subject() 
        {
            Students = new List<Student>();
        }

        public Subject(int id, string name, int espb, int professorId)
        {
            Id = id;
            Name = name;
            Espb = espb;
            ProfessorId = professorId;
            Students = new List<Student>();
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Name,
                Espb.ToString(),
                ProfessorId.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Id = Int32.Parse(values[0]);
            Name = values[1];
            Espb = Int32.Parse(values[2]);
            ProfessorId = Int32.Parse(values[3]);
        }
    }
}
