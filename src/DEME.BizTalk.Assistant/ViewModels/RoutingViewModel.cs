using System.ComponentModel.DataAnnotations;
namespace DEME.BizTalk.Assistant.Models
{
    public class RoutingViewModel
    {
        public int Id { get; set; }

        [Required]
        public BusinessProcess Source { get; set; }

        [Required]
        [Display(Name = "Type of change")]
        public string ChangeType { get; set; }

        [Required]
        public BusinessProcess Destination { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
