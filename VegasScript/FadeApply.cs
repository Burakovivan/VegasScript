using ScriptPortal.Vegas;
//using VegasScript.Vegas;

namespace FadeApply
{
    public class EntryPoint
    {
        private class TransitionCostructor
        {
            public TransitionCostructor(Vegas vegas, string effectName, string effectPreset, Timecode length)
            {
                Vegas = vegas;
                EffectName = effectName;
                EffectPreset = effectPreset;
                Lenth = length;
            }
            public void ApplyTransition(Fade fade)
            {
                Effect sFlash = new Effect(Vegas.Transitions.GetChildByName(EffectName));
                fade.Transition = sFlash;
                sFlash.Preset = EffectPreset;
                fade.Length = Lenth;
            }

            public Vegas Vegas;
            public string EffectName;
            public string EffectPreset;
            public Timecode Lenth;
        }
        public void FromVegas(Vegas vegas)
        {
            var fade_In = new TransitionCostructor(vegas,
                                                  effectName: "Flash",
                                                  effectPreset: "Soft Flash",
                                                  length: Timecode.FromMilliseconds(1000));


            var fade_Out = new TransitionCostructor(vegas,
                                                  effectName: "Flash",
                                                  effectPreset: "Soft Flash",
                                                  length: Timecode.FromMilliseconds(1000));


            foreach (Track CurrentTrack in vegas.Project.Tracks)
                if (CurrentTrack.Selected)
                    foreach (var CurrentEvent in CurrentTrack.Events)
                        if (CurrentEvent.Selected)
                        {
                            fade_In.ApplyTransition(CurrentEvent.FadeIn);
                            fade_Out.ApplyTransition(CurrentEvent.FadeOut);
                        }
        }

    }
}