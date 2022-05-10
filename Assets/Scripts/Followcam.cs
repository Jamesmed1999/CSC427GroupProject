using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{
    void Update()
    {
        transform.position = Hero.S.transform.position+ new Vector3(0,5,-5);
    }
}
