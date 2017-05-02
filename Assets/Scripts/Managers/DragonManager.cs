using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragonManager : Singleton<DragonManager>
{
	private Animator animator;
	private Rigidbody2D rigidBody;

	private float distance = 0.0f;

	void Awake()
	{
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	void Update()
	{
		switch(DragonStateManager.Instance.state)
		{
			case DragonStateManager.State.Tutorial:
				break;

			case DragonStateManager.State.Alive:
				if(Input.GetMouseButtonDown(0))
				{
					Fly();
				}
				if(transform.position.y < -5)
				{
					DragonStateManager.Instance.Die();
				}
				break;

			case DragonStateManager.State.Dead:
				if(Input.GetMouseButtonDown(0))
				{
					SceneManager.LoadScene("Default");
				}
				break;
		}
	}

	void FixedUpdate()
	{
		if(DragonStateManager.Instance.state == DragonStateManager.State.Alive)
		{
			distance += 0.01f;
			MenuManager.Instance.SetDistance(distance);
		}
	}

	void Fly()
	{
		animator.Play("DragonFly");
		Vector2 velocity = rigidBody.velocity;
		if(velocity.y <= 0)
			velocity.y = 5;
		else
			velocity.y = 7;
		
		rigidBody.velocity = velocity;
	}

	public void SetKinematic(bool kinematic)
	{
		rigidBody.isKinematic = kinematic;
		rigidBody.velocity = new Vector2();
	}
}
