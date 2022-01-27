using GuitarRental.Filters;
using GuitarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarRental.Controllers
{
    [Route("api/guitars")]
    public class RestGuitarController : Controller
    {
        private ICRUDGuitarRepository guitars;

        public RestGuitarController(ICRUDGuitarRepository guitars)
        {
            this.guitars = guitars;
        }

        [HttpGet]
        [DisableBasicAuthentication]
        public IList<Guitar> GetGuitars()
        {
            return guitars.FindAll();
        }

        [HttpGet]
        [Route("{id}")]
        [DisableBasicAuthentication]
        public ActionResult Get(int id)
        {
            Guitar guitar = guitars.FindById(id);
            if (guitar != null)
            {
                return new OkObjectResult(guitar);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                Guitar _guitar = guitars.Add(guitar);
                return new CreatedResult($"/api/guitars/{_guitar.GuitarId}", guitar);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var delete = guitars.FindById(id);

            if (delete == null)
            {
                return NotFound($"Gitara z id = {id} nie znaleziona.");
            }
            else
            {
                guitars.Delete(id);
                return Ok($"Gitara o id = {id} została usunięta");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit([FromBody] Guitar guitar, int id)
        {
            if (id != guitar.GuitarId)
                return BadRequest("Nie znaleziono powiązania id");
            var update = guitars.FindById(id);

            if (update == null)
                return NotFound();
            else
            {
                guitars.Update(guitar);
            }

            return Ok();
        }
    }
}
