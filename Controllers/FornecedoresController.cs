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

        [HttpGet("id")]
        public Fornecedor Get(int id){
            Fornecedor _fornec = new Fornecedor(); 
            return _fornec.ListaFornecedores().Where( f => f.id == id).FirstOrDefault();
        }

        [HttpPost]
        public List<Fornecedor> Post(Fornecedor fornec){
            Fornecedor _fornec = new Fornecedor();
            _fornec.InserirFornecedor(fornec);
            return _fornec.ListaFornecedores();
        }

        [HttpPut]
        public void Put(int id, Fornecedor fornec)
        {
            Fornecedor _fornec = new Fornecedor(); 
            _fornec.AtualizarFornecedor(id, _fornec);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Fornecedor _fornec = new Fornecedor(); 
            _fornec.DeletarFornecedor(id);
        }
    }
}
