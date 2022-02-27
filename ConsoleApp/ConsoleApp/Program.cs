using ConsoleApp.model;
using ConsoleApp.serialization;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Professor> professors = professorExample();

            List<Subject> subjects = subjectExample(professors);

            List<Student> students = studentExample(subjects);

            printProfessors(professors);
            printSubjects(subjects);
            printStudents(students);
        }

        static List<Professor> professorExample()
        {
            // Serijalizacija profesora
            List<Professor> professors = new List<Professor>
            {
                new Professor(1, "Professor1"),
                new Professor(2, "Professor2")
            };
            Serializer<Professor> professorSerializer = new Serializer<Professor>();
            professorSerializer.toCSV("professors.txt", professors);

            // Deserijalizacija profesora
            professors = professorSerializer.fromCSV("professors.txt");

            return professors;
        }

        static List<Subject> subjectExample(List<Professor> professors)
        {
            // Serijalizacija predmeta
            List<Subject> subjects = new List<Subject>
            {
                new Subject(1, "subject1", 8, 1),
                new Subject(2, "subject2", 2, 1),
                new Subject(3, "subject3", 4, 2),
            };
            Serializer<Subject> subjectSerializer = new Serializer<Subject>();
            subjectSerializer.toCSV("subjects.txt", subjects);

            // Deserijalizacija predmeta
            subjects = subjectSerializer.fromCSV("subjects.txt");

            // Uvezivanje predmeta sa profesoraima (one to many)
            foreach (Subject subject in subjects)
            {
                Professor professor = professors.Find(p => p.Id == subject.ProfessorId);
                professor.Subjects.Add(subject);
                subject.Professor = professor;
            }

            return subjects;
        }

        static List<Student> studentExample(List<Subject> subjects)
        {
            // Serijalizacija studenata
            List<Student> students = new List<Student>
            {
                new Student(1, "student1"),
                new Student(2, "student2")
            };
            Serializer<Student> studentSerializer = new Serializer<Student>();
            studentSerializer.toCSV("students.txt", students);

            // Deserijalizacija studenata
            students = studentSerializer.fromCSV("students.txt");


            // Veza student - predment je many to many
            // Serijalizujemo je pomocu klase StudentSubject, koja ima one to many vezu sa oba entiteta

            List<StudentSubject> studentSubjects = new List<StudentSubject>
            {
                new StudentSubject(1, 1),
                new StudentSubject(1, 3),
                new StudentSubject(2, 2),
                new StudentSubject(2, 3)
            };
            Serializer<StudentSubject> studentSubjectSerializer = new Serializer<StudentSubject>();
            studentSubjectSerializer.toCSV("studentSubject.txt", studentSubjects);

            studentSubjects = studentSubjectSerializer.fromCSV("studentSubject.txt");
            

            // Uvezivanje studenata i predmeta
            foreach(StudentSubject studentSubject in studentSubjects)
            {
                Student student = students.Find(s => s.Id == studentSubject.StudentId);
                Subject subject = subjects.Find(s => s.Id == studentSubject.SubjectId);
                student.Subjects.Add(subject);
                subject.Students.Add(student);
            }

            return students;
        }


        static void printProfessors(List<Professor> professors)
        {
            Console.WriteLine("### Professors ###");

            foreach (Professor p in professors)
            {
                string text = "ID: " + p.Id.ToString() + ", ";
                text += "NAME: " + p.Name + ", ";
                text += "SUBJECTS: ";
                foreach(Subject s in p.Subjects) {
                    text += s.Name + ", ";
                }
                Console.WriteLine(text);
            }
        }

        static void printSubjects(List<Subject> subjects)
        {
            Console.WriteLine("### Subjects ###");
            foreach (Subject s in subjects)
            {
                string text = "ID: " + s.Id.ToString() + ", ";
                text += "NAME: " + s.Name + ", ";
                text += "ESPB: " + s.Espb + ", ";
                text += "STUDENTS: ";
                foreach (Student st in s.Students)
                {
                    text += st.Name + ", ";
                }
                Console.WriteLine(text);
            }
        }

        static void printStudents(List<Student> students)
        {
            Console.WriteLine("### Students ###");

            foreach (Student s in students)
            {
                string text = "ID: " + s.Id.ToString() + ", ";
                text += "IME: " + s.Name + ", ";
                text += "SUBJECTS: ";
                foreach (Subject sub in s.Subjects)
                {
                    text += sub.Name + ", ";
                }
                Console.WriteLine(text);
            }
        }
    }
}
