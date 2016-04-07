using System.ComponentModel.DataAnnotations;

namespace DEME.BizTalk.Assistant.Models
{
    public class BusinessProcessViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Source { get; set; }

        [Required]
        public string Process { get; set; }

        [Required]
        public string Destination { get; set; }
    }
}
