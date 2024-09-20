using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class setSI : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string imageIdentifier = "";
            string stantImageIdentiier = "";

            try
            {
                imageIdentifier = args[0];
                stantImageIdentiier = args[1];
            }
            catch (System.IndexOutOfRangeException)
            {
                consoleWriter.instance.throwError(
                    replError.EXECUTE_ERROR,
                    replError.executionError.argumentCountException,
                    evman.eventClasses[evman.currentEventIndex].inSrcLineNumber
                );
            }
            catch (System.FormatException)
            {
                consoleWriter.instance.throwError(
                    replError.EXECUTE_ERROR,
                    replError.executionError.argumentFormatException,
                    evman.eventClasses[evman.currentEventIndex].inSrcLineNumber
                );
            }

            Sprite sprite = talkCharaDBinstance.instance.getSprite(stantImageIdentiier);
            if (sprite != null)
            {
                standImagesController.instance.setSprite(imageIdentifier, sprite);
            }
            else
            {
                consoleWriter.instance.throwError(
                    replError.READ_ERROR,
                    replError.readError.noSuchSprite + ": " + stantImageIdentiier,
                    evman.eventClasses[evman.currentEventIndex].inSrcLineNumber
                );
            }

            isDone = true;
            yield return null;
        }
    }

    public class setSIVisible : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string imageIdentifier = args[0];
            bool visible = bool.Parse(args[1]);
            standImagesController.instance.setVisible(imageIdentifier, visible);

            isDone = true;
            yield return null;
        }
    }

    public class setSITrigger : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string imageIdentifier = args[0];
            string triggerIdentifier = args[1];

            standImagesController.instance.setTrigger(imageIdentifier, triggerIdentifier);

            isDone = true;
            yield return null;
        }
    }
}
