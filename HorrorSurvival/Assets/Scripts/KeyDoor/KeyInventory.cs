using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public enum KeyType
    {
        None,
        RustyKey,
        GoldenKey
        // Add other key types here.
    }


    public class KeyInventory : MonoBehaviour
    {
        public HashSet<KeyType> collectedKeys = new HashSet<KeyType>();

        public bool HasKey(KeyType keyType)
        {
            return collectedKeys.Contains(keyType);
        }

        // Call this method to add a key to the inventory.
        public void AddKey(KeyType keyType)
        {
            collectedKeys.Add(keyType);
        }
    }
}
