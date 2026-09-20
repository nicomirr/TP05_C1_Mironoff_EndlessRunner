using UnityEngine;
using System.Collections.Generic;

public class TransitionObjectsDisabler 
{
    public void DisableObjects(List<GameObject> sceneObjects)
    {
        foreach(GameObject obj in sceneObjects)
        {
            obj.SetActive(false);
        }
    }
}
