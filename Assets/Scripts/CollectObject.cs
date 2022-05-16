using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectObject : MonoBehaviour
{
   

    public void OnTriggerEnter(Collider other)
    {
        Collectable.collectCount += 1;
        Debug.Log("collected");
        Debug.Log("collectCount" + Collectable.collectCount);
        Destroy(gameObject);
        if (Collectable.collectCount == 2)
        {
            SceneManager.LoadScene("mainmenu"); //replace with credits scene
        }
    }
}
