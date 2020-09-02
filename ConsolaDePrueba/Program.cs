using System;
using ArbolMulticamino;
namespace ConsolaDePrueba
{
    class Program
    {
        static void Main(string[] args)
        {

            ArbolMultiCamino<Numero> Arbolin = new ArbolMultiCamino<Numero>(3);
            
            int decision;
            bool terminarCiclo = false;

            while (terminarCiclo == false)
            {
                Console.WriteLine("Eliga una opcion");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. InOrden");
                Console.WriteLine("3. Mostrar");

                Console.WriteLine("0 salir");
                decision = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (decision)
                {
                    case 1:
                        Numero nuevo = new Numero();
                        Console.WriteLine("Ingrese el numero");
                        nuevo.valor = Convert.ToInt32(Console.ReadLine());
                        Arbolin.Insertar(nuevo);
                        break;
                    case 2:
                        Arbolin.InOrden(Arbolin.Raiz);
                        foreach (var item in Arbolin.RecolectorRecorridos)
                        {
                            Console.WriteLine(item.valor);
                        }
                        Console.ReadLine();
                        break;
                    case 0:
                        terminarCiclo = true;
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }















            Console.ReadLine();
        }
    }
}
