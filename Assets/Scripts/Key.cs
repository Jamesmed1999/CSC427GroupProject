using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour //attach to key prefab 
{
    [SerializeField] private KeyType KeyT; //sets what type of key the prefab is 
    public enum KeyType //Types of Keys
    {
        Key,
        BossKey
    }


    public KeyType GetKeyType() //standard getter method 
    {
        return KeyT;
    }

}
