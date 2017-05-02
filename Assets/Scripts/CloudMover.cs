using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
	private Vector3 cloudMovement;

	void Start()
	{
		cloudMovement = new Vector3(-0.02f, 0, 0);
	}

	void FixedUpdate()
	{
		if(DragonStateManager.Instance.state == DragonStateManager.State.Alive)
		{
			transform.Translate(cloudMovement);

			if(transform.position.x < -15)
				Destroy(gameObject);
		}
	}
}