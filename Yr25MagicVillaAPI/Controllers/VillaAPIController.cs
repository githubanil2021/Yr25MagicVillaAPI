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

        private readonly ILogger<VillaAPIController> _logger;
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Getting all vilas");
            return Ok(_db.Villas.ToList());
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(200, Type=typeof(VillaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult  GetVilla(int id)
        { 
            
             if (id == 0)
                return BadRequest();

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
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

            //villaDTO.Id= _db.Villas.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id=villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };
            
            _db.Villas.Add(model);
            _db.SaveChanges();

 
            return CreatedAtRoute("GetVilla", new {id=villaDTO.Id}, villaDTO);

        }


        [HttpDelete("{id:int}", Name ="DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
                return BadRequest();

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
                return NotFound();

            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();

        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villaDTO)
        {
            if(villaDTO==null || id!=villaDTO.Id)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);

            //villa.Name=villaDTO.Name;
            //villa.Occupancy=villaDTO.Occupancy;
            //villa.Sqft=villaDTO.Sqft;

            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id ==0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

            VillaDTO villaDTO = new()
            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                Name = villa.Name,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft
            };

            if (villa == null )
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(villaDTO, ModelState);
            Villa model = new Villa()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft

            };
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();

        }
    }
    }
