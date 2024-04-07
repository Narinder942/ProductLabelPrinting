namespace ProductLabelPrinting.Models.Common
{
    public class ResponseReturn
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Response { get; set; }
    }
}