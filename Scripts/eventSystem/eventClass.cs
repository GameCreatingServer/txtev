using System.Collections.Generic;
using UnityEngine;

namespace txt2ev
{
    [System.Serializable]
    public class eventClass
    {
        public eventActor actor;
        public string actorType;
        public string[] args;

        public string SrcPath;
        public int inSrcLineNumber;

        public eventClass[] includance;

        public eventClass(string SrcPath, eventActor actor, string[] args, int inSrcLineNumber)
        {
            this.SrcPath = SrcPath;
            this.actor = actor;
            this.actorType = actor.GetType().Name;
            this.args = args;
            this.inSrcLineNumber = inSrcLineNumber;
        }

        public eventClass(
            string SrcPath,
            string[] args,
            eventClass[] includance,
            int inSrcLineNumber
        )
        {
            this.SrcPath = SrcPath;
            this.actor = new dummy();
            this.actorType = "eventBlock";
            this.args = args;
            this.includance = includance;
            this.inSrcLineNumber = inSrcLineNumber;
        }
    }
}
