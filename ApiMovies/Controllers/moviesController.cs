using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArbolMulticamino;
using ApiMovies.Models;

namespace ApiMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moviesController : ControllerBase
    {

        static ArbolMultiCamino<Movie> Arbol;
        static bool ArbolInicialiado = false;

        [HttpPost]
        public string InicializarArbol(int order)
        {
            var mensaje = "ArbolInicializado";
            Arbol = new ArbolMultiCamino<Movie>(order);
            ArbolInicialiado = true;
            return mensaje;
        }
        

    }
}