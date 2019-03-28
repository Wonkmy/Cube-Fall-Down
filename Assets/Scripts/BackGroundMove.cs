using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour {

	public float move_Speed;
	public MeshRenderer meshrenderer;

	void Start()
	{
		meshrenderer = GetComponent<MeshRenderer> ();
	}

	void Update () {
		Move ();
	}

	void Move()
	{
		Vector2 temp = meshrenderer.sharedMaterial.GetTextureOffset ("_MainTex");
		temp.y += Time.deltaTime * move_Speed;

		meshrenderer.sharedMaterial.SetTextureOffset ("_MainTex", temp);
	}
}
