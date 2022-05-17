using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour //attach script to hero allows hero to store Key info
{
    private List<Key.KeyType> KeyList; //Hero's key list

    public void Awake()
    {
        KeyList = new List<Key.KeyType>(); //creates new list on awake maybe singleton in the future?
    }
    public void addKey(Key.KeyType k) //adds key to key list
    {
        FindObjectOfType<AudioManager>().Play("key");
        Debug.Log("Added Key  " + k);
        KeyList.Add(k);
    }
    public void removeKey(Key.KeyType k) //removes key from key list
    {
        Debug.Log("Removed Key  " + k);
        KeyList.Remove(k);
    }
    public bool containsKey(Key.KeyType k) //checks if key is in list
    {
        return KeyList.Contains(k);
    }
    private void OnTriggerEnter(Collider other) ///dictates KEY interactions
    {
        Key k1 = other.GetComponent<Key>();
        if(k1 != null) //code for player colliding with a Key
        {
            addKey(k1.GetKeyType());
            Destroy(k1.gameObject);
        }
        Door door1 = other.GetComponent<Door>();
        if(door1 != null) //code for door colliding with a player it checks the door type forst then if player has correct key
        {
            if (containsKey(door1.GetKeyType()))
            {
                removeKey(door1.GetKeyType());
                door1.openDoor();
            }
        }
    }

}
