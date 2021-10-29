using ScriptPortal.Vegas;

namespace DeleteSpaceStartEnd
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            Timecode DeleteSpaceEnd = new Timecode("00:00:00:20");
            Timecode DeleteSpaceStart = new Timecode("00:00:00:3");

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected)
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected && CurrentEvent.Length > (DeleteSpaceEnd + DeleteSpaceStart))
                        {
                            CurrentEvent.ActiveTake.Offset += DeleteSpaceStart;
                            CurrentEvent.Length -= DeleteSpaceEnd + DeleteSpaceStart;
                            CurrentEvent.Start += DeleteSpaceStart;
                        }
        }
    }
}