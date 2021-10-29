/**
 * Название: DeleteSpaceEnd.cs
 *    Автор: Дмитрий Чайник <chainick@narod.ru>
 *     Дата: 08.10.2012
 *   Версия: 0.0.1
 * Описание: Скрипт для каждого фрагмента выделенного трека удаляет 
 *           c конца заданное количество кадров (переменная DeleteSpaceEnd).
 **/


using System;
using System.IO;
using ScriptPortal.Vegas;

namespace DeleteSpaceEnd
{
    public class EntryPoint
    {

        Vegas myVegas = null;

        public void FromVegas(Vegas vegas)
        {
            myVegas = vegas;

            // удалить в конце фрагмента
            Timecode DeleteSpaceEnd = new Timecode("00:00:00:50");
            Timecode DeleteSpaceStart = new Timecode("00:00:00:50");


            // обход треков
            foreach (Track CurrentTrack in myVegas.Project.Tracks)
            {
                //если трек выделен
                if (true == CurrentTrack.Selected)
                {
                    int count = 0;

                    // обход фрагментов текущего трека
                    for (int i = 0; i < CurrentTrack.Events.Count; i++)
                    {
                        // текущий фрагмент
                        TrackEvent CurrentEvent = CurrentTrack.Events[i];

                        if (DeleteSpaceEnd + DeleteSpaceStart < CurrentEvent.Length)
                        {
                            CurrentEvent.ActiveTake.Offset += DeleteSpaceEnd;
                            CurrentEvent.Length -= DeleteSpaceEnd;

                            if (count > 0)
                            {
                                double Milliseconds = DeleteSpaceEnd.ToMilliseconds() * count;
                                CurrentEvent.Start -= Timecode.FromMilliseconds(Milliseconds);
                            }

                            count += 1;
                        }
                        else
                        {
                            if (i > 0)
                                CurrentEvent.Start = CurrentTrack.Events[i - 1].End;

                        }
                    }
                }
            }
        }
    }
}