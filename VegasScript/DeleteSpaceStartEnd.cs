using System.Collections.Generic;
using ScriptPortal.Vegas;

namespace DeleteSpaceEnd
{
    public class EntryPoint
    {

        private Vegas myVegas { get; set; }

        public void FromVegas(Vegas vegas)
        {
            myVegas = vegas;

            Timecode DeleteSpaceEnd = new Timecode("00:00:00:20");
            Timecode DeleteSpaceStart = new Timecode("00:00:00:3");


            foreach (Track CurrentTrack in myVegas.Project.Tracks)
            {
                if (CurrentTrack.Selected)
                {
                    int count = 0;

                    var distanceSet = new List<Timecode>();
                    for (int i = 1; i < CurrentTrack.Events.Count; i++)
                    {
                        distanceSet.Add(CurrentTrack.Events[i].Start - CurrentTrack.Events[i - 1].End);
                    }

                    for (int i = 0; i < CurrentTrack.Events.Count; i++)
                    {
                        TrackEvent CurrentEvent = CurrentTrack.Events[i];
                        if (CurrentEvent.Selected)
                        {

                            if (CurrentEvent.Length > (DeleteSpaceEnd + DeleteSpaceStart))
                            {
                                CurrentEvent.ActiveTake.Offset += DeleteSpaceStart;
                                CurrentEvent.Length -= DeleteSpaceEnd + DeleteSpaceStart;

                                if (count > 0)
                                {
                                    double Milliseconds = (DeleteSpaceStart).ToMilliseconds() * count;
                                    CurrentEvent.Start += Timecode.FromMilliseconds(Milliseconds);
                                }

                                count++;
                            }
                            //else
                            //{
                            //    if (i > 0)
                            //        CurrentEvent.Start = CurrentTrack.Events[i - 1].End + distanceSet[i];

                            //}
                        }
                    }
                }
            }
        }
    }
}