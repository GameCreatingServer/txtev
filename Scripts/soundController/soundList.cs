using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.userDataBase
{
    [CreateAssetMenu(fileName = "Data", menuName = "rm2/サウンドリスト")]
    public class soundList : ScriptableObject
    {
        public string listName;
        public List<audioData> audioClips = new List<audioData>();
    }

    [System.Serializable]
    public class audioData
    {
        public string identifier = "";
        public AudioClip clip;

        public audioData(audioData audioData)
        {
            this.identifier = audioData.identifier;
            this.clip = audioData.clip;
        }
    }
}
