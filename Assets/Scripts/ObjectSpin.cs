using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 50 * Time.deltaTime, 0f, Space.Self); //you spin me right round
    }
}
