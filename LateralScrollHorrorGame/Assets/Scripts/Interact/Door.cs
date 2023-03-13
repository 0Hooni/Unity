using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteract
{
    [SerializeField]
    private Transform tpPosition;

    public bool Interact(GameObject playerObj) {
        if (tpPosition != null)
        {
            playerObj.transform.position = tpPosition.position;
            return true;
        }
        return false;
    }

}
