using System;
namespace beer
{
    public class Ferment : Repeat
    {
        public int id { get; set; }
        public string fermentation_type { get; set; }
        public int temperature { get; set; }
        public int duration { get; set; }
        public int recipe_id { get; set; }

        public int Duration()
        {
            return duration;
        }

        public override string ToString()
        {
            return "ferment";
        }
   
    }


}
