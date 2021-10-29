/**
 * Название: DeleteSpaceStart.cs
 *    Автор: Дмитрий Чайник <chainick@narod.ru>
 *     Дата: 07.09.2012
 *   Версия: 0.0.1
 * Описание: Скрипт для каждого фрагмента выделенного трека удаляет 
 *           заданное количество кадров (переменная DeleteSpaceStart).
 **/


using System;
using System.IO;
using ScriptPortal.Vegas;

namespace DeleteSpaceStart
{

    public class EntryPoint
    {

        ScriptPortal.Vegas.Vegas myVegas = null;

        public void FromVegas(Vegas vegas)
        {
            myVegas = vegas;

            // удалить в начале фрагмента
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

                        if (DeleteSpaceStart < CurrentEvent.Length)
                        {
                            CurrentEvent.ActiveTake.Offset += DeleteSpaceStart;
                            CurrentEvent.Length -= DeleteSpaceStart;

                            if (count > 0)
                            {
                                double Milliseconds = DeleteSpaceStart.ToMilliseconds() * count;

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