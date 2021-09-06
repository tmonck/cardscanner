using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTcgScanner
{
    public interface ICardApi<T>
    {
        Task<T> LookUpCard(string name, string number, string set);
        Task<T> LookUpCard(string name, string number);
        Task<T> LookUpCard(string name);
    }
}
