using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace txt2ev
{
    public class backGroundImageClass : MonoBehaviour
    {
        public static backGroundImageClass instance;

        Image backGroundImage;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            backGroundImage = GetComponent<Image>();
        }

        public void setSprite(Sprite sprite)
        {
            backGroundImage.sprite = sprite;
        }
    }
}
