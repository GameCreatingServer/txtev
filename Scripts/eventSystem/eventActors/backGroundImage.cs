using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class setBGI : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string spriteIdentifier = args[0];

            Sprite sprite = backgroundImageDataBase.instance.getSprite(spriteIdentifier);
            if (sprite != null)
            {
                backGroundImageClass.instance.setSprite(sprite);
            }

            isDone = true;
            yield return null;
        }
    }
}
