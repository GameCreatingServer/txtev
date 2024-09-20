using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace txt2ev
{
    public class eventManager : MonoBehaviour
    {
        public static eventManager instance;

        public bool executing = false;
        public int currentEventIndex = 0;
        public eventClass[] eventClasses;

        [SerializeField]
        int skipPoint = 0;

        public AudioSource soundEffectSource;

        public GameObject instEvman;

        bool skip = false;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public void execute(string command)
        {
            TextAsset textAsset = new TextAsset(command);
            var classes = eventParser.parseEvent(textAsset);
            StartCoroutine(executeEvent(classes));
        }

        public void execute(TextAsset command)
        {
            var classes = eventParser.parseEvent(command);
            StartCoroutine(executeEvent(classes));
        }

        IEnumerator executeEvent(eventClass[] classes)
        {
            eventClasses = classes;
            for (int i = 0; i < eventClasses.Length; i++)
            {
                if (eventClasses[i].actorType == "SKIPPOINT")
                {
                    skipPoint = i;
                    break;
                }
            }
            executing = true;
            yield return runEvent(eventClasses[0]);
            yield return null;
        }

        IEnumerator runEvent(eventClass evClss)
        {
            skip = false;
            var actor = evClss.actor;
            var args = evClss.args;

            if (!actor.isDone)
            {
                currentEventIndex++;
                Debug.Log("Executing actor: " + actor);
                StartCoroutine(actor.execute(this, args));
                yield return new WaitUntil(() => actor.isDone || skip);
            }
            if (currentEventIndex < eventClasses.Length)
            {
                if (eventClasses[currentEventIndex].actorType == "eventBlock")
                {
                    var instantEventManager = GameObject
                        .Instantiate(instEvman)
                        .GetComponent<instantEventManager>();
                    yield return instantEventManager.executeEvent(
                        eventClasses[currentEventIndex].includance
                    );
                    yield return new WaitUntil(() => instantEventManager.executing == false);
                    Destroy(instantEventManager.gameObject);
                }
                StartCoroutine(runEvent(eventClasses[currentEventIndex]));
            }
            else
            {
                currentEventIndex = 0;
                executing = false;
            }
            yield return null;
        }

        public void jump(int index)
        {
            if (index < eventClasses.Length && index >= 0)
                currentEventIndex = index;
            else
                Debug.LogWarning("indexJump: index out of range");
        }

        public void skipAllEvents()
        {
            jump(skipPoint);
            skip = true;
        }
    }
}
