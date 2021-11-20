/*
—брос таймкода фала из медиа пула по ссылке активного ивента(ов)
*/
using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;

namespace DropAudioEvent
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {

            var eventToRemoveList = new List<Tuple<Track, TrackEvent>>();

            foreach (Track CurrentTrack in vegas.Project.Tracks)
                foreach (var CurrentEvent in CurrentTrack.Events)
                    if (CurrentEvent.IsAudio() && CurrentEvent.Selected)
                        eventToRemoveList.Add(new Tuple<Track, TrackEvent>(CurrentTrack, CurrentEvent));


            foreach (var eventToRemove in eventToRemoveList)
                eventToRemove.Item1.Events.Remove(eventToRemove.Item2);

        }
    }
}