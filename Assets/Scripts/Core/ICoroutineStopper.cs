using System.Collections;
using UnityEngine;

namespace Game.Core
{
    public interface ICoroutineStopper
    {
        public void FinalizeCoroutine(Coroutine routine);
    }
}

