using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    [SerializeField]
    string sceneName = "";
    public void Exit()
    {
        Application.Quit();
        Debug.Log("game closed");
    }
    public void Startgame()
    {
        SceneManager.LoadScene(sceneName); //replace with hub scene!!!!!!!
        
    }

}
