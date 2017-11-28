namespace DillonG.Microsoft.CognitiveServices.Bing.SpellCheck
{
    public class Flaggedtoken
    {
        public int offset { get; set; }
        public string token { get; set; }
        public string type { get; set; }
        public Suggestion[] suggestions { get; set; }
    }

}
