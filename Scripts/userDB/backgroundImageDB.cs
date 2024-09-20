using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.userDataBase
{
    [CreateAssetMenu(fileName = "Data", menuName = "rm2/背景画像データ")]
    public class backgroundImageDatas : ScriptableObject
    {
        public string listName;
        public List<backGroundImageData> backGroundImages = new List<backGroundImageData>();
    }

    [System.Serializable]
    public class backGroundImageData
    {
        public string identifier = "";
        public Sprite sprite;

        public backGroundImageData(backGroundImageData data)
        {
            this.identifier = data.identifier;
            this.sprite = data.sprite;
        }
        /*
        public Sprite getSprite(string identifier)
        {
            Debug.Log("searching sprite: " + identifier);
            Debug.Log("searching in: " + expressionSprites);

            Sprite ret = null;

            foreach (var e in expressionSprites)
            {
                Debug.Log("identifier: " + e.identifier);
                if (e.identifier == identifier)
                {
                    Debug.Log("found sprite: " + e.sprite);
                    ret = e.sprite;
                }
            }

            if (ret == null)
            {
                Debug.LogWarning($"identifier \"{identifier}\" is invalid");
            
                return null;
            }
            return ret;
        }
        */
    }
}
