using System.ComponentModel.DataAnnotations;

namespace Yr25MagicVillaAPI.Models.DTO
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }

        [Required]
        public int VillaId { get; set; }

        public string SpecialDetails { get; set; }

        public VillaDTO Villa { get; set; }

         


    }
}
