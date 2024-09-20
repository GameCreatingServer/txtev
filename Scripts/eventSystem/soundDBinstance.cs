using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rm2.userDataBase;

namespace txt2ev
{
    public class soundDBinstance : MonoBehaviour
    {
        public static soundDBinstance instance;

        public List<audioData> audioDatas = new List<audioData>();

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        public void initializeDatas(soundList[] datas)
        {
            foreach (var data in datas)
            {
                // 各リストのAudioClipを追加する。
                // 区別の為にidentifierの先頭にリスト名を付与する。
                foreach (var a in data.audioClips)
                {
                    var clip = new audioData(a);
                    clip.identifier = $"{data.listName}.{a.identifier}";
                    audioDatas.Add(clip);
                }
            }
        }

        public AudioClip getClip(string identifier)
        {
            foreach (var a in audioDatas)
            {
                if (a.identifier == identifier)
                {
                    Debug.Log("searching sound: " + a.identifier);
                    return a.clip;
                }
            }

            Debug.LogWarning($"identifier \"{identifier}\" is invalid");
            return null;
        }

        public AudioClip getClip(int index)
        {
            if (index < audioDatas.Count && -1 < index)
            {
                return audioDatas[index].clip;
            }

            Debug.LogWarning($"index \"{index}\" is invalid");
            return null;
        }
    }
}
