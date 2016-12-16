
namespace RENEGADES.Common
{
    //Time Formater, will turn 61.0f to 1:01
    public class TimeFormater
    {
        //Returns a custom string version of the value.
        public static string ToString_Time(float seconds)
        {
            string str = (int)(seconds / 60) + ":";

            if ((int)(seconds % 60) > 9) { str += (int)(seconds % 60); }

            else if ((int)(seconds % 60) == 0) { str += "00"; }

            else { str += "0" + (int)(seconds % 60); }

            return str;
        }
    }
}