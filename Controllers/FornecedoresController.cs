using System.Collections.Generic;
using WebApiFornecedor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Net;

namespace WebApiFornecedor.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly Fornecedor _fornecedores;

        public FornecedoresController()
        {
            _fornecedores = new Fornecedor();

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_fornecedores.ListaFornecedores());
            }
            catch (Exception ex)
            {
                return null;
            }

        }
              

        [HttpGet("{id}")]
        //[Route("Recuperar/{id:int}/")]
        public Fornecedor Get(int id)
        {
            try
            {
                var fornec = _fornecedores.ListaFornecedores().Where(f => f.id == id).FirstOrDefault();
                if (fornec == null)
                {
                    return null;
                }
                return fornec;
            }
            catch (Exception ex)
            {
                return null;

            }           
        }

        //[HttpGet]
        //[Route(@"RecuperarPorDataEmpresa/{data:regex([0-9]{4}\-[0-9]{2}))/razaosocial:minlength(5)}")]
        //public IActionResult Recuperar(string data, string razaosocial)
        //{
        //    try
        //    {
        //        IEnumerable<Fornecedor> fornecedores = _fornecedores.ListaFornecedores().Where(x => x.data == data || x.razaosocial == razaosocial);
        //        if (!fornecedores.Any())
        //        {
        //            return NotFound();
        //        }

        //        return Ok(fornecedores);

        //    }
        //    catch (Exception ex)
        //    {
        //        return null; 

        //    }
        //}



        [HttpPost]
        public Fornecedor Post([FromBody] Fornecedor fornec){
            _fornecedores.InserirFornecedor(fornec);
            return fornec;
        }

        [HttpPut("{id}")]
        public Fornecedor Put(int id, [FromBody] Fornecedor fornec)
        {         
            _fornecedores.AtualizarFornecedor(id,fornec);
            return fornec;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _fornecedores.DeletarFornecedor(id);
        }
    }
}
