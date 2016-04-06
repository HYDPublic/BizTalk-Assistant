namespace DEME.BizTalk.Assistant.Models
{
    public class Routing
    {
        public int Id { get; set; }
        public BusinessProcess Source { get; set; }
        public BusinessProcess Destination { get; set; }
        public bool Active { get; set; }
    }
}
