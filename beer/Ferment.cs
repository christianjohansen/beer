using System;
namespace beer
{
    public class Ferment
    {
        public int id { get; set; }
        public string fermentation_type { get; set; }
        public int temperature { get; set; }
        public int duration { get; set; }
        public int recipe_id { get; set; }
    }
}
