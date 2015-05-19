using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

	public float walkSpeed = 5.0f;
	public float attackDistance = 3.0f;
	public float attackDemage = 10.0f;
	public float attackDelay = 1.0f;
	public float hp = 200.0f;
	//public float hitPoints = 100.0f;

	private float timer = 0;

	void takeHit(float demage) 
	{
		hp -= demage;
		animation.CrossFade("damage");
		if(hp <= 0.0) {
			//Destroy(gameObject);
			animation.Stop("run");
			animation.CrossFade("dead");
		}
	}
	


	void OnTriggerStay(Collider other)
	{
		if(other.tag.Equals("Player") && hp > 0) {
			
			Quaternion targetRotation = Quaternion.LookRotation(other.transform.position - transform.position);
			float oryginalX = transform.rotation.x;
			float oryginalZ = transform.rotation.z;

			Quaternion finalRotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);
			finalRotation.x = oryginalX;
			finalRotation.z = oryginalZ;
			transform.rotation = finalRotation;

			float distance = Vector3.Distance(transform.position, other.transform.position);
			if(distance > attackDistance) {
				animation.CrossFade("run");
				transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
				
			} else {
				if(timer <= 0) {
					animation.CrossFade("attack02");
					//animation.CrossFade("attack02", 0.5f);
					other.SendMessage("takeHit", attackDemage);
					timer = attackDelay;
				}
			}

			if(timer > 0) {
				timer -= Time.deltaTime;
			}
		}
	}
	
	void OnTriggerExit(Collider other) 
{
	if (other.tag.Equals ("Player") && hp > 0) {
		animation.CrossFade("stand_vigilance");
		animation.CrossFadeQueued("stand");
	}
}
	
	void Start() {
	
		animation.CrossFade("stand");
		//rigidbody.Sleep;
		
		
	}
}