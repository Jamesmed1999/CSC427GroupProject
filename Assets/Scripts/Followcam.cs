using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{
	public float distance=5f;
    void Update()
    {
        transform.position = Hero.S.transform.position+ new Vector3(0,distance,-distance);
    }
}
