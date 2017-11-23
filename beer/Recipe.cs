using System;
using System.Collections.Generic;

namespace beer
{
    public class Recipe
    {
        public int id { get; set; }
        public int yeast_id { get; set; }
        public int brewer_id { get; set; }
        public int beerstyle_id { get; set; }
        public int volume { get; set; }
        public float efficiency { get; set; }
        public string mash_schedule { get; set; }
        public float boil_volume { get; set; }
        public int hop_util_model { get; set; }
        public string name { get; set; }
        public string added { get; set; }
        public float rating { get; set; }
        public string comment { get; set; }
        public string units { get; set; }
        public string brewer { get; set; }
        public Hop[] hop_used { get; set; }
        public Malt[] malt_used { get; set; }
        public string yeast { get; set; }
        public Ferment[] fermentation { get; set; }
        public string beerstyle { get; set; }

        public Mash[] mash { get; set; }

        public string weight_unit { get; set; } // 
        public string liquid_unit { get; set; } //
        public string temperature_unit { get; set; } // hmm

        public float total_malt_weight { get; set; }
        public float total_malt_gravity { get; set; }
        public float total_malt_colour { get; set; }
        public string colour_description { get; set; }
        public float total_bitterness { get; set; }
        public float final_gravity { get; set; }
        public float alcohol { get; set; }

        public override string ToString()
        {
            return "" + id;
        }

    
    
    }

}
