using System;
using System.Collections.Generic;

namespace FullWebApp.Models
{
    public class Quest
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Difficulty { get; set; }
        public int Reward { get; set; }
    }
}
