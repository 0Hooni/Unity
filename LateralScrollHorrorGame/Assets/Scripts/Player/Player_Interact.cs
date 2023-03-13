using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    private Player_Input playerInput; 


    private bool canInteract; 

    private List<Transform> interactableObjs = new List<Transform>();

    private void Awake()
    {
        playerInput = GetComponentInParent<Player_Input>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.isInteract) {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractableObj"))
        {
            canInteract = true;
            interactableObjs.Add(collision.GetComponent<Transform>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractableObj"))
        {
            interactableObjs.Remove(collision.GetComponent<Transform>());
            if (interactableObjs.Count == 0) { canInteract = false; }
        }
    }

    private void Interact()
    {
        if (!canInteract) return;

        float distance = 0; 
        int lowDistanceIdx = 0;

        for (int i = 0; i < interactableObjs.Count; i++)
        {
            if (i == 0)
            {
                distance = Vector2.Distance(transform.position, interactableObjs[i].position);
            }
            else
            {
                float tmpDistance = Vector2.Distance(transform.position, interactableObjs[i].position);

                if (tmpDistance < distance)
                {
                    distance = tmpDistance;
                    lowDistanceIdx = i;
                }
            }
        }

        IInteract interactObj = interactableObjs[lowDistanceIdx].gameObject.GetComponent<IInteract>();

        if (interactObj != null)
        {
            interactObj.Interact(playerInput.gameObject);
        }
    }
}
