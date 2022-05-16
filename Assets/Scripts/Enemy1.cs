using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
	[Header("Set Dynamically")]
	public int firing=0;
	public void FixedUpdate(){
		if(firing==0)go();//if not in shooting loop, try moving
		else if(canFire()){
			firing--;
			fire();
		}
	}public void go(){
		if(move()==false)firing=4;
	}public void fire(){
		Quaternion target = head.transform.rotation*Quaternion.Euler(0,0,90);
		head.transform.rotation=target;
		shoot();
		if(firing==0){rotate();}
	}
}
