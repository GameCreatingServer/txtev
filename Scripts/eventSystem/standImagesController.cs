using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace txt2ev
{
    public class standImagesController : MonoBehaviour
    {
        public static standImagesController instance;

        public List<Transform> standImages = new List<Transform>();

        List<string> keys = new List<string>();
        List<Animator> animators = new List<Animator>();
        List<Image> renderers = new List<Image>();

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

            foreach (var standImage in standImages)
            {
                animators.Add(standImage.GetComponent<Animator>());
                renderers.Add(standImage.GetComponent<Image>());
                keys.Add(standImage.name);
            }
        }

        void Start()
        {
            foreach (var render in renderers)
            {
                render.enabled = false;
            }
        }

        public int ImageIndexOf(string imageName)
        {
            var index = keys.IndexOf(imageName);

            return index;
        }

        public void setSprite(string imageName, Sprite sprite)
        {
            var index = ImageIndexOf(imageName);
            if (index == -1)
            {
                consoleWriter.instance.throwError(
                    replError.READ_ERROR,
                    replError.readError.noSuchImage,
                    -1
                );
                return;
            }
            renderers[index].sprite = sprite;
        }

        public void setVisible(string imageName, bool visible)
        {
            var index = ImageIndexOf(imageName);
            if (index == -1)
            {
                consoleWriter.instance.throwError(
                    replError.READ_ERROR,
                    replError.readError.noSuchImage,
                    -1
                );
                return;
            }
            renderers[index].enabled = visible;
        }

        public void setTrigger(string imageName, string trigger)
        {
            var index = ImageIndexOf(imageName);
            if (index == -1)
            {
                consoleWriter.instance.throwError(
                    replError.READ_ERROR,
                    replError.readError.noSuchImage,
                    -1
                );
                return;
            }
            animators[index].SetTrigger(trigger);
        }
    }
}
