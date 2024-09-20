using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    [System.Serializable]
    public class flag
    {
        public string flagName;
        public int flagValue = 0;

        public void setFlag(int value)
        {
            flagValue = value;
        }

        public int getFlag()
        {
            return flagValue;
        }
    }
}
