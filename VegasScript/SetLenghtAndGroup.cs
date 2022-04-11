using ScriptPortal.Vegas;

namespace SetLenghtAndGroup
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            Timecode Length = Timecode.FromSeconds(4.1);

            Timecode previousEnd = Timecode.FromFrames(0);


            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected && CurrentTrack.IsVideo())
                    foreach (var CurrentEvent in CurrentTrack.Events)
                    {


                        CurrentEvent.Start = previousEnd;
                        previousEnd = CurrentEvent.End;
                        CurrentEvent.Length = Length + Timecode.FromSeconds(0.5);
                    }
        }
    }
}