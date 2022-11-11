using Microsoft.AspNetCore.Mvc;
using Pagamento.Context;
using Pagamento.Models;

namespace Pagamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController: ControllerBase
    {

        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Registrar(Venda venda)
        {

            var vendaQt = venda.Itens.Count();
            if(vendaQt == 0)
                return BadRequest("A venda tem que possui pelo menos um item!");

            _context.Vendas.Add(venda);
            _context.SaveChanges();

            return Ok(venda);
        }

        [HttpGet("{id}")]
        public IActionResult Visualizar(int id)
        {
            var venda = _context.Vendas.Find(id);

            return Ok(venda);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(id);
            var vendaSt =(int) venda.Status;
            var vendaStB =(int) vendaBanco.Status;
            
            if((vendaStB == 1) && ((vendaSt == 2) || (vendaSt == 5)))
            {
                vendaBanco.Status = venda.Status;
                
            } else {
                if((vendaStB == 2) && ((vendaSt == 3) || (vendaSt == 5)))
                {
                    vendaBanco.Status = venda.Status;
                    
                } else {
                    if((vendaStB == 3) && ((vendaSt == 4)))
                    {
                        vendaBanco.Status = venda.Status;
                        
                    } else {
                        if(vendaSt >= 6)
                        {
                            return BadRequest("ERROR");
                        }else {
                        return BadRequest("Nao pode ser efetuado desse status para esse!");
                        }
                    }
                }
            }
            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);
            
        }
    }
}