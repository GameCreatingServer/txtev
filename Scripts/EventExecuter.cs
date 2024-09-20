using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using txt2ev;

public class EventExecuter : MonoBehaviour
{
    [SerializeField]
    TextAsset eventFile;

    void Start()
    {
        eventManager.instance.execute(eventFile);
    }
}
