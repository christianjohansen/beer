using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.MediaManager;

namespace beer
{
    public class EggWatch
    {
        public static int seconds;
        public static string function;
        public static Button button;
        public static bool running;

        public static void setWatch(int minutes, Button button) {
            EggWatch.seconds = 60 * minutes;
            EggWatch.button = button;
            running = false;
            function = "";
            if ( minutes > 0 ) button.BackgroundColor = Color.FromHex("aaf4a200");

            DisplayWatch();
        }

        public static async void Trigger()
        {
            if ( !running )
            {
                running = true;
                function = "";
                button.BackgroundColor = Color.FromHex("aa07800a");//  aa1960aa
                while ( running && seconds > 0 )
                {
                    seconds--;
                    DisplayWatch();
                    await Task.Delay(1000);
                }
                if ( seconds == 0 )
                {
                    button.BackgroundColor = Color.FromHex("aa850909");
                    await CrossMediaManager.Current.Play("https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3"); // change taack or to alarm
                }
            }
            else if ( function == "" && seconds > 0 ) {
                running = false;
                function = "paused";
                DisplayWatch();
            }
            else if ( seconds == 0 && running ) {
                CrossMediaManager.Current.PlaybackController.Stop();
            }
        }

        public static void DisplayWatch()
        {
            int m = (int)Math.Floor((double)(seconds / 60));
            int s = ((seconds - 60 * m) + 100);
            button.Text = "" + m + ":" + s.ToString().Substring(1,2) + " " + function;
        }
    }
}
