using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factory
{
    public abstract class Factory
    {
        public static Factory GetFactory(string className)
        {
            Factory factory = null;
            try
            {
                var t = Type.GetType(className);
                factory = (Factory)Activator.CreateInstance(t);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return factory;
        }

        public abstract Link CreateLink(string caption, string url);
        public abstract Tray CreateTray(string caption);
        public abstract Page CreatePage(string title, string author);
    }
}
