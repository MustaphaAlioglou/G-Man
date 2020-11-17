using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTextObject : MonoBehaviour
{
	public float fallSpeed = 1f;
	private void Update()
	{
		//temporary movement(moving with transform doesnt collide with objects)
		transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
	}
}
