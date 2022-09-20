using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sumaCrew
{
    class MainClass
    {
        
        static int[] A = new int[9];
        int n = 8;
        int i, j, x;

        public void Suma()
        {
            x = (int)(Math.Log(n, 2));

            imprimir();
            for (int i = 1; i < x; i++)
            {
                Parallel.For(((int)Math.Pow(2, i - 1) + 1), n + 1, j => {
                    
                    if ((Math.Pow(2, i - 1)) == 1)
                    {
                        A[j] = A[j] + A[j - (int)(Math.Pow(2, i - 1))];
                    }
                });
            }

            imprimir();
            Console.Write("\n");
            Console.WriteLine("La suma es:" + A[n]);
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
            Console.Write("---2.-SUMA CREW----\n"); 
            for (int f = 1; f <= 8; f++)
            {
                Console.Write("Dame el valor " + f + ": ");
                String linea;
                linea = Console.ReadLine();
                A[f] = int.Parse(linea);
            }
            Console.WriteLine("\t\tSUMA CREW(TOTAL)");
            MainClass p = new MainClass();
            p.Suma();
        }
    }
}