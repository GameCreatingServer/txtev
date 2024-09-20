using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public abstract class eventActor
    {
        public bool isDone = false;
        public abstract IEnumerator execute(eventManager evman, string[] args);
    }
}
