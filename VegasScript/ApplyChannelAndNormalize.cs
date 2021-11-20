 
using ScriptPortal.Vegas;

namespace ApplyChannelAndNormalize
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {


            /*
                None 
                DisableLeft - Left Only (оставит только правый)
                DisableRight - Right Only (оставит только левый)
            
                Use ChannelRemapping.XXXXX
             */
            var channelState = ChannelRemapping.DisableLeft;

             

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected && CurrentTrack.IsAudio())
                    foreach (AudioEvent CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected)
                        {
                            CurrentEvent.Channels = channelState;
                            CurrentEvent.Normalize = true;
                            
                            //раскоментировать если надо пересчитать нормализацию
                            //CurrentEvent.RecalculateNorm();
                        }
             
        }
    }
}