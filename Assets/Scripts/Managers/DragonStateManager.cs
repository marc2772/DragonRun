using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStateManager : Singleton<DragonStateManager>
{
	public enum State
	{
		Tutorial,
		Alive,
		Dead
	}
	public State state;

	void Start()
	{
		state = State.Tutorial;
	}

	public void EndTutorial()
	{
		state = State.Alive;
		DragonManager.Instance.SetKinematic(false);
	}

	public void Die()
	{
		state = State.Dead;
		MenuManager.Instance.Die();
		DragonManager.Instance.SetKinematic(true);
	}
}
