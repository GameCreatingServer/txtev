using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rm2.userDataBase;

namespace txt2ev
{
    public class talkCharaDBinstance : MonoBehaviour
    {
        public static talkCharaDBinstance instance;

        public List<talkCharaData> talkCharaDatas = new List<talkCharaData>();

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

        public void initializeDatas(talkCharaDataBase[] datas)
        {
            foreach (var data in datas)
            {
                talkCharaDatas.AddRange(data.talkCharaDatas);
            }
        }

        public talkCharaData getChara(string identifier)
        {
            Debug.Log("searching chara: " + identifier);
            return talkCharaDatas.Find(t => t.identifier == identifier);
        }

        /// <summary>
        /// keyを指定してSpriteを取得する
        /// </summary>
        /// <param name="key">取得したいSpriteのIdentifier( charaIdentifier.expressionIdentifer )</param>
        /// <returns>取得したSprite. 取得できなかった場合はnull.</returns>
        public Sprite getSprite(string identifier)
        {
            string[] keys = identifier.Split('.');

            if (keys.Length != 3)
            {
                Debug.LogWarning($"identifier \"{identifier}\" is invalid");
                return null;
            }

            string charaIdentifier = keys[0];
            int expressionIdentifier = int.Parse(keys[1]);
            bool isAlter = bool.Parse(keys[2]);

            talkCharaData chara = this.getChara(charaIdentifier);
            if (chara == null)
            {
                Debug.LogWarning($"expressionSprite \"{charaIdentifier}\" not found");
                return null;
            }

            //Sprite retSprite = chara.getSprite(expressionIdentifier);

            Sprite retSprite = isAlter
                ? chara.expressionSpritesAlter[expressionIdentifier]
                : chara.expressionSprites[expressionIdentifier];

            if (retSprite == null)
            {
                Debug.LogWarning($"sprite \"{expressionIdentifier}\" not found");
                return null;
            }

            return retSprite;
        }
    }
}
