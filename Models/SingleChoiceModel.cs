namespace Recrutify.Models
{
    public class SingleChoiceModel
    {
        public int FID { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Antwort_1 { get; set; } = string.Empty;
        public string Antwort_2 { get; set; } = string.Empty;
        public string Antwort_3 { get; set; } = string.Empty;
        public string Antwort_4 { get; set; } = string.Empty;
        public string Richtig { get; set; } = string.Empty;
    }
}
