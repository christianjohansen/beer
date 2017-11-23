using System;
namespace beer
{
    public class Mash : Repeat
    {
        public int id { get; set; }
        public int recipe_id { get; set;  }
        public float temperature { get; set; }
        public int duration { get; set; }

        public int Duration()
        {
            return duration;
        }

        public override string ToString()
        {
            return "keep at " + temperature + " for " + duration + " minutes";
        }

    }


}



