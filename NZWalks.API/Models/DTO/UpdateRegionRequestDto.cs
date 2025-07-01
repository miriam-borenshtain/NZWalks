using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "The maxsimum lenght is 3 characters")]
        [MinLength(3, ErrorMessage = "The minimum lenght is 3 characters")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
