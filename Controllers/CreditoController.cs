using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using APICredito.Classes;

namespace APICredito2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        [HttpPost]
        public Credito Post(SolicitacaoCredito solicitacao)
        {
            Credito credito = solicitacao.validarTipoCredito();

            return credito;
        }
    }
}