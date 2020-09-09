using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolMulticamino
{
    public class ArbolMultiCamino <T> where T : IComparable
    {

        #region Clase Nodo
        public class Nodo
        {
            public T[] datos;
            public Nodo[] hijos;
            int grado;


            public Nodo(int _grado)
            {
                datos = new T[_grado-1];
                hijos = new Nodo[_grado];
                grado = _grado;
            }


            public void InsertarOrdenar(T dato) // Inserta y usa bubble sort para ordenar
            {
                int iterador = 0;
                bool detener = false;

                while (iterador < grado && detener == false)
                {
                    if (datos[iterador] == null)
                    {
                        datos[iterador] = dato;
                        detener = true;
                    }
                    iterador++;
                }

                for (int p = 0; p <= datos.Length - 2; p++)
                {
                    for (int i = 0; i <= datos.Length - 2; i++)
                    {
                        if (datos[i + 1] != null)
                        {
                            if (datos[i].CompareTo(datos[i + 1]) == 1)
                            {
                                var temp = datos[i + 1];
                                datos[i + 1] = datos[i];
                                datos[i] = temp;

                            }
                        }
                    }
                }
            }


        }
        #endregion

        int grado;

        public ArbolMultiCamino(int _grado)
        {
            grado = _grado;
        }

        public Nodo Raiz = null;
        Nodo BuscarHoja = null;

        public LinkedList<T> RecolectorRecorridos = new LinkedList<T>();

        
        public void Insertar(T dato)
        {
            if (Raiz == null)
            {
                Nodo NuevoNodo = new Nodo(grado);
                NuevoNodo.InsertarOrdenar(dato);
                Raiz = NuevoNodo;
            }
            else
            {
                PosicionarHojaInsertar(dato);

                BuscarHoja.InsertarOrdenar(dato);
               
            }
        }

        public void InOrden(Nodo Recorrer)
        {
            if (Recorrer.hijos[0] != null)
            {
                InOrden(Recorrer.hijos[0]);
            }
            for (int i = 0; i < grado-1; i++)
            {
                if (Recorrer.datos[i] != null)
                {
                    RecolectorRecorridos.AddLast(Recorrer.datos[i]);
                }
                if (Recorrer.hijos[i + 1] != null)
                {
                    InOrden(Recorrer.hijos[i + 1]);
                }
            }
        }

        public void PostOrden(Nodo Recorrer)
        {
            if (Recorrer.hijos[0] != null)
            {
                InOrden(Recorrer.hijos[0]);
            }
            for (int i = 0; i < grado - 1; i++)
            {
                if (Recorrer.hijos[i + 1] != null)
                {
                    InOrden(Recorrer.hijos[i + 1]);
                }
                if (Recorrer.datos[i] != null)
                {
                    RecolectorRecorridos.AddLast(Recorrer.datos[i]);
                }
            }
            
        }

        //-----------------------------------------------------------------------------------------
        public void PosicionarHojaInsertar(T dato)
        {
            BuscarHoja = Raiz;
            var valorMenorEncontrado = false;
            var iteradorNodo = 0;

            while (BuscarHoja.datos[grado-2] !=null)
            {
                while (valorMenorEncontrado == false)
                {
                    if (dato.CompareTo(BuscarHoja.datos[iteradorNodo]) == -1)
                    {
                        if (BuscarHoja.hijos[iteradorNodo] !=null)
                        {
                            BuscarHoja = BuscarHoja.hijos[iteradorNodo];
                            valorMenorEncontrado = true;
                        }
                        else if(BuscarHoja.hijos[iteradorNodo] == null)
                        {
                            Nodo NuevoHijo = new Nodo(grado);
                            BuscarHoja.hijos[iteradorNodo] = NuevoHijo;
                            BuscarHoja = BuscarHoja.hijos[iteradorNodo];
                            valorMenorEncontrado = true;
                        }
                        
                    }
                
                    else if(iteradorNodo == grado-2 && valorMenorEncontrado == false)
                    {
                        if (BuscarHoja.hijos[iteradorNodo+1] != null)
                        {
                            BuscarHoja = BuscarHoja.hijos[iteradorNodo + 1];
                            valorMenorEncontrado = true;
                        }
                        else if(BuscarHoja.hijos[iteradorNodo + 1] == null)
                        {
                            Nodo NuevoHijo = new Nodo(grado);
                            BuscarHoja.hijos[iteradorNodo+ 1] = NuevoHijo;
                            BuscarHoja = NuevoHijo;
                            valorMenorEncontrado = true;
                        }
                    
                    }
                    iteradorNodo++;
                }
                iteradorNodo = 0;
                valorMenorEncontrado = false;
            }

            
        }
    }
}
