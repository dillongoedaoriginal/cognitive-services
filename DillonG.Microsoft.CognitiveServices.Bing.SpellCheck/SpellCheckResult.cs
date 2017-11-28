using System;

namespace DillonG.Microsoft.CognitiveServices.Bing.SpellCheck
{
    public class SpellCheckResult
    {
        public Flaggedtoken[] flaggedTokens { get; set; }

        public SpellCheckResult()
        {
            flaggedTokens = Array.Empty<Flaggedtoken>();
        }
    }

}
