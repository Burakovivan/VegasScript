/*
—брос таймкода фала из медиа пула по ссылке активного ивента(ов)
*/
using ScriptPortal.Vegas;

namespace MoveCursor
{ 
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {



            //FromNanos(long nanos);
            //FromMilliseconds(double milliseconds);
            //FromSeconds(double seconds);  
            //FromFrames(long frames);
            //FromPositionString(string timestamp); 
            var moveLength = Timecode.FromFrames(5);

            // true = Right, false = Left
            var isForward = true;


            vegas.Cursor += Timecode.FromNanos(moveLength.Nanos * (isForward ? 1 : -1));

        }
    }
}