using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace txt2ev
{
    public class fadeController : MonoBehaviour
    {
        public static fadeController instance;

        Image spr;

        [SerializeField]
        float currentFadeValue = 0.0f;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void initialize()
        {
            spr = GetComponent<Image>();
            spr.color = Color.clear;
        }

        public IEnumerator FadeOut(float duration)
        {
            spr.enabled = true;

            currentFadeValue = 0.0f;

            while (currentFadeValue < 1.0f)
            {
                currentFadeValue = Mathf.MoveTowards(
                    currentFadeValue,
                    1.0f,
                    Time.deltaTime / duration
                );
                spr.color = Color.Lerp(Color.clear, Color.black, currentFadeValue);
                yield return null;
            }
        }

        public IEnumerator FadeIn(float duration)
        {
            currentFadeValue = 1.0f;

            while (currentFadeValue > 0.0f)
            {
                currentFadeValue = Mathf.MoveTowards(
                    currentFadeValue,
                    0.0f,
                    Time.deltaTime / duration
                );
                spr.color = Color.Lerp(Color.clear, Color.black, currentFadeValue);
                yield return null;
            }
            spr.enabled = false;
        }
    }
}
