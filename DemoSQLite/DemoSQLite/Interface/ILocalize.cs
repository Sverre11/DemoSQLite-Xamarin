using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSQLite.Interface
{
    interface ILocalize
    {
        CultureInfo GetCurrentCulterInfo();
        void SetLocal(CultureInfo cultureInfo);
    }
}
