using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	[Header("Set in Inspector")]
	public float lifeSpan=5;
	public int damage=1;
	[Header("Set Dynamically")]
	public float lifeTime;
	public void Start(){
		lifeTime=Time.time+lifeSpan;
	}public void Update(){
		if(lifeTime<=0){
			lifeTime=Time.time+lifeSpan;
		}
		if(Time.time>=lifeTime){disable();}
	}public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag=="Player"){Hero.S.Damage(damage);}
		if(other.gameObject.tag!="Enemy")disable();
	}private void disable(){
		lifeTime=0;
		gameObject.SetActive(false);
	}
}
