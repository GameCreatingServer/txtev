using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    [System.Serializable]
    public class eventSequence
    {
        public eventClass[] events;
        public List<Vector2Int> jumps;

        public eventSequence(eventClass[] events, List<Vector2Int> jumps)
        {
            this.events = events;
            this.jumps = jumps;
        }
    }
}
