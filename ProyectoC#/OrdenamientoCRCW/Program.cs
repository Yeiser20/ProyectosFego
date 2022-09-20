using System;

using System.Threading.Tasks;


namespace OrdenamientoCRCW
{
    class OrdenamientoCRCW
    {
        
        static int[] L = new int[4];
        static int n = 4;
        static int[] win = { 99, 99, 99, 99 };
        static int[] L2 = { 0, 0, 0, 0 };

        
        public static void tarea1()
        {
            Parallel.For(0, n, i =>
            {
                win[i] = 0;
            });
            Console.WriteLine("\nPaso 1: ");
            muestra(win);

        }
        public static void tarea2()
        {
            Parallel.For(0, n, i =>
            {
                Parallel.For(0, n, j =>
                {
                    if (i < j)
                    {
                        if (L[i] > L[j])
                        {
                            win[i] = win[i] + 1;
                        }
                        else
                        {

                            win[j] += 1;
                        }
                    }
                });
            });
            Console.WriteLine("\nPaso 2: ");
            Console.WriteLine();
            muestra(win);
        }
        public static void tarea3()
        {
            Parallel.For(0, n, i => {
                L2[win[i]] = L[i];
            });
            Console.WriteLine("\nRESULTADO: ");
            muestra(L2);
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void muestra(int[] aux)
        {
            int k;
            int n = aux.Length;
            for (k = 0; k < n; k++)
            {
                Console.Write(aux[k] + " ");
            }
        }

  
        static void Main(string[] args)
        {
            Console.Write("---5.-Ordenamiento CRCW--- \n");
            Console.Write("Se requieren 4 valores \n");
            for (int f = 0; f <= 3; f++)
            {
                Console.Write("Dame el valor " + f + ": ");
                String linea;
                linea = Console.ReadLine();
                L[f] = int.Parse(linea);
            }
            Console.Write("\nVector: \n");
            muestra(L);
            Console.WriteLine();
            Console.ReadKey();

            Task t = new Task(() => { tarea1(); });
            Task t1 = new Task(() => { tarea2(); });
            Task t2 = new Task(() => { tarea3(); });
            t.Start();
            t.Wait();
            Console.WriteLine();
            Console.ReadKey();
            t1.Start();
            t1.Wait();
            Console.WriteLine();
            Console.ReadKey();
            t2.Start();
            t2.Wait();
        }
    }
}
