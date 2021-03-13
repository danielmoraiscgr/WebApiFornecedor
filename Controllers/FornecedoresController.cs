using System.Collections.Generic;
using WebApiFornecedor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApiFornecedor.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        [HttpGet]
        public List<Fornecedor> Get()
        {
            Fornecedor _fornecedores = new Fornecedor();
            return _fornecedores.ListaFornecedores();
        }

        [HttpGet("{id}")]
        public Fornecedor Get(int id){
            Fornecedor _fornec = new Fornecedor(); 
            var achouFornec = _fornec.ListaFornecedores().Where( f => f.id == id).FirstOrDefault();
            if (achouFornec==null){
                return null;
            }
            return achouFornec;
        }

        [HttpPost]
        public Fornecedor Post([FromBody] Fornecedor fornec){
            Fornecedor _fornec = new Fornecedor();
            _fornec.InserirFornecedor(fornec);
            return fornec;
        }

        [HttpPut("{id}")]
        public Fornecedor Put(int id, [FromBody] Fornecedor fornec)
        {
            Fornecedor _fornec = new Fornecedor(); 
            
            _fornec.AtualizarFornecedor(id,fornec);
            return fornec;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Fornecedor _fornec = new Fornecedor(); 
            _fornec.DeletarFornecedor(id);
        }
    }
}
