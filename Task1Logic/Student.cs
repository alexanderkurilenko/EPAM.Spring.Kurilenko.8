using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class Student:IObserver
    {
        #region Props&Fields
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Group { get; set; }
        public uint Grade { get; private set; }
        private IObservable facultative;
        #endregion

        #region  Ctors
        /// <summary>
        /// Ctor with all parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surName"></param>
        /// <param name="group"></param>
        /// <param name="obs"></param>
        public Student(string name,string surName,int group,IObservable obs)
        {
            Name = name;
            SurName = surName;
            Group = group;
            facultative = obs;

            if (obs != null)
            {
                facultative.AddObserver(this);
            }
        }
        #endregion

        /// <summary>
        /// Drop out course
        /// </summary>
        public void Release()
        {
            facultative.RemoveObserver(this);
            facultative = null;
        }
       
        /// <summary>
        /// Override method  ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + "  " + SurName;
        }

        /// <summary>
        /// Setting mark
        /// </summary>
        /// <param name="mark"></param>
        public void SetGrade(uint mark)
        {
            Grade = mark;
        }
    }
}
