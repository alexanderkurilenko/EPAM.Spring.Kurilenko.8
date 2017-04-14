using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public interface IArchive
    {
        void AddToArchive(Dictionary<IObserver, uint> grades);
    }
}
