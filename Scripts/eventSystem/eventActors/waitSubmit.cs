using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class waitSubmit : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
            isDone = true;
        }
    }
}
