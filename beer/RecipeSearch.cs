using System;
namespace beer
{
    public class RecipeSearch
    {
        public static string[] colors = { "#ffffffff", "#fffafafa" };
        public static string[] filterarray = { "", "", "B", "", "M", "", "", "", "H", "", "", "", "", "", "", "", "Y" };

        public int id { get; set; }
        public string name { get; set; }
        public int filter { get; set; }
        public string backgroundcolor { get; set; }
        public string[] filter2string { get; set; }

        public RecipeSearch setFormat(string color)
        {
            filter2string = new String[5];
            backgroundcolor = color;
            for (int a = 0; a < 5; a++) filter2string[a] = RecipeSearch.filterarray[filter & (int)Math.Pow(2, a)];

            return this;
        }


    }


}
