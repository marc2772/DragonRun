using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D rigidBody;

	void Awake()
	{
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Fly();
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
}
