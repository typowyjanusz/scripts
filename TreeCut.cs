using UnityEngine;
using System.Collections;

public class TreeCut : MonoBehaviour {
	
	public float hp = 100.0f;
	public GameObject drewno;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void takeHit(float demage) 
	{
		Debug.Log ("Trafione");
		hp -= demage;
		
		if(hp <= 0.0) {
			Destroy(gameObject);
			Instantiate(drewno,transform.position,transform.rotation);
			
		}
	}
	
}
