using ScriptPortal.Vegas;
using System.Collections.Generic;
//using VegasScript.Vegas;

namespace GrabAllVideoToSingleTrack
{
    public class EntryPoint
    {

        public void FromVegas(Vegas vegas)
        {
            var videoTrack = new VideoTrack(vegas.Project, 0, "Grabbed Video") as Track;
            var audioTrack = new AudioTrack(vegas.Project, 1, "Grabbed Audio") as Track;
            vegas.Project.Tracks.Add(videoTrack);
            vegas.Project.Tracks.Add(audioTrack);

            var tracksToRemoveList = new List<Track>();

            var grouppingDict = new Dictionary<long, List<TrackEvent>>();

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected && CurrentTrack.Index != videoTrack.Index)
                {
                    Track trackToCopy = CurrentTrack.IsVideo() ? videoTrack : audioTrack;
                    foreach (var CurrentEvent in CurrentTrack.Events)
                    {
                        var copiedEvent = CurrentEvent.Copy(trackToCopy, CurrentEvent.Start);
                        var startKey = copiedEvent.Start.FrameCount;
                        if (!grouppingDict.ContainsKey(startKey))
                        {
                            grouppingDict.Add(startKey, new List<TrackEvent>());
                        }
                        grouppingDict[startKey].Add(copiedEvent);
                    }

                    tracksToRemoveList.Add(CurrentTrack);
                }

            foreach (var trackToRemove in tracksToRemoveList)
            {
                vegas.Project.Tracks.Remove(trackToRemove);
            }
            foreach (var group in grouppingDict)
            {
                var eventGRoup = new TrackEventGroup(vegas.Project);
                vegas.Project.TrackEventGroups.Add(eventGRoup);
                foreach (var trackEvent in group.Value)
                {
                    eventGRoup.Add(trackEvent);
                }
            }
        }

    }
}