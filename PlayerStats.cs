using UnityEngine;
using System.Collections;

public class PlayerStats: MonoBehaviour {
	
private float maxHealth = 100;
private float currentHealth = 100;
	
public Texture2D healthTexture;
	
private float barWidth;
private float barHeight;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake() {
		
	barHeight = Screen.height * 0.02f;
	barWidth = barHeight * 10.0f;

	}
	
	void OnGUI() {
		
	GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
	                         Screen.height - barHeight - 10,
	                         currentHealth * barWidth / maxHealth,
	                         barHeight),
	                healthTexture);

	}
	
	void takeHit(float demage) {
	
		currentHealth -= demage;
	

	
	currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
}
	
}
