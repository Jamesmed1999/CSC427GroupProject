using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
	[Header("Set in Inspector")]
	public GameObject head2;
	public GameObject head3;
	public GameObject DoorTrigger;
    [Header("Set Dynamically")]
	public int firing=0;
	public bool active=false;
	public void FixedUpdate(){
		if(active){
			minifire();//not working, zero idea why
			if(firing==0)go();//if not in shooting loop, try moving
			else if(canFire()){
				firing--;
				fire();
			}
		}else{
			if(DoorTrigger.activeInHierarchy == false)active=true;
		}
	}public void go(){
		if(move()==false)firing=4;
	}public void fire(){
		Quaternion target = head.transform.rotation*Quaternion.Euler(0,0,90);
		head.transform.rotation=target;
		shoot();
		if(firing==0){rotate();}
	}public override bool canMove(){
		ray = new Ray(transform.position,transform.up);
		if(Physics.Raycast(ray,3f)){
			return false;
		}else return true;
	}public override Quaternion turn(){
		int rand = Random.Range(-1,1);//intentionally 1 out of range for no movement
		if(rand==0)rand=2;
		Quaternion target = transform.rotation*Quaternion.Euler(0,0,90*rand);
		return target;
	}public override Vector3 forward(){
		Vector3 loc=transform.position;
		loc+=transform.up*moveStep;
		return loc;
	}public void minifire(){
		if(canFire()){
			blast(head2);
			blast(head3);
		}
	}
}