using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float move_Speed;

	public enum PlatformType
	{
		/// <summary>
		/// 普通平台
		/// </summary>
		STANDARD,
		/// <summary>
		/// 左移动平台
		/// </summary>
		SPEED_LEFT,
		/// <summary>
		/// 右移动平台
		/// </summary>
		SPEED_RIGHT,
		/// <summary>
		/// 尖刺平台
		/// </summary>
		SPIKE
	}

	public PlatformType platformtype;

	void Start()
	{
		
	}

	void Update()
	{
		Move ();
	}

	void Move()
	{
		transform.Translate (Vector2.up * move_Speed * Time.deltaTime);
	}
	//OnCollisionEnter2D(Collision2D target)
	public void OnTriggerEnter2D(Collider2D target)
	{
		if (target.transform.tag == "Player") {
            
			if (platformtype == PlatformType.SPIKE) {
                //玩家死亡 播放死亡声音  重新开始游戏
                SoundManager.instance.PlayDeath();
                GameManager.instance.GameOver();
				target.gameObject.SetActive(false);
			}
		}
	}

	public void OnCollisionStay2D(Collision2D target)
	{
		if (target.transform.tag == "Player") {
			if (platformtype == PlatformType.SPEED_LEFT) {
                target.gameObject.GetComponent<PlayerController> ().MoveOnSpeedPlatform (-1);
			}
			if (platformtype == PlatformType.SPEED_RIGHT) {
				target.gameObject.GetComponent<PlayerController> ().MoveOnSpeedPlatform (1);
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D target)
	{
		if (target.transform.tag == "Player") {
            
            if (platformtype == PlatformType.STANDARD) {
                //SoundManager.instance.PlayLand();
            }
		}
	}
}
