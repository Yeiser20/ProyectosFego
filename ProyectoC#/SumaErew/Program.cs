using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sumaEREW
{
    class MainClass
    {
      
        static int[] A = new int[9];
        int n = A.Length -1;

        public void Suma()
        {

            int x = (int)(Math.Log(n, 2));

            imprimir();

            for (int i = 1; i < x + 1; i++)
            {

                Parallel.For(((int)Math.Pow(2, i - 1) + 1), n + 1, j => {
                    if (((j) % ((int)(Math.Pow(2, i)))) == 0)
                    {
                        A[j] = A[j] + A[(j) - (int)(Math.Pow(2, i - 1))];
                    }
                });
            } 

            imprimir();
            Console.Write("\n");
            Console.WriteLine("La suma total es:" + A[n]);
            Console.ReadKey(true);
        }

        public void imprimir()
        {
            Console.Write("[");
            foreach (int z in A)
            {
                Console.Write("{0} ", z);
            }
            Console.Write("]\n");
        }

        public static void Main(string[] args)
        {
            Console.Write("----1.-SUMA EREW----\n");
            for (int f = 1; f <= 8; f++)
                
            {
                Console.Write("dame el valor  " + f + ": ");
                String linea;
                linea = Console.ReadLine();
                A[f] = int.Parse(linea);
            }
            Console.WriteLine("\t\tSUMA EREW TOTAL");
            MainClass p = new MainClass();
            p.Suma();
        }
    }
}