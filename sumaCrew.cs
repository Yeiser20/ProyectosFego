using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sumaCREW
{
    class MainClass
    {
        //int[] A = { 0, 5, 2, 10, 1, 8, 12, 7, 3 };
        static int[] A = new int[9];
        int n = 8;
        int i, j, x;

        public void Suma()
        {
            x = (int)(Math.Log(n, 2));
            //Console.Write("\n" + x);
            imprimir();
            for (i = 1; i <= x; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    Parallel.For(0, 1, f => {
                        if ((Math.Pow(2, i - 1)) == 1)
                        {
                            A[j] = A[j] + A[j - (int)(Math.Pow(2, i - 1))];
                        }
                    });
                }
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
            for (int f = 1; f <= 8; f++)
            {
                Console.Write("Ingrese el valor " + f + ": ");
                String linea;
                linea = Console.ReadLine();
                A[f] = int.Parse(linea);
            }
            Console.WriteLine("\t\tSUMA CREW");
            MainClass p = new MainClass();
            p.Suma();
        }
    }
}