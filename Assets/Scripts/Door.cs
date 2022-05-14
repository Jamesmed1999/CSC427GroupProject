using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour //attach to doors prefabs
{

    [SerializeField] private Key.KeyType KeyT; 

    public Key.KeyType GetKeyType() //tells you what key type a door has
    {
        return KeyT;
    }

    public void openDoor() //door "opener" 
    {
        gameObject.SetActive(false);
    }



}
