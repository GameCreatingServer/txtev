using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rm2.userDataBase;

namespace txt2ev
{
    public class backgroundImageDataBase : MonoBehaviour
    {
        public static backgroundImageDataBase instance;

        public List<backGroundImageData> backGroundImages = new List<backGroundImageData>();

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

        public void initializeDatas(backgroundImageDatas[] datas)
        {
            foreach (var data in datas)
            {
                foreach (var d in data.backGroundImages)
                {
                    var bg = new backGroundImageData(d);
                    bg.identifier = $"{data.listName}.{d.identifier}";
                    backGroundImages.Add(bg);
                }
            }
        }

        public Sprite getSprite(string identifier)
        {
            foreach (var a in backGroundImages)
            {
                if (a.identifier == identifier)
                {
                    Debug.Log("searching sprite: " + a.identifier);
                    return a.sprite;
                }
            }

            Debug.LogWarning($"identifier \"{identifier}\" is invalid");
            return null;
        }
    }
}
