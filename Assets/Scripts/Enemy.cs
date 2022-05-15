using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Set in Inspector")]
	public float moveDelay=0.1f;
	public float shootDelay=1f;
	public float maxMoveDistance=10f;
	public float moveStep=0.1f;
	public GameObject head;
	public float projectileSpeed=10f;
	public float offsetForward=1.5f;
	public float offsetUp=0f;
	[Header("Set Dynamically")]
	public float canGo;
	public float canShoot;
	public float moveDistance=0f;
	public Ray ray;
	public virtual bool canFire(){
		if(canShoot<=Time.time){
			return true;
		}else return false;
	}public virtual bool move(){
		if(moveDistance>0 && canMove()){
			Vector3 loc;
			loc=forward();
			moveDistance-=moveStep;
			transform.position=loc;
			return true;
		}else if(moveDistance>0){
			moveDistance=0;
			return false;
		}return false;
	}public virtual bool canMove(){
		ray = new Ray(transform.position,transform.forward);
		if(Physics.Raycast(ray,3f)){
			return false;
		}else return true;
	}public virtual void shoot(){
		if(canFire()){
			canShoot = Time.time+shootDelay;
			GameObject go = ObjectPool.S.getEnemyPool();
			if(go!=null){
				blast(head);
			}
		}
	}public virtual void rotate(){
		Quaternion target;
		target = turn();
		transform.rotation=target;
		moveDistance=Random.Range(0,maxMoveDistance);
	}public virtual Vector3 forward(){
		Vector3 loc=transform.position;
		loc+=transform.forward*moveStep;
		return loc;
	}public virtual Quaternion turn(){
		int rand = Random.Range(-1,1);
		if(rand==0)rand=2;
		Quaternion target = transform.rotation*Quaternion.Euler(0,90*rand,0);
		return target;
	}public virtual void blast(GameObject point){
			GameObject go = ObjectPool.S.getEnemyPool();
			if(go!=null){
				//take the same properties as reference
				go.transform.rotation = point.transform.rotation;
				go.transform.position = point.transform.position;
				//move it to the end of the cannon, it's weird cuz it needs to be on the local axis and the head has negative y as forward
				go.transform.position += offsetForward*point.transform.TransformDirection(Vector3.down);
				go.transform.position += offsetUp*point.transform.TransformDirection(Vector3.forward);
				go.tag = "EnemyProjectile";
				go.layer = LayerMask.NameToLayer("EnemyProjectile");
				Rigidbody rb = go.GetComponent<Rigidbody>();
				go.SetActive(true);
				rb.velocity = go.transform.TransformDirection(Vector3.down)*projectileSpeed;
			}
	}
}

/*public Vector3 getRandomDirection(){
		float rand = 3;//Random.Range(0,4);//intentionally 1 out of range for no movement
		Vector3 loc=transform.position;
		switch(rand){
		case 0:loc.x+=1;break;
		case 1:loc.x-=1;break;
		case 2:loc.z+=1;break;
		case 3:loc.z-=1;break;
		}
		return loc;
	}*/
