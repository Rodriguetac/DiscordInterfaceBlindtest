using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents.DocumentStructures;

namespace DiscordInterfaceBlindtest.Models
{

    public class BlindtestItem
    {
        public bool IsFind { get; set; } = false;
        public List<string> answers { get; set; }
        public string url { get; set; }
        public BlindtestItem(string url, string answer)
        {
            this.url = url;
            this.answers.Add(answer);
        }
    }
}
