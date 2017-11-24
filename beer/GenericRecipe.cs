using System;

namespace beer
{
    public class GenericRecipe
    {
        public static int page = 0;
        public static int sub_page = 0;
        public static Recipe recipe;
        public static Repeat[] repeat;

        public static string[] generic_recipe = {
            "bring water to 65-77 degrees celsius.",
            "add grain in muslin bag.\n\n", // resultinh temp should be 68 degrees C
            "",
            "remove grain water through grain",
            "add malt\n\n",
            "stear",
            "boil(wort)",
            "add muslin bag with hops 60min (you can have more hops)\nclearer\n\n",
            "chill quickly to room temperature - lunken",
            "sanitize equipment",
            "remove hops",
            "into fermentor(you can have more steps of fermenting/lagering)",
            "top up with water approx. 80% fill",
            "add yeast",
            "airlock",
            "wait for minimum 2 weeks",
            "add sugar solution to bottling bucket",
            "sugar and water boiled(boil till clear)",
            "into bottling bucket",
            "into bottles",
            "wait for 1-2 weeks before ready"

        };

        public static Step GetStep() {
            if (page == 4 || page == 7 || page == 2)
            {
                if (page == 4) repeat = recipe.malt_used;
                else if (page == 7) repeat = recipe.hop_used;
                else if (page == 2) repeat = recipe.mash;
    
                if ( sub_page < repeat.Length ) return new Step(generic_recipe[page] + repeat[sub_page].ToString(),repeat[sub_page++].Duration());
                else page++;
            }

            sub_page = 0;
            return new Step(generic_recipe[page++],0);
        }

        public static void setRecipe(Recipe recipe) {
            GenericRecipe.recipe = recipe;
            // boil says how long hop should be in wort. But timer needs to know time before next hop should go in
            for (int a = 0; a < recipe.hop_used.Length - 1; a++)
            {
                recipe.hop_used[a].boil -= recipe.hop_used[a + 1].boil;
            }
        }
    }
}
