using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectObject : MonoBehaviour
{
   

    public void OnTriggerEnter(Collider other)
    {
        Collectable.collectCount += 1;
        FindObjectOfType<AudioManager>().Play("nice");
        Debug.Log("collected");
        Debug.Log("collectCount" + Collectable.collectCount);
        Destroy(gameObject);
        if (Collectable.collectCount == 3)
        {
            SceneManager.LoadScene("outro"); //replace with credits scene
        }
    }
}
