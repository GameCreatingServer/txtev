using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class debugLog : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            Debug.Log(args[0]);
            isDone = true;
            yield return null;
        }
    }
}
