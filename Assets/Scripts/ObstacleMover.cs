using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour 
{
	private Vector3 obstacleMover;

	void Start()
	{
		obstacleMover = new Vector3(-Random.Range(0.01f, 0.08f), 0, 0);
	}

	void FixedUpdate()
	{
		if(DragonStateManager.Instance.state == DragonStateManager.State.Alive)
		{
			transform.Translate(obstacleMover);

			if(transform.position.x < -15)
				Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		DragonStateManager.Instance.Die();
	}
}
