using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kurs.AppData
{
    public partial class App : Application
    {
        public static ZooBdEntities1 zbd { get; }=new ZooBdEntities1();
        
    }
}
