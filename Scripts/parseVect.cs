using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using txt2ev;

public static class parseVect
{
    public static Vector2 str2Vec2(string str)
    {
        //str example : "(50.0,50.0)"
        str = str.Replace(" ", "")
            .Replace("\t", "")
            .Replace("\n", "")
            .Replace("(", "")
            .Replace(")", "");

        string[] cor = str.Split(',');
        float x = 0,
            y = 0;
        try
        {
            x = float.Parse(cor[0]);
            y = float.Parse(cor[1]);
        }
        catch (System.IndexOutOfRangeException e)
        {
            consoleWriter.instance.throwError(
                replError.EXECUTE_ERROR,
                replError.executionError.argumentFormatException,
                eventManager.instance.currentEventIndex
            );
            Debug.LogError(e);
        }
        catch (System.FormatException e)
        {
            consoleWriter.instance.throwError(
                replError.EXECUTE_ERROR,
                replError.executionError.argumentFormatException,
                eventManager.instance.currentEventIndex
            );
            Debug.LogError(e);
        }
        Vector2 ret = new Vector2(x, y);
        return ret;
    }
}
