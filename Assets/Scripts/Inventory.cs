using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance; 
    public List<Key> keyList = new List<Key>();

    public Transform ItemContent; 
    public GameObject InventoryItem;

    private void Awake(){
        Instance = this; 
    }

    public void AddKey(Key k){
        keyList.Add(k);
    }

    public void RemoveKey(Key k){
        keyList.Remove(k);
    }
    
    private void OnTriggerEnter(Collider other) ///dictates KEY interactions
    {
        Key k1 = other.GetComponent<Key>();
        if(k1 != null) //code for player colliding with a Key
        {
            keyList.Add(other.GetComponent<Key>());
            Destroy(k1.gameObject);
            Debug.Log("Key added to inventory!");
        }
    }

    public void ListInventoryItems(){
        foreach (var key in keyList){
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var ItemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var ItemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            string s = key.ToString();

            ItemName.text = s;
        }
    }
}