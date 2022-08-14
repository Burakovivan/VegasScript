using VegasWrapper = ScriptPortal.Vegas.Vegas;
using ScriptPortal.Vegas;
using System.Collections.Generic;

namespace DeleteSpaceStartEnd
{
    public partial class EntryPoint
    {
        public void FromVegas(VegasWrapper vegas)
        {
            Timecode DeleteSpace = new Timecode("00:00:00:25");
            //Timecode DeleteSpace = Timecode.FromMilliseconds(50000);
            //Timecode DeleteSpace = Timecode.FromSeconds(50000);
            //Timecode DeleteSpace = Timecode.FromFrames(50000);
            //Timecode DeleteSpace = Timecode.FromPositionString("00:00:00:50");

            foreach (var currentEvent in GetEventListOnSelectedTrack(vegas))
            {
                RemoveSpaces(currentEvent, DeleteSpace);
            }
        }
        private IEnumerable<TrackEvent> GetEventListOnSelectedTrack(VegasWrapper vegas)
        {
            foreach (Track CurrentTrack in vegas.Project.Tracks)
            {
                if (CurrentTrack.Selected)
                {
                    foreach (var CurrentEvent in CurrentTrack.Events)
                    {
                        if (CurrentEvent.Selected)
                        {
                            yield return CurrentEvent;
                        }
                    }
                }
            }
        }

        private void RemoveSpaces(TrackEvent trackEvent, Timecode timecode)
        {
            if (timecode + timecode < trackEvent.Length)
            {
                trackEvent.ActiveTake.Offset += timecode;
                trackEvent.Length -= (timecode + timecode);
                trackEvent.Start += timecode;
            }
        }
    }
}