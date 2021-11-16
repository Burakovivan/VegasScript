/*
—брос таймкода фала из медиа пула по ссылке активного ивента(ов)
*/
using ScriptPortal.Vegas;

namespace DeleteSpaceStartEnd
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {


            var timeCodeToSet = Timecode.FromPositionString("00:00:00:00");

            //true - сработает только на выделенных 
            //false - сработает на выделенных или на всех если нет выделенных
            var applyForSelectedOnly = true;




            uint SelectedMediaId = 0;

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected)
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected)
                        {
                            SelectedMediaId = CurrentEvent.ActiveTake.Media.MediaID;
                        }

            foreach (Media bin in vegas.Project.MediaPool)
            {
                if (SelectedMediaId != 0)
                {
                    if (bin.MediaID == SelectedMediaId)
                    {
                        bin.UseCustomTimecode = true;
                        bin.TimecodeIn = timeCodeToSet;
                    }

                }
                else if (!applyForSelectedOnly)
                {

                    bin.UseCustomTimecode = true;
                    bin.TimecodeIn = timeCodeToSet;
                }
            }
        }
    }
}