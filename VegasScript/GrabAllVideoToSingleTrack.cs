using ScriptPortal.Vegas;
//using VegasScript.Vegas;

namespace GrabAllVideoToSingleTrack
{
    public class EntryPoint
    {

        public void FromVegas(Vegas vegas)
        {
            var videoTrack = vegas.Project.AddVideoTrack();
            videoTrack.Name = "Grabbed";

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.IsVideo() && CurrentTrack.Index != videoTrack.Index)
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected)
                        {
                            CurrentEvent.Copy(videoTrack, CurrentEvent.Start);
                        }
        }

    }
}