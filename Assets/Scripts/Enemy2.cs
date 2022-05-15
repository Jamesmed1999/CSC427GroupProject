using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    void FixedUpdate()
    {
        if(move()==false)rotate(); //really wish I could do ~move(), but unity is dumb
    }public override bool canMove(){
		ray = new Ray(transform.position,transform.right);
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
		loc+=transform.right*moveStep;
		return loc;
	}
}
