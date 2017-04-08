using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
	public GameObject sunAndMoon;

	private SpriteRenderer sky;

	void Awake()
	{
		sky = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		Vector3 rotation = sunAndMoon.transform.rotation.eulerAngles;

		rotation.z -= 0.1f;
		if(rotation.z < -360)
			rotation.z += 360;

		sunAndMoon.transform.rotation = Quaternion.Euler(rotation);
	}
}
