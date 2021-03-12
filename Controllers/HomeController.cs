using Microsoft.AspNetCore.Mvc;


namespace WebApiFornecedor.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("home")]
        public string Home() => " API Fornecedores Iniciada . . . ";

    }
}
