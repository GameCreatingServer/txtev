using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rm2.userDataBase;
using txt2ev;
using Cysharp.Threading.Tasks;

namespace rm2
{
    public class senarioStarter : MonoBehaviour
    {
        [SerializeField]
        senarioFile senario;

        void Start()
        {
            startSenario();
        }

        void startSenario()
        {
            talkCharaDBinstance.instance.initializeDatas(senario.talkCharaDatas.ToArray());
            soundDBinstance.instance.initializeDatas(senario.soundLists.ToArray());
            backgroundImageDataBase.instance.initializeDatas(
                senario.backgroundImageDatas.ToArray()
            );
            fadeController.instance.initialize();
            messageWindowClass.instance.initialize();

            eventManager.instance.execute(senario.eventScript);
        }
    }
}
