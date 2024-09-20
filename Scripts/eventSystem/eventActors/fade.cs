using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class Fade : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string mode = "";
            float duration = 0.0f;

            try
            {
                mode = args[0];
                duration = args.Length > 1 ? float.Parse(args[1]) : 0.5f;
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

            if (mode.Contains("In"))
                yield return fadeController.instance.FadeIn(duration);
            else if (mode.Contains("Out"))
                yield return fadeController.instance.FadeOut(duration);
            else
                Debug.LogWarning("Invalid mode: " + mode);

            isDone = true;
            yield return null;
        }
    }
}
