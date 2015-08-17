using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelatedTile.Urban10.Models
{
    /// <summary>
    /// Main Results List
    /// </summary>
    public class ResultsList
    {
        public int defid { get; set; }
        public string word { get; set; }
        public string author { get; set; }
        public string permalink { get; set; }
        public string definition { get; set; }
        public string example { get; set; }
        public int thumbs_up { get; set; }
        public int thumbs_down { get; set; }
        public string current_vote { get; set; }
    }
    /// <summary>
    /// Misc Results (Tags, Result Type, Sounds)
    /// </summary>
    public class UrbanResults
    {
        public List<string> tags { get; set; }
        public string result_type { get; set; }
        public List<ResultsList> list { get; set; }
        public List<object> sounds { get; set; }
    }
}
