using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	public static Hero S;
	[Header("Set in Inspector")]
	public float speed=1f;
	public Vector3 origin = new Vector3(0f,0.55f,0f);
	public GameObject hitbox;
	public float hidehitboxdelay=0.5f;
	public float attackcooldown=1f;
	[Header("Set Dynamically")]
	public float hidehitbox=0f;
	public float attackdelay=0f;
	public int health=12;//3 hearts, 4 per heart
	void Start()
	{
		hitbox.SetActive(false);
		if(S==null)S=this;
		else Destroy(this);
	}void Update(){
		if(hidehitbox != 0 && Time.time>hidehitbox){
			hitbox.SetActive(false);
		}
		if(transform.position.y<-10)transform.position=origin;
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 loc = transform.position;
		loc.x += x * speed * Time.deltaTime;
		loc.z += z * speed * Time.deltaTime;
		if (Input.GetAxis("Jump")==1 && attackdelay<=Time.time){
			hitbox.SetActive(true);
			hidehitbox=Time.time+hidehitboxdelay;
			attackdelay=Time.time+attackcooldown;
		}
		transform.LookAt(loc);
		transform.position = loc;
	}public void Damage(int damage){health-=damage;}
}
