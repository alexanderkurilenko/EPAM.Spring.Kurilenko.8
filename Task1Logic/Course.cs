using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class Course:IObservable
    {
        #region Fields
        private List<IObserver> students;
        private Tutor tutor;
        private string title;
        private Dictionary<IObserver, uint> marks;
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor with tutor parameter
        /// </summary>
        /// <param name="headOfCourse"></param>
        public Course(Tutor headOfCourse)
        {
            if (headOfCourse == null)
            {
                throw new NullReferenceException();
            }

            tutor = headOfCourse;
            students = new List<IObserver>();
            marks = new Dictionary<IObserver, uint>();
        }

        public Course(Tutor headOfCourse,string name)
        {
            if (headOfCourse == null)
            {
                throw new NullReferenceException();
            }
            if (String.IsNullOrEmpty(name))
            {
                throw new NullReferenceException();
            }
            title = name;
            tutor = headOfCourse;
            students = new List<IObserver>();
            marks = new Dictionary<IObserver, uint>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserting student
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(IObserver observer)
        {
            if (observer == null)
            {
                throw new NullReferenceException();
            }
            if (!students.Contains(observer)){
                students.Add(observer);
            }
        }

        /// <summary>
        /// Enterting collection of students
        /// </summary>
        /// <param name="observers"></param>
        public void AddObserver(IEnumerable<IObserver> observers)
        {
            if (observers == null)
            {
                throw new NullReferenceException();
            }

            foreach(var stud in observers)
            {
                if (!students.Contains(stud))
                {
                    students.Add(stud);
                }
            }
        }

        /// <summary>
        /// Set up mark
        /// </summary>
        /// <param name="student"></param>
        /// <param name="mark"></param>
        public void SetUpMark(IObserver student,uint mark)
        {
            if (students.Contains((Student)student))
            {
                marks[(Student)student] = mark;
            }
            else
            {
                throw new Exception("Student not found");
            }
        }
        /// <summary>
        /// saving to archive
        /// </summary>
        /// <param name="arch"></param>
        public void SaveToArchive(IArchive arch)
        {
            arch.AddToArchive(marks);
        }

        /// <summary>
        /// removing student
        /// </summary>
        /// <param name="o"></param>
        public void RemoveObserver(IObserver o)
        {
            if (students.Contains(o))
            {
                students.Remove(o);
            }
        }

        /// <summary>
        /// notifying for everyone
        /// </summary>
        public void NotifyObservers()
        {
           foreach(Student o in students)
            {
                if (marks.ContainsKey(o))
                {
                    o.SetGrade(marks[o]);
                }
                
            }
        }
        #endregion
    }
}
