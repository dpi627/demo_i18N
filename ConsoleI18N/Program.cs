using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleI18N
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rm = i18N.Views.LM09.LM0915.ResourceManager;
            var rs = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            WriteData(rs);

            WriteData(GetResourceSet("i18N.Views.LM09.LM0915", "en-US"));
            WriteData(GetResourceSet("i18N.Views.LM09.LM0915", "ja-JP"));
            WriteData(GetResourceSet("i18N.Views.LM09.LM0915"));

            Console.ReadLine();
        }

        /// <summary>
        /// Get ResourceSet from DLL
        /// </summary>
        /// <param name="baseName">Assembly Name</param>
        /// <param name="cultureName">Culture Name</param>
        /// <returns></returns>
        static ResourceSet GetResourceSet(string baseName, string cultureName = null)
        {
            CultureInfo cultureInfo = string.IsNullOrEmpty(cultureName) ? CultureInfo.CurrentCulture : new CultureInfo(cultureName);
            Assembly assembly = Assembly.LoadFrom($"{baseName.Split('.')[0]}.dll");
            ResourceManager rm = new ResourceManager(baseName, assembly);
            ResourceSet rs = rm.GetResourceSet(cultureInfo, true, true);
            return rs;
        }

        /// <summary>
        /// Print data
        /// </summary>
        static void WriteData(ResourceSet rs)
        {
            foreach (DictionaryEntry r in rs)
            {
                var key = r.Key.ToString();
                var val = r.Value.ToString();
                Console.WriteLine($"{key} : {val}");
            }
        }
    }
}
