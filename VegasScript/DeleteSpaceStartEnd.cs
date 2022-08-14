using ScriptPortal.Vegas;

namespace DeleteSpaceStartEnd
{
    public partial class EntryPoint
    {
        public void FromVegas(Vegas vegas) 
        {
            Timecode trimLength = new Timecode("00:00:00:20");
            //Timecode trimLength = Timecode.FromMilliseconds(50000);
            //Timecode trimLength = Timecode.FromSeconds(50000);
            //Timecode trimLength = Timecode.FromFrames(50000);
            //Timecode trimLength = Timecode.FromPositionString("00:00:00:50");

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected)
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected && CurrentEvent.Length > (trimLength + trimLength))
                        {
                            CurrentEvent.ActiveTake.Offset += trimLength;
                            CurrentEvent.Length -= trimLength + trimLength;
                            CurrentEvent.Start += trimLength;
                        }
        }
    }
}