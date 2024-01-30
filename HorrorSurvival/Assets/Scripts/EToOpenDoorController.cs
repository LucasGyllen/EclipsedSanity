using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EToOpenDoorController : MonoBehaviour, IInteractable
{
    private Animator doorAnim;

    private bool doorOpen = false;

    [SerializeField] private GameObject showEToOpenDoor = null;

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
        Debug.Log(Random.Range(0, 100));
        PlayAnimation();
        //StartCoroutine(ShowDoorLocked());
    }

    /*IEnumerator ShowDoorLocked()
    {
        showEToOpenDoor.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showEToOpenDoor.SetActive(false);
    }*/
}
