using VegasWrapper = ScriptPortal.Vegas.Vegas;
using ScriptPortal.Vegas; 

namespace DeleteSpaceStartEnd
{
    public partial class EntryPoint
    {
        public void FromVegas(VegasWrapper vegas)
        {
            Timecode DeleteSpaceEnd = Timecode.FromPositionString("00:00:00:20");
            Timecode DeleteSpaceStart = Timecode.FromPositionString("00:00:00:03");

            Timecode Shift = Timecode.FromMilliseconds(10);

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected)
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected && CurrentEvent.Length > (DeleteSpaceEnd + DeleteSpaceStart))
                        {
                            CurrentEvent.ActiveTake.Offset += DeleteSpaceStart;
                            CurrentEvent.Length -= DeleteSpaceEnd + DeleteSpaceStart;
                            CurrentEvent.Start += DeleteSpaceStart + Shift;
                        }  

        }
    }
}