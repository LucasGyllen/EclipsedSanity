using System.Collections;
using UnityEngine;

public class CupboardManager : MonoBehaviour, IInteractable
{
    [Header("Animators")]
    [SerializeField] private Animator Cupboard_Door;
    [SerializeField] private Animator Cupboard_Door_2;

    [Header("Animation Clips")]
    [SerializeField] private AnimationClip cupboardLeftDoorOpen;
    [SerializeField] private AnimationClip cupboardRightDoorOpen;
    [SerializeField] private AnimationClip cupboardLeftDoorClose;
    [SerializeField] private AnimationClip cupboardRightDoorClose;

    /*Animator Cupboard_Door = GameObject.Find("Cupboard_Door").GetComponent<Animator>();
    Animator Cupboard_Door_2 = GameObject.Find("Cupboard_Door_2").GetComponent<Animator>();

    AnimationClip cupboardLeftDoorOpen = Resources.Load<AnimationClip>("CupboardLeftDoorOpen");
    AnimationClip cupboardRightDoorOpen = Resources.Load<AnimationClip>("CupboardRightDoorOpen");
    AnimationClip cupboardLeftDoorClose = Resources.Load<AnimationClip>("CupboardLeftDoorClose");
    AnimationClip cupboardRightDoorClose = Resources.Load<AnimationClip>("CupboardRightDoorClose");*/
    
    
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private bool doorsOpen = false;

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void ToggleDoors()
    {
        if (!pauseInteraction)
        {
            if (!doorsOpen)
            {
                // Play open animations for all doors
                Cupboard_Door.Play(cupboardLeftDoorOpen.name, 0, 0.0f);
                Cupboard_Door_2.Play(cupboardRightDoorOpen.name, 0, 0.0f);
                StartCoroutine(PauseDoorInteraction());
            }
            else
            {
                // Play close animations for all doors
                Cupboard_Door.Play(cupboardLeftDoorClose.name, 0, 0.0f);
                Cupboard_Door_2.Play(cupboardRightDoorClose.name, 0, 0.0f);
                StartCoroutine(PauseDoorInteraction());
            }

            doorsOpen = !doorsOpen;
        }
    }

    public void Interact()
    {
        ToggleDoors();
    }

    public void InteractWithDoors()
    {
        ToggleDoors();
    }
}