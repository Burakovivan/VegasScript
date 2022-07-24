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

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected && CurrentTrack.Index != videoTrack.Index)
                {
                    Track trackToCopy = CurrentTrack.IsVideo() ? videoTrack as Track : audioTrack;
                    foreach (var CurrentEvent in CurrentTrack.Events)
                    { 
                        CurrentEvent.Copy(trackToCopy, CurrentEvent.Start);
                    }  

                    tracksToRemoveList.Add(CurrentTrack);
                }

            foreach (var trackToRemove in tracksToRemoveList)
            {
                vegas.Project.Tracks.Remove(trackToRemove);
            }
        }

    }
}