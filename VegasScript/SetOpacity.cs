using ScriptPortal.Vegas;

namespace SetOpacity
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected)
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected)
                            CurrentEvent.FadeIn.Gain = 0.1f;
        }
    }
}