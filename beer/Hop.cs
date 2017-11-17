using System;
namespace beer
{
    public class Hop
    {
        public int id { get; set; }
        public int recipe_id { get; set; }
        public int hop_id { get; set; }
        public float weight { get; set; }
        public int boil { get; set; }
        public string name { get; set; }
        public float alpha { get; set; }
        public float utilisation { get; set; }
        public float bitterness { get; set; }
    }
}
