using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace txt2ev
{
    public class messageWindowClass : MonoBehaviour
    {
        public static messageWindowClass instance;

        Animator animator;

        [SerializeField]
        TMP_Text nameText;

        [SerializeField]
        TMP_Text bodyText;

        string messageSE = "common.pop";

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

        public void initialize()
        {
            animator = GetComponent<Animator>();
        }

        public IEnumerator showText(
            string name,
            string text,
            float speed,
            bool hideWindow,
            bool isAuto
        )
        {
            nameText.text = name;

            string curBlock = text.Replace(";", "\n").Replace("_", " ");
            //curBlock = Epm.repValable(curBlock);
            int charNum = 0;
            bodyText.text = curBlock;
            animator.SetBool("enable", true);
            eventManager.instance.soundEffectSource.PlayOneShot(
                soundDBinstance.instance.getClip(messageSE)
            );
            while (charNum < curBlock.Length + 1)
            {
                /*
                if (eventManager.instance.skip)
                {
                    charNum = curBlock.Length + 1;
                }
                else
                {*/
                charNum++;
                //}
                bodyText.maxVisibleCharacters = charNum;

                if (Input.GetKey(KeyCode.P))
                {
                    break;
                }
                yield return new WaitForSeconds(
                    0.025f / speed /* / eventManager.instance.textSpeed */
                );
            }

            if (!isAuto)
            {
                yield return new WaitUntil(
                    () =>
                        Input.GetMouseButtonDown(0)
                        || Input.GetButtonDown("Submit")
                        || Input.GetKey(KeyCode.P)
                );
            }

            if (hideWindow || Input.GetKey(KeyCode.P))
            {
                animator.SetBool("enable", false);
            }
            yield return null;
        }

        public void hideWindow()
        {
            animator.SetBool("enable", false);
        }
    }
}
