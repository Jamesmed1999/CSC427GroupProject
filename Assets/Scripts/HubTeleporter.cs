using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HubTeleporter : MonoBehaviour
{

    [SerializeField] string sceneName = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("tele");
        SceneManager.LoadScene(sceneName);
    }
}
