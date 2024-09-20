using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class ending : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            isDone = true;
            yield return null;
        }
    }
}
