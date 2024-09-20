using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rm2.userDataBase;

namespace rm2
{
    [CreateAssetMenu(fileName = "Data", menuName = "rm2/シナリオファイル")]
    public class senarioFile : ScriptableObject
    {
        public string senarioName;
        public TextAsset eventScript;
        public List<soundList> soundLists = new List<soundList>();
        public List<talkCharaDataBase> talkCharaDatas = new List<talkCharaDataBase>();
        public List<backgroundImageDatas> backgroundImageDatas = new List<backgroundImageDatas>();
    }
}
