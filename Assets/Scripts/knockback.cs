using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
	public string trigger;
	public float force=0.5f;
	public int damage=0;
	//this is a workaround for collisions on children not working properly
	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == trigger){
			other.transform.position += (other.transform.position-transform.position)*0.5f;
		}if(other.gameObject.tag == "Player"){Hero.S.Damage(damage);}
	}
}
