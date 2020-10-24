using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using presentacion.Models;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController: ControllerBase
    {
        private readonly PersonService personService;
        public SupportController(FirstParcialContext context)
        {
            personService = new PersonService(context);
        }


        [HttpGet]
        public ActionResult<decimal> Get()
        {
             SupportResponse response = personService.GetSumaSupport();
            if(response.Error) {
                BadRequest(response.Message);
            }
            return Ok(response.SumaSupport);
        }
        
    }
}