using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class SiekieraJeb : MonoBehaviour {
public Texture2D crosshairTexture;

public AudioClip pistolShot;
public GameObject bloodParticles;

public float demage = 5.0f;
public float damage = 50.0f;
private Rect position;    
private float range = 100.0f;
private GameObject pistolSparks; 
private Vector3 fwd;
private RaycastHit hit;

public GameObject bulletHole;



	// Use this for initialization
	void Start () {
//Screen.showCursor = false;

        
	position = new Rect((Screen.width - crosshairTexture.width) / 2,
	                    (Screen.height - crosshairTexture.height) /2,
	                    crosshairTexture.width,
	                    crosshairTexture.height);	
	//pistolSparks = GameObject.Find("Sparks");
	//pistolSparks.particleEmitter.emit = false;
	//audio.clip = pistolShot;
	
	}
	
	// Update is called once per frame
	void Update () {

 Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        fwd = transform.TransformDirection(Vector3.forward);
	
	if(Input.GetButtonDown("Fire1")) {
			//animation.CrossFade("atak_siekiera_2");
		//pistolSparks.particleEmitter.Emit();
		//audio.Play();
		
		if (Physics.Raycast(transform.position, fwd, out hit)) {
			if(hit.transform.tag == "Enemy" && hit.distance < range) {
				hit.transform.gameObject.SendMessage("takeHit", damage);
				//hit.transform.gameObject.SendMessageUpwards("takeHitTree", damage);
				//hit.collider.SendMessageUpwards("takeHitTree", damage);
				GameObject go;
				go = Instantiate(bloodParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject; 
				Destroy(go, 0.3f);
				
			} else if(hit.distance < range) {
//GameObject go;
//go = Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject; 
//Destroy(go, 5);

				Debug.Log ("Trafiona Sciana");
			}
		}
	}
	
	}
void OnGUI()
{
	GUI.DrawTexture(position, crosshairTexture);
}
}
