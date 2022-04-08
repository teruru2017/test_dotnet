using System.ComponentModel.DataAnnotations;

namespace octa_dotnet.DTOs.Airdrop
{
    public class AirdropRequest
    {
          public int? AirdropId { get; set; }

          [Required]
          [MaxLength(100, ErrorMessage = "no100")]
        public string? Account { get; set; }
        public int? BoxId { get; set; }
        public int? BoxType { get; set; }
        public int? Boxquota { get; set; }
       public List<IFormFile> FormFiles { get; set; }

       
    }
}