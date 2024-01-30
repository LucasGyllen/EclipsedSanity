using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool firstDoor = false;
        [SerializeField] private bool pressEToOpenDoor = false;
        [SerializeField] private bool rustyKey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (firstDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }

            else if (pressEToOpenDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void objectInteraction()
        {
            if (firstDoor)
            {
                doorObject.PlayAnimation();
            }

            else if (rustyKey)
            {
                _keyInventory.hasRustyKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}


