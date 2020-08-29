using System;
using System.Collections.Generic;
using System.Text;

namespace ArbolMulticamino
{
    class ArbolMultiCamino <T> where T : IComparable
    {

        #region Clase Nodo
        internal class Nodo
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

        private Nodo Raiz = null;
        private Nodo BuscarHoja = null;

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

        public bool TieneHijos()
        {
            var TieneHijos = false; 

            for (int i = 0; i < grado; i++)
            {
                if (BuscarHoja.hijos[i] != null)
                {
                    TieneHijos = true;
                }
            }

            return TieneHijos;
        } 


        public void PosicionarHojaInsertar(T dato)
        {
            BuscarHoja = Raiz;
            var valorMenorEncontrado = false;
            var iteradorNodo = 0;
            while (TieneHijos() == true)
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
                        else
                        {
                            Nodo NuevoHijo = new Nodo(grado);
                            BuscarHoja.hijos[iteradorNodo] = NuevoHijo;
                            BuscarHoja = NuevoHijo;
                            valorMenorEncontrado = true;
                        }
                        
                    }
                
                    if (iteradorNodo == (grado - 2) && valorMenorEncontrado == false)
                    {
                        if (BuscarHoja.hijos[iteradorNodo+1] != null)
                        {
                            BuscarHoja = BuscarHoja.hijos[iteradorNodo + 1];
                            valorMenorEncontrado = true;
                        }
                        else
                        {
                            Nodo NuevoHijo = new Nodo(grado);
                            BuscarHoja.hijos[iteradorNodo+1] = NuevoHijo;
                            BuscarHoja = NuevoHijo;
                            valorMenorEncontrado = true;
                        }
                    
                    }
                }
                iteradorNodo++;
            }

            iteradorNodo = 0;
        }
    }
}
