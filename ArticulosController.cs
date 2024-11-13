using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorio;
using ArticulosAPI.Dto;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        //Todas las funciones pasan a repositorio por lo que ya no se llama a iRepositorio sino a irepositorio
        // antes   private readonly iRepositorio _repositorio;
        private readonly iRepositorio _repositorio;
        //cambiar contex por repositorio
        public ArticulosController(iRepositorio context)
        {
            _repositorio = context;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDto>>> GetArticulos()
        {
            return await _repositorio.GetArticulo();
            //repositorio.getarticulo
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDto>> GetArticulo(int id)
        {
            var articulo = await _repositorio.GetArticulo(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ArticuloDto>> PutArticulo(int id, ArticuloDto articulo)
        {
           return await _repositorio.CrearOActualizar(articulo , id);
        }

        // POST: api/Articulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticuloDto>> PostArticulo(ArticuloDto articulo)
        {
            return await _repositorio.CrearOActualizar(articulo);

        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteArticulo(int id)
        {
            return await _repositorio.EliminarArticulo(id);
        }

    }
}
