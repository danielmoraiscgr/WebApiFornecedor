using System.Collections.Generic;
using WebApiFornecedor.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiFornecedor.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        [HttpGet]
        public List<Fornecedor> Get()
        {
            Fornecedor Fornecedores = new Fornecedor();
            return Fornecedores.ListarFornecedores();
        }
    }
}
