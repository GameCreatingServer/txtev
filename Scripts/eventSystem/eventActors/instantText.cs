using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class instantText : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string body = "";
            int fontSize = 0;
            Vector2 position = Vector2.zero;
            string identfier = "";

            try
            {
                body = args[0];
                fontSize = int.Parse(args[1]) * 2;
                identfier = args[3];
            }
            catch (System.IndexOutOfRangeException e)
            {
                consoleWriter.instance.throwError(
                    replError.EXECUTE_ERROR,
                    replError.executionError.argumentCountException,
                    evman.eventClasses[evman.currentEventIndex].inSrcLineNumber
                );
                Debug.Log(e);
            }
            catch (System.FormatException e)
            {
                consoleWriter.instance.throwError(
                    replError.EXECUTE_ERROR,
                    replError.executionError.argumentFormatException,
                    evman.eventClasses[evman.currentEventIndex].inSrcLineNumber
                );
                Debug.Log(e);
            }

            position = parseVect.str2Vec2(args[2]) * 2f;

            instantTextManager.instance.generateNewText(body, fontSize, position, identfier);

            yield return null;
            isDone = true;
        }
    }

    public class hideInstantText : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string identfier = args[0];

            instantTextManager.instance.DestroyText(identfier);

            yield return null;
            isDone = true;
        }
    }
}
