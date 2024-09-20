using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace txt2ev
{
    [RequireComponent(typeof(TMP_InputField))]
    public class DebugCommandField : MonoBehaviour
    {
        TMP_InputField inputField;

        void Start()
        {
            inputField = GetComponent<TMP_InputField>();
        }

        public void execute()
        {
            if (inputField.text == null)
            {
                return;
            }
            eventManager.instance.execute(inputField.text);
        }
    }
}
