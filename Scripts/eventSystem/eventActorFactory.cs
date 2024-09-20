using System.Text.RegularExpressions;
using UnityEngine;

namespace txt2ev
{
    public static class eventActorFactory
    {
        public static eventActor str2EA(string str)
        {
            eventActor result = new dummy();

            /*
            else if(Regex.IsMatch(str,"choice")){
                result = new choice();
                }
                */
            if (Regex.IsMatch(str, "debugLog"))
            {
                result = new debugLog();
            }
            else if (Regex.IsMatch(str, "delay"))
            {
                result = new delay();
            }
            else if (Regex.IsMatch(str, "ENDING"))
            {
                result = new ending();
            }
            else if (Regex.IsMatch(str, "textWindow"))
            {
                result = new textWindow();
            }
            else if (Regex.IsMatch(str, "indexJump"))
            {
                result = new indexJump();
            }
            /*
        else if(Regex.IsMatch(str,"flagOperation")){
            result = new flagOperation();
            }
            */
            else if (Regex.IsMatch(str, "setSI$"))
            {
                result = new setSI();
            }
            else if (Regex.IsMatch(str, "setSIVisible"))
            {
                result = new setSIVisible();
            }
            else if (Regex.IsMatch(str, "setSITrigger"))
            {
                result = new setSITrigger();
            }
            else if (Regex.IsMatch(str, "fade"))
            {
                result = new Fade();
            }
            else if (Regex.IsMatch(str, "waitSubmit"))
            {
                result = new waitSubmit();
            }
            /*
        else if(Regex.IsMatch(str,"instantText")){
            result = new instantText();
            }
        else if(Regex.IsMatch(str,"hideInstantText")){
            result = new hideInstantText();
            }
            */
            else if (Regex.IsMatch(str, "setBGI"))
            {
                result = new setBGI();
            }
            else if (Regex.IsMatch(str, "SKIPPOINT"))
            {
                result = new SKIPPOINT();
            }
            else if (Regex.IsMatch(str, "hideWindow"))
            {
                result = new hideWindow();
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}
