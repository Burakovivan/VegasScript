using VegasWrapper = ScriptPortal.Vegas.Vegas;
using ScriptPortal.Vegas; 

namespace AddReverb
{
    public partial class EntryPoint
    {
        public void FromVegas(VegasWrapper vegas)
        {

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected && CurrentTrack.IsAudio())
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected)
                        {
                            Effect reverbEffect = new Effect(vegas.PlugIns.FindChildByName("Reverb"));
                            (CurrentEvent as AudioEvent).Effects.Add(reverbEffect);
                            reverbEffect.Preset = "AABBCC";
                        }

        }
    }
}