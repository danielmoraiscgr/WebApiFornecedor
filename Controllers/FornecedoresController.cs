using System.Collections.Generic;
using WebApiFornecedor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            return Ok(_fornecedores.ListaFornecedores());         
        }

        [HttpGet("{id}")]
        public Fornecedor Get(int id)
        {
            var fornec = _fornecedores.ListaFornecedores().Where( f => f.id == id).FirstOrDefault();
            if (fornec ==null){
                return null;
            }
            return fornec;
        }

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
