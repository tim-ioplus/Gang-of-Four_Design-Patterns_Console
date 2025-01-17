using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Creational.Singleton
{
    public class IamSingleton
    {
        private static IamSingleton instance;

        private int initCount = 0;
        private string guid = "";
        private IamSingleton()
        {
            guid = Guid.NewGuid().ToString();
        }

        public static IamSingleton getInstance()
        {
            if (instance == null)
            {
                instance = new IamSingleton();
            }

            instance.initCount++;

            return instance;
        }

        public string ToString()
        {
            return "IamSingleton " + guid + " - #" + initCount;
        }

        public bool WriteFile(string path)
        {
            if (initCount == 1)
            {
                Console.WriteLine(string.Format("Writing File to {0} .. wait.", path));
                Thread.Sleep(1250);
                Console.WriteLine(string.Format("File written to {0} .. done.", path));

                return true;
            }
            else
            {
                Console.WriteLine("No 2nd Instance to prohibit writing the same File.");

                return false;
            }
        }

    }
}
