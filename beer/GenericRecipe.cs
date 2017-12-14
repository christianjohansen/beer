using System;

namespace beer
{
    public class GenericRecipe
    {
        public static int page = 0;
        public static int sub_page = 0;
        public static Recipe recipe;
        public static Repeat[] repeat;
        public static bool isLast;

        public static string[] generic_recipe;

        public static Step GetStep() {
            if (page == 2 || page == 3 || page == 1 || page==10)
            {
                if (page == 2) repeat = recipe.mash;
                else if (page == 3) repeat = recipe.hop_used;
                else if (page == 1) repeat = recipe.malt_used;
                else if (page == 10) 

                System.Diagnostics.Debug.WriteLine("0:" + sub_page);
                System.Diagnostics.Debug.WriteLine("1:" + generic_recipe[page]);
                if (sub_page < repeat.Length) return new Step(generic_recipe[page].Replace("#subst#",repeat[sub_page].ToString()), repeat[sub_page++].Duration());
                else page++;
            }

            sub_page = 0;
            isLast = (page == generic_recipe.Length-1);
            return new Step(generic_recipe[page++],0);
        }

        public static void setRecipe(Recipe recipe)
        {
            GenericRecipe.recipe = recipe;
            // boil says how long hop should be in wort. But timer needs to know time before next hop should go in
            for (int a = 0; a < recipe.hop_used.Length - 1; a++)
            {
                recipe.hop_used[a].boil -= recipe.hop_used[a + 1].boil;
            }

            double temp = 68;
            if (recipe.units == "us") temp = temp * 1.8 + 32; // fahrenheit
            generic_recipe = new string[] { 
                "bring water to >"+temp+"°"+recipe.temperature_unit,
                "add malt\n\n#subst#.\n\ntemperature after adding malt\nshould be "+temp+"°"+recipe.temperature_unit, // resultinh temp should be 68 degrees C
                "steep & stear\n\n#subst#",
                "add muslin bag \nwith hops\n\n#subst#", // clearer
                "chill quickly to \nroom temperature",
                "remove hops",
                "into fermentor\n(you can have more \nsteps of fermenting/lagering)",
                "top up with water \napprox. 80% fill",
                "add yeast",
                "airlock",
                "wait for minimum 2 weeks",
                "add sugar solution \nto bottling bucket",
                "sugar and water \nboiled(boil till clear)",
                "into bottling bucket",
                "into bottles",
                "wait for 1-2 \nweeks before ready"
            };
        }

    }
}


/*
                "bring water to 65-77°",
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



    public class GenericRecipe
    {
        public static int page = 0;
        public static int sub_page = 0;
        public static Recipe recipe;
        public static Repeat[] repeat;
        public static bool isLast;

        public static string[] generic_recipe;

        public static Step GetStep() {
            if (page == 4 || page == 7 || page == 2)
            {
                if (page == 4) repeat = recipe.malt_used;
                else if (page == 7) repeat = recipe.hop_used;
                else if (page == 2) repeat = recipe.mash;

                if (sub_page < repeat.Length) return new Step(generic_recipe[page] + repeat[sub_page].ToString(), repeat[sub_page++].Duration());
                else page++;
            }

            sub_page = 0;
            System.Diagnostics.Debug.WriteLine(page+","+generic_recipe.Length);
            isLast = (page == generic_recipe.Length-1);
            return new Step(generic_recipe[page++],0);
        }

        public static void setRecipe(Recipe recipe)
        {
            GenericRecipe.recipe = recipe;
            // boil says how long hop should be in wort. But timer needs to know time before next hop should go in
            for (int a = 0; a < recipe.hop_used.Length - 1; a++)
            {
                recipe.hop_used[a].boil -= recipe.hop_used[a + 1].boil;
            }

            double temp = 68;
            if (recipe.units == "us") temp = temp * 1.8 + 32; 
            generic_recipe = new string[] { 
                "bring water to >"+temp+"°"+recipe.temperature_unit,
                "add grain in muslin bag.\ntemperature after adding grain\nshould be "+temp+"°"+recipe.temperature_unit, // resultinh temp should be 68 degrees C
                "",
                "remove grain water\nthrough grain",
                "add malt\n\n",
                "stear",
                "boil(wort)",
                "add muslin bag \nwith hops \n(you can have more hops)\nclearer\n\n",
                "chill quickly to \nroom temperature",
                "sanitize equipment",
                "remove hops",
                "into fermentor\n(you can have more \nsteps of fermenting/lagering)",
                "top up with water \napprox. 80% fill",
                "add yeast",
                "airlock",
                "wait for minimum 2 weeks",
                "add sugar solution \nto bottling bucket",
                "sugar and water \nboiled(boil till clear)",
                "into bottling bucket",
                "into bottles",
                "wait for 1-2 \nweeks before ready"
            };
        }

    }






*/


