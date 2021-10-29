/**
 * ��������: DeleteSpaceEnd.cs
 *    �����: ������� ������ <chainick@narod.ru>
 *     ����: 08.10.2012
 *   ������: 0.0.1
 * ��������: ������ ��� ������� ��������� ����������� ����� ������� 
 *           c ����� �������� ���������� ������ (���������� DeleteSpaceEnd).
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

            // ������� � ����� ���������
            Timecode DeleteSpaceEnd = new Timecode("00:00:00:50");
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