using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	//public List<GameObject> pooledObjects;
	public List<GameObject> enemyPool;
	//public GameObject playerProjectile;
	public GameObject enemyProjectile;
	//public int playerPoolSize;
	public int enemyPoolSize;
	public static ObjectPool S;
	void Awake(){
		if(S==null)S = this;
		else Destroy(this);
	}
    // Start is called before the first frame update
    void Start()
    {
        //pooledObjects = new List<GameObject>();
		enemyPool = new List<GameObject>();
		/*for(int i=0;i<playerPoolSize;i++){
			GameObject obj = (GameObject)Instantiate(playerProjectile);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}*/
		for(int i=0;i<enemyPoolSize;i++){
			GameObject obj = (GameObject)Instantiate(enemyProjectile);
			obj.SetActive(false);
			enemyPool.Add(obj);
		}
    }
	/*public GameObject GetPooledObject(){
		for(int i=0;i<pooledObjects.Count;i++){
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}
		return null;
	}*/
	public GameObject getEnemyPool(){
		for(int i=0;i<enemyPool.Count;i++){
			if(!enemyPool[i].activeInHierarchy){
				return enemyPool[i];
			}
		}
		return null;
	}
}
