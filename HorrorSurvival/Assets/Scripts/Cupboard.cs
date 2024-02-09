using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour, IInteractable
{
    private CupboardManager cupboardManager;

    private void Start()
    {
        // Find the CupboardManager in the scene or set it some other way
        cupboardManager = FindObjectOfType<CupboardManager>();
    }

    public void Interact()
    {
        // Let the manager handle the interaction
        if (cupboardManager != null)
        {
            cupboardManager.ToggleDoors();
        }
    }
}
