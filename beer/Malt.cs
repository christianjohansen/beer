using System;
namespace beer
{
    public class Malt : Repeat
    {
        public int id { get; set; }
        public int recipe_id { get; set; }
        public int malt_id { get; set; }
        public float weight { get; set; }
        public string name { get; set; }
        public float gravity_factor { get; set; }
        public float ebc { get; set; }
        public int nomash { get; set; }
        public float gravity { get; set; }
        public float colour { get; set; }
        public float percent { get; set; }

        public int Duration()
        {
            return 0;
        }

        public override string ToString()
        {
            return name + "\n\n" + weight + " " + GenericRecipe.recipe.weight_unit;
        }

    }


}
