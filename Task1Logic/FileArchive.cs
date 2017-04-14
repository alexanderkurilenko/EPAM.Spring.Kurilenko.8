using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class FileArchive : IArchive
    {
        #region Fields
        private string filePath;
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor with string parameter filepath
        /// </summary>
        /// <param name="path"></param>
        public FileArchive(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new NullReferenceException();
            }
            filePath = path;
        }
        #endregion

        #region Methods
        /// <summary>
        /// public meethod for logging file
        /// </summary>
        /// <param name="grades"></param>
        public void AddToArchive(Dictionary<IObserver, uint> grades)
        {
            WriteGrades(grades, filePath);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Save dictionary to file
        /// </summary>
        /// <param name="grades"></param>
        /// <param name="filePath"></param>
        private void WriteGrades(Dictionary<IObserver, uint> grades, string filePath)
        {
            if (filePath == "" && filePath == null)
            {
                throw new ArgumentNullException();
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                foreach (var entry in grades)
                {
                    writer.Write(entry.ToString()+"\n");
                }
                   
            }
        }
        #endregion
    }
}
