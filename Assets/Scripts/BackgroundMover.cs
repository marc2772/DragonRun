using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
	private Vector3 backgroundMovement;
	private bool hasSpawnedAnother = false;

	void Start()
	{
		backgroundMovement = new Vector3(-0.05f, 0, 0);
	}

	void FixedUpdate()
	{
		transform.Translate(backgroundMovement);

		if(transform.position.x < -5 && !hasSpawnedAnother)
		{
			Camera.main.SendMessage("Spawn");
			hasSpawnedAnother = true;
		}
		
		if(transform.position.x < -15)
			Destroy(gameObject);
	}
}
