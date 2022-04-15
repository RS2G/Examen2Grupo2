using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Solicitud
{
    public class EditModel : PageModel
    {
        private readonly ISolicitudService solicitudService;
        private readonly IClienteService clienteService;
        private readonly IServicioService servicioService;

        public EditModel(ISolicitudService solicitudService, IClienteService clienteService, IServicioService servicioService)
        {
            this.solicitudService = solicitudService;
            this.clienteService = clienteService;
            this.servicioService = servicioService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public SolicitudEntity Entity {get; set;} = new SolicitudEntity();

        public IEnumerable<ClienteEntity> ClienteLista { get; set; } = new List<ClienteEntity>();
        public IEnumerable<ServicioEntity> ServicioLista { get; set; } = new List<ServicioEntity>();

        //Metodo OnGet
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await solicitudService.GetById(new()
                    {
                        IdSolicitud = id
                    });
                }
                ClienteLista = await clienteService.GetLista();
                ServicioLista = await servicioService.GetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        //Metodo OnPOst Actualizar e Insertar
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                if (Entity.IdSolicitud.HasValue)
                {
                    //Actualizar
                    result = await solicitudService.Update(Entity);
                }
                else
                {
                    //Insertar
                    result = await solicitudService.Create(Entity);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult( new DBEntity
                {
                    CodeError = ex.HResult,
                    MsgError = ex.Message
                } );
            }
        }


    }
}
