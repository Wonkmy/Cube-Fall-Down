using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {
	
	void Update () {
		Vector3 temp = transform.position;
		if (temp.x <= -2.71f) {
			temp.x = -2.71f;
		}
		if (temp.x >= 2.71f) {
			temp.x = 2.71f;
		}
		if (temp.y <= -6f) {
			gameObject.SetActive (false);
            SoundManager.instance.PlayDeath();
			GameManager.instance.GameOver ();
		}
		transform.position = temp;
	}
}
