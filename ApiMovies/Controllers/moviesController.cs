﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArbolMulticamino;
using ApiMovies.Models;
//using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Text.Json;


namespace ApiMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moviesController : ControllerBase
    {

        static ArbolMultiCamino<Movie> Arbol;
        static bool ArbolInicialiado = false;

        // Ordenamiento segun recorrido 
        [HttpGet]
        [Route("{traversal}")]
        public LinkedList<Movie> Metodo(string traversal)
        {
            if (ArbolInicialiado == true && (traversal == "inorden" || traversal == "InOrden" || traversal == "inOrden"))
            {
                Arbol.InOrden(Arbol.Raiz);
                return Arbol.RecolectorRecorridos;
            }

            //if (ArbolInicialiado == true && (traversal == "postorden" || traversal == "PostOrden" || traversal == "postOrden"))
            //{
            //    Arbol.PostOrden(Arbol.Raiz);
            //    return Arbol.RecolectorRecorridos;
            //}

            //if (ArbolInicialiado == true && (traversal == "preorden" || traversal == "PreOrden" || traversal == "preOrden"))
            //{
            //    Arbol.PreOrden(Arbol.Raiz);
            //    return Arbol.RecolectorRecorridos;
            //}

            return null;
        }


        [HttpPost]
        public string InicializarArbol(Grado order) // Inicializacion del arbol de grado n
        {
            string mensaje = ("Arbol de grado " + order.Order.ToString() + " inicializado");
            Arbol = new ArbolMultiCamino<Movie>(order.Order);
            ArbolInicialiado = true;
            return mensaje;
        }

        //Recibe un archivo JSON con un listado de películas
        [HttpPost]
        [Route("populate")]
        public async Task<Movie> Post([FromForm] IFormFile file)
        {
            if (ArbolInicialiado == true)
            {
                using var contenidoEnMemoria = new MemoryStream();
                await file.CopyToAsync(contenidoEnMemoria); //
                var contenido = Encoding.ASCII.GetString(contenidoEnMemoria.ToArray());
                var dato = JsonSerializer.Deserialize<List<Movie>>(contenido, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                foreach (var item in dato)
                {
                    Arbol.Insertar(item);
                }

            }


            return null;
        }

        //[HttpPost]
        //[Route("movies")]
        //public string PostMovies()
        //{
        //    var MoviesJson = new Movie()
        //    {
        //        Title = "Star Wars",
        //        Director = "Lucas ",
        //        Genre = "Science Fiction",
        //        ReleaseDate = DateTime.Now,
        //        ImdbRating = 5,
        //        RottenTomatoesRating = 1
        //    };

        //    var JsonMovies = JsonConvert.SerializeObject(MoviesJson);
        //    return JsonMovies;
        //}

    }
}