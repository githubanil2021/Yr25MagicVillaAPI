using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Yr25MagicVillaAPI.Data;
using Yr25MagicVillaAPI.Models;
using Yr25MagicVillaAPI.Models.DTO;

namespace Yr25MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
         
        //public IEnumerable<Villa> GetVillas()
        //{
        //    return new List<Villa> {
        //          new Villa { Id=1, Name="PoolView"},
        //           new Villa { Id = 2, Name = "BeachView" }
        //    };

        //}
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);

        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(200, Type=typeof(VillaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult  GetVilla(int id)
        { 
            
             if (id == 0)
                return BadRequest();

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
                return NotFound();

            return Ok(villa);

        }

        [HttpPost]
        public ActionResult CreateVilla([FromBody]VillaDTO villaDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
             
            if (villaDTO == null)
                return BadRequest(villaDTO);

            if(villaDTO.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDTO.Id= VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            VillaStore.villaList.Add(villaDTO);

 
            return CreatedAtRoute("GetVilla", new {id=villaDTO.Id}, villaDTO);

        }


        [HttpDelete("{id:int}", Name ="DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
                return BadRequest();

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);

            if (villa == null)
                return NotFound();

            VillaStore.villaList.Remove(villa);
            return NoContent();

        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villaDTO)
        {
            if(villaDTO==null || id!=villaDTO.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);

            villa.Name=villaDTO.Name;
            villa.Occupancy=villaDTO.Occupancy;
            villa.Sqft=villaDTO.Sqft;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id ==0)
            {
                return BadRequest();
            }

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null )
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return NoContent();

        }
    }
    }
