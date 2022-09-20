using System;

using System.Threading.Tasks;
namespace MultiMatiz
{
    class MultiMatriz
    {
        public static int n;
        public static int[,] A, B;
        public static int[,,] C;
        public static void Main(string[] args)
        {

            Console.WriteLine("\n\t---7.Multiplicacion de matrices------");

            n = 2;
            A = new int[n + 1, n + 1];
            B = new int[n + 1, n + 1];
            C = new int[n + 1, n + 1, n + 1];

            string linea;
            Console.Write("Ingrese valor 1,1 de la matriz 1:");
            linea = Console.ReadLine();
            A[1, 1] = int.Parse(linea);
            Console.Write("Ingrese valor 1,2 de la matriz 1:");
            linea = Console.ReadLine();
            A[1, 2] = int.Parse(linea);
            Console.Write("Ingrese valor 2,1 de la matriz 1:");
            linea = Console.ReadLine();
            A[2, 1] = int.Parse(linea);
            Console.Write("Ingrese valor 2,2 de la matriz 1:");
            linea = Console.ReadLine();
            A[2, 2] = int.Parse(linea);

            Console.Write("\nIngrese valor 1,1 de la matriz 2:");
            linea = Console.ReadLine();
            B[1, 1] = int.Parse(linea);
            Console.Write("Ingrese valor 1,2 de la matriz  2:");
            linea = Console.ReadLine();
            B[1, 2] = int.Parse(linea);
            Console.Write("Ingrese valor 2,1 de la matriz 2:");
            linea = Console.ReadLine();
            B[2, 1] = int.Parse(linea);
            Console.Write("Ingrese valor 2,2 de la matriz 2:");
            linea = Console.ReadLine();
            B[2, 2] = int.Parse(linea);


            Console.WriteLine("Matriz 1:");
            MuestraMat(A);
            Console.WriteLine();
            Console.WriteLine("Matriz 2:");
            MuestraMat(B);
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...\n");
            Console.ReadKey();

            Parallel.For(1, n + 1, i =>
            {
                Parallel.For(1, n + 1, j =>
                {
                    Parallel.For(1, n + 1, k =>
                    {
                        C[i, j, k] = A[i, k] * B[k, j];
                    });
                });
            });

            for (int l = 1; l <= Math.Log(n, 2); l++)
            {
                Parallel.For(1, n + 1, i =>
                {
                    Parallel.For(1, n + 1, j =>
                    {
                        Parallel.For(1, (n / 2) + 1, k =>
                        {
                            if (((2 * k) % (int)Math.Pow(2, l)) == 0)
                            {

                                int r = C[i, j, 2 * k] + C[i, j, (2 * k) - (int)Math.Pow(2, l - 1)];

                                C[i, j, 2 * k] = C[i, j, 2 * k] + C[i, j, (2 * k) - (int)Math.Pow(2, l - 1)];
                            }
                        });
                    });
                });
            }

            resultado();

            Console.ReadKey();
        }


        static void MuestraMat(int[,] X)
        {
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    Console.Write(X[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void resultado()
        {
            Console.WriteLine("RESULTADO : \n");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(C[i, j, n] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}