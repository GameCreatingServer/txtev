using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    public class flagOperation : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string flagName = "";
            string operation = "";
            int value = 0;

            try
            {
                flagName = args[0];
                operation = args[1];
                value = int.Parse(args[2]);
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

            switch (operation)
            {
                case "=":
                    commonFlag.instance.setFlag(flagName, value);
                    break;
                case "+=":
                    commonFlag.instance.setFlag(
                        flagName,
                        commonFlag.instance.getFlag(flagName) + value
                    );
                    break;
                case "-=":
                    commonFlag.instance.setFlag(
                        flagName,
                        commonFlag.instance.getFlag(flagName) - value
                    );
                    break;
                default:
                    Debug.LogWarning("Invalid operation: " + operation);
                    break;
            }
            isDone = true;
            yield return null;
        }
    }
}
