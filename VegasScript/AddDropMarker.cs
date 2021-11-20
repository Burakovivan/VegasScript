/*
—брос таймкода фала из медиа пула по ссылке активного ивента(ов)
*/
using ScriptPortal.Vegas; 

namespace AddDropMarker
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