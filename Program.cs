//#define SHOW_PINVOKE_BUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace AnyConsoleTest
{
    public class TupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>>
    {
        public void Add(T1 item, T2 item2, T3 item3)
        {
            Add(new Tuple<T1, T2, T3>(item, item2, item3));
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ages = new TupleList<int, int, int>();
            for (int i = 1; i <= 6; i++)
            {
                for (int j = i; j <= 11; j++)
                {
                    if (13 - i - j > 0 && 13 - i - j >= j)
                        ages.Add(i,j,13-i-j);
                }
            }
            
            try
            {
                using (StreamWriter sw = new StreamWriter("out.txt"))
                {
                    sw.WriteLine("Age1\tAge2\tAge3\tProduct");
                    foreach (var age in ages)
                    {
                        sw.WriteLine("{0}\t{1}\t{2}\t{3}", age.Item1, age.Item2, age.Item3,
                            age.Item1 * age.Item2 * age.Item3);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
