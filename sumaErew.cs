using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sumaEREW
{
    class sumaErew
    {
        
        static int[] A = new int[9];
        int n = 8; 
        int i, j = 1, x;

        public void Suma() { 

            x = (int)(Math.Log(n, 2));

            imprimir();


            for (i = 1; i < x + 1; i++)
            {
                for (j = 1; j <= (n / 2); j++)
                {
                    Parallel.For(0, 1, index => {  
                        if (((2 * j) % ((int)(Math.Pow(2, i)))) == 0)
                        {
                            A[j * 2] = A[j * 2] + A[(j * 2) - (int)(Math.Pow(2, i - 1))];
                        }
                    });
                }
            }
            imprimir();
            Console.Write("\n");
            Console.WriteLine("La suma es:" + A[n]);
            Console.ReadKey(true);
        }

        public void EREW()
        {
            if (((2 * j) % ((int)(Math.Pow(2, i)))) == 0)
            {
                A[j * 2] = A[j * 2] + A[(j * 2) - (int)(Math.Pow(2, i - 1))];
            }
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
            Console.Write("---1.- SUMA EREW---");
            for (int f = 1; f <= 8; f++)
            {
                Console.Write("Dame el valor " + f + ": ");
                String linea;
                linea = Console.ReadLine();
                A[f] = int.Parse(linea);
            }
            Console.WriteLine("\t\tSUMA EREW");
            MainClass p = new MainClass();
            p.Suma();
        }
    }
}