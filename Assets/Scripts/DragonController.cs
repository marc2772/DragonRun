using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragonController : Singleton<DragonController>
{
	public GameObject gameOver;
	public Text distanceText;

	private Animator animator;
	private Rigidbody2D rigidBody;
	private bool isDead = false;

	private float distance = 0.0f;

	void Awake()
	{
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	void Update()
	{
		if(!TutorialManager.Instance.isActive)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(!isDead)
					Fly();
				else
					SceneManager.LoadScene("Default");
			}
			if(transform.position.y < -5)
			{
				Die();
			}
		}
	}

	void FixedUpdate()
	{
		if(!TutorialManager.Instance.isActive)
		{
			distance += 0.01f;
			distanceText.text = distance.ToString("#.0");
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

	void Die()
	{
		gameOver.SetActive(true);
		isDead = true;
	}

	public void SetKinematic(bool kinematic)
	{
		rigidBody.isKinematic = kinematic;
	}
}
