using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpwan : MonoBehaviour {


	public float CreatTime = 1;
	private float current = 0;

	public GameObject spikePlatform, stardardPlatform;
	public GameObject[] SpeedPlatform;

	void Update()
	{
		CreatPlatform ();
	}

	public void CreatPlatform()
	{
		GameObject temp = null;
		Vector2 pos = transform.position;
		pos.x = Random.Range (-2.14f, 2.14f);
		current += Time.deltaTime;
		if (current >= CreatTime) {

			int ran = Random.Range (0, 5);
			if (ran == 2) {
				temp=Instantiate (stardardPlatform, pos, Quaternion.identity);
			} else if (ran == 3) {
				if (Random.Range (0, 2) > 0) {
					temp=Instantiate (stardardPlatform, pos, Quaternion.identity);
				} else {
					temp=Instantiate (spikePlatform, pos, Quaternion.identity);
				}

			} else if (ran == 4) {
				temp=Instantiate (stardardPlatform, pos, Quaternion.identity);
			} else if (ran == 1) {
				temp=Instantiate (SpeedPlatform [Random.Range (0, SpeedPlatform.Length)], pos, Quaternion.identity);
			} else {
				if (Random.Range (0, 2) > 0) {
					temp=Instantiate (stardardPlatform, pos, Quaternion.identity);
				} else {
					temp=Instantiate (spikePlatform, pos, Quaternion.identity);
				}
			}
			current = 0;
		}
	}
}
