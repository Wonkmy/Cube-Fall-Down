using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float move_Speed;
	private Rigidbody2D myRig;
	private int coinNum;
    private int scorenum = 0;
    public GameObject StarEffect;
    Vector3 startpos;


    void Start()
	{
        startpos = transform.position;

        myRig = GetComponent<Rigidbody2D> ();
		if (PlayerPrefs.HasKey ("RewordCoin")) {
			coinNum = GameManager.instance.GetRewordCoin ();	
		}
    }

	public void FixedUpdate()
	{
		Move ();
	}

	void Update()
	{
        Vector3 temp = transform.position - startpos;
        scorenum += (int)temp.y;
        PlayerPrefs.SetInt("GamingScore", scorenum);
    }

	void Move()
	{
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			//transform.Translate (Vector2.right * move_Speed * Time.deltaTime);
			myRig.velocity=new Vector2 (move_Speed,myRig.velocity.y);
		}
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			//transform.Translate (Vector2.left * move_Speed * Time.deltaTime);
			myRig.velocity=new Vector2 (-move_Speed,myRig.velocity.y);
		}


	}

	public void MoveOnSpeedPlatform(float speed)
	{
		myRig.velocity =new Vector2 (speed, myRig.velocity.y);
	}

	public void OnCollisionEnter2D(Collision2D target)
	{
		if (target.transform.tag == "TopSpike") {
            SoundManager.instance.PlayDeath();
			gameObject.SetActive (false);
			GameManager.instance.GameOver ();
		}
	}

	public void OnTriggerEnter2D(Collider2D target)
	{
		if (target.transform.tag == "Star") {
            //加金币  加特效  加分数
            GameObject newEffect= Instantiate(StarEffect, target.transform.position, Quaternion.identity);
            newEffect.transform.parent = target.transform.parent.transform;
            Destroy(newEffect, 1f);
            target.gameObject.SetActive(false);
            SoundManager.instance.PlayStar();
			coinNum++;
			PlayerPrefs.SetInt("RewordCoin",coinNum);
		}
	}
}
