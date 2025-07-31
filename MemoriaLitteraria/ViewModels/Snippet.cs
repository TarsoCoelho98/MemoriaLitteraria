using MemoriaLitteraria.Models;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace MemoriaLitteraria.ViewModels
{
    public class Snippet
    {
        public Guid LocalGuid { get; }
        public Section Section { get; }
        public Models.File File { get; }
        public Author Author { get; }
        [JsonIgnore]
        public string Search { get; }
        public bool MatchByStem { get; private set; } = false;
        public string ShortContent { get; private set; }

        public Snippet(Models.File file, Section section, Author author, string search)
        {
            File = file;
            Section = section;
            Author = author;
            Search = search;
            LocalGuid = Guid.NewGuid();
            ShortContent = GetShortContent();
        }

        private string GetShortContent()
        {
            var separatorCharacters = new char[] { '.', '?', '!' };
            string pattern = $@"(?<=[{Regex.Escape(new string(separatorCharacters))}])";
            var phrases = Regex.Split(Section.Content, pattern).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();


            for (var i = 0; i < phrases.Length; i++)
            {
                if (phrases[i].Contains(Search, StringComparison.OrdinalIgnoreCase))
                {
                    if (phrases[i].StartsWith("\\n") || phrases[i].StartsWith("\n"))
                        phrases[i] = phrases[i].Replace("\\n", string.Empty).Replace("\n", string.Empty).Trim();
                    
                    return phrases[i].Trim();
                }
            }

            MatchByStem = true;
            return "Correspondência por radicalização — leia para localizar o trecho exato.";
        }
    }
}

