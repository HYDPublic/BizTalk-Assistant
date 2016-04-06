namespace DEME.BizTalk.Assistant.Models
{
    public class RoutingViewModel
    {
        public int Id { get; set; }
        public BusinessProcess Source { get; set; }
        public string ChangeType { get; set; }
        public BusinessProcess Destination { get; set; }
        public bool Active { get; set; }
    }
}
