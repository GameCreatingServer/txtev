using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class delay : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            float delayTime = 0.0f;
            try
            {
                delayTime = float.Parse(args[0]);
            }
            catch (System.ArgumentOutOfRangeException e)
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

            yield return new WaitForSeconds(delayTime);
            isDone = true;
            yield return null;
        }
    }
}
