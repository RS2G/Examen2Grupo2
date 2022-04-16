using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;
namespace WebApp.Pages.Cliente
{
    public class EditModel : PageModel
    {
        private readonly IClienteService clienteService;
        
        public EditModel(IClienteService clienteService)
        {
            this.clienteService = clienteService;
           
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ClienteEntity Entity { get; set; } = new ClienteEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await clienteService.GetById(new()
                    {
                        IdCliente = id
                    });
                }
                
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                if (Entity.IdCliente.HasValue)
                {
                    result = await clienteService.Update(Entity);

                }
                else
                {   //Metodo de Inserción
                    result = await clienteService.Create(Entity);

                }


                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity
                { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}