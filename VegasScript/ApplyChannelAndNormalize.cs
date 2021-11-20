 
using ScriptPortal.Vegas;

namespace ApplyChannelAndNormalize
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {


            /*
                None 
                DisableLeft - Left Only (������� ������ ������)
                DisableRight - Right Only (������� ������ �����)
            
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
                            
                            //���������������� ���� ���� ����������� ������������
                            //CurrentEvent.RecalculateNorm();
                        }
             
        }
    }
}