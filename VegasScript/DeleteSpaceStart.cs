/**
 * ��������: DeleteSpaceStart.cs
 *    �����: ������� ������ <chainick@narod.ru>
 *     ����: 07.09.2012
 *   ������: 0.0.1
 * ��������: ������ ��� ������� ��������� ����������� ����� ������� 
 *           �������� ���������� ������ (���������� DeleteSpaceStart).
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

            // ������� � ������ ���������
            Timecode DeleteSpaceStart = new Timecode("00:00:00:50");


            // ����� ������
            foreach (Track CurrentTrack in myVegas.Project.Tracks)
            {
                //���� ���� �������
                if (true == CurrentTrack.Selected)
                {
                    int count = 0;

                    // ����� ���������� �������� �����
                    for (int i = 0; i < CurrentTrack.Events.Count; i++)
                    {
                        // ������� ��������
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