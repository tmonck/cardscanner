using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTcgScanner
{
    public interface ICardApi<T>
    {
        T LookUpCard(string name, string number, string set);
        T LookUpCard(string name, string number);
        T LookUpCard(string name);
    }
}
