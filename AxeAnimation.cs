using UnityEngine;
using System.Collections;

public class AxeAnimation : MonoBehaviour {
               //AXE KURWEUE
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetButtonDown("Fire1")) {
			animation.CrossFade("atak_siekiera");
		}
	
	}
}
