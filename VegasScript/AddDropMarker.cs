/*
����� �������� ���� �� ����� ���� �� ������ ��������� ������(��)
*/
using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;

namespace DeleteSpaceStartEnd
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {

            var isMarkerRemoved = false;
            foreach (var marker in vegas.Project.Markers)
            {

                if (marker.Position == vegas.Cursor)
                {
                    vegas.Project.Markers.Remove(marker);
                    isMarkerRemoved = true;
                    break;
                }
            }
            if (!isMarkerRemoved)
            {
                vegas.Project.Markers.Add(new Marker(vegas.Cursor));
            }

        }
    }
}