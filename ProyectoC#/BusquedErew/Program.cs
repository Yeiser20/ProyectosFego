using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaEREW
{
    class Program
    {
  

        static void Broadcast(int x, int i, ref int[] temp)
        {
            int n = temp.Length - 1;
            for (int j = 1; j <= (int)(Math.Pow(2, i - 1) + 1); j++)
            {
                if (j <= (int)(Math.Pow(2, i - 1) + 1))
                {
                    temp[j] = x;
                }
            }
        }
        static void SearchMin(int i, ref int[] L, ref int[] temp)
        {
            if (L[i] == temp[i])
            {
                temp[i] = i;
            }
            else
            {
                temp[i] = 0;
            }

        }


        static void Min(int n, ref int[] temp)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (temp[i] == 0)
                {
                    temp[i] = temp[i + 1];
                    temp[i + 1] = 0;
                }
                else
                {
                    if (temp[i] < temp[i + 1])
                    {
                        temp[i + 1] = 0;
                    }
                }

            }

        }
        static void MinPram(int x, int n, ref int[] temp)
        {
            int h = 1;

            while (h < temp.Length)
            {
                if (temp[h] != 0)
                {
                    x = temp[h];
                    break;
                }
                h = h + 1;
            }
            x = x + 1;
            Console.WriteLine("esta en la posicion: " + x);
        }
        static void MuestraVectorL(ref int[] L)
        {
            int k;
            int n = L.Length;
            for (k = 0; k <= n - 1; k++)
            {
                Console.Write(L[k] + " ");
            }

        }
        static void MuestraVectorTemp(ref int[] temp)
        {
            int k;
            int n = temp.Length;
            for (k = 0; k <= n - 1; k++)
            {
                Console.Write(temp[k] + " ");
            }

        }
  
        static void Main(string[] args)
        {
            Console.Write("Busqueda EREW  \n");
            Console.Write("se requieren 16 elementos \n");
            int i;
            int[] L = new int[17];
            for (int f = 1; f <= 16; f++)
            {
                Console.Write("Ingrese el valor " + f + ": ");
                String linea;
                linea = Console.ReadLine();
                L[f] = int.Parse(linea);
            }

            int[] temp = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int x = 5;
            

            int n = 16;
            double lg = (Math.Log((double)n / (Math.Log(2)) + 3));
            Console.WriteLine("\nOriginal: ");
            MuestraVectorL(ref L);
            Console.WriteLine();
            Console.ReadKey();

          
            for (i = 0; i <= Math.Log(n, 2); i++)
            {
                var t = Task.Factory.StartNew(() => Broadcast(x, i, ref temp));
                t.Wait();
            }
            Console.WriteLine("\nBroadcast: ");
            MuestraVectorTemp(ref temp);
            Console.WriteLine();
            Console.ReadKey();
   
            Console.WriteLine("\nBuscar EREW: ");
            for (i = 1; i <= n - 1; i++)
            {
                var t = Task.Factory.StartNew(() => SearchMin(i, ref L, ref temp));
                t.Wait();

                MuestraVectorTemp(ref temp);
                Console.WriteLine();

            }
            Console.ReadKey();
       
            for (i = 0; i <= n + 1; i++)
            {
                var t = Task.Factory.StartNew(() => Min(n, ref temp));
                t.Wait();
            }
            Console.WriteLine("\nFuncion Minima: ");
            MuestraVectorTemp(ref temp);
            Console.WriteLine("\nResultado: ");
            MinPram(x, n, ref temp);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}