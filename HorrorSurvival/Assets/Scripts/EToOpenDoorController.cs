using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EToOpenDoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator doorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            doorAnim.Play("FirstDoorOpenAnim", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("FirstDoorCloseAnim", 0, 0.0f);
            doorOpen = false;
        }
    }

    public void Interact()
    {
        PlayAnimation();
    }
}
