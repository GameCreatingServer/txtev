using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class textWindow : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string chara = "";
            string text = "";

            try
            {
                chara = args[0];
                text = args[1];
            }
            catch (System.IndexOutOfRangeException e)
            {
                consoleWriter.instance.throwError(
                    replError.EXECUTE_ERROR,
                    replError.executionError.argumentCountException,
                    evman.eventClasses[evman.currentEventIndex].inSrcLineNumber
                );
                Debug.LogError(e);
            }
            catch (System.FormatException e)
            {
                consoleWriter.instance.throwError(
                    replError.EXECUTE_ERROR,
                    replError.executionError.argumentFormatException,
                    evman.eventClasses[evman.currentEventIndex].inSrcLineNumber
                );
                Debug.LogError(e);
            }

            bool hideWindow = false;
            if (args.Length > 2)
                hideWindow = args[2] == "1";

            float speed = 1.0f;
            if (args.Length > 3)
                speed = float.Parse(args[3]);

            bool isAuto = false;
            if (args.Length > 4)
                isAuto = args[4] == "1";

            yield return messageWindowClass.instance.showText(
                chara,
                text,
                speed,
                hideWindow,
                isAuto
            );
            isDone = true;
        }
    }

    public class hideWindow : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            messageWindowClass.instance.hideWindow();
            isDone = true;
            yield return null;
        }
    }
}
