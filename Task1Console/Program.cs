using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tutor alex = new Tutor() { Name = "Alexander", SurName = "Kurilenko", Qualification = "Phd" };
            Course chemistry = new Course(alex);
            Student dima = new Student("Dmitriy", "Ignatchk", 453501, chemistry);
            Student ivan = new Student("Ivan", "Ignatchk", 453501,chemistry);
            Student peter = new Student("peter", "Ignatchk", 453501, null);
            chemistry.AddObserver(peter);
            chemistry.SetUpMark(peter, 2);
            chemistry.SetUpMark(dima, 5);
            chemistry.SetUpMark(peter, 200);
            chemistry.NotifyObservers();
            chemistry.RemoveObserver(dima);
            FileArchive storage = new FileArchive("output.txt");
            chemistry.SaveToArchive(storage);
            Console.WriteLine(dima.Grade.ToString());
            Console.ReadKey();
        }
    }
}
