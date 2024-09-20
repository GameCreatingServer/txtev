using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class indexJump : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            try
            {
                evman.jump(int.Parse(args[0]));
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
            isDone = true;
            yield return null;
        }
    }
}
