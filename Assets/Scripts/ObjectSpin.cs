using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    [SerializeField] 
    int spinSpeed = 50, rotateSpeed = 0;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, rotateSpeed, Space.Self); //you spin me right round
    }
}
