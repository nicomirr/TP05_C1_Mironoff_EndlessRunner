using UnityEngine;
using System.Collections;

namespace Game.Core
{
    public interface ICoroutineRunner
    {
        public Coroutine RunCoroutine(IEnumerator routine);
    }

}


//CHEQUEAR