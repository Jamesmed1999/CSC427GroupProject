using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform Target; //assign empty game object 
    public GameObject Player; //assign player

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("tele");
        Player.transform.position = Target.transform.position;
    }
}
