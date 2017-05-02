using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : Singleton<TutorialManager>
{
	public GameObject handCursor;
	public GameObject grey;

	void Update()
	{
		if(DragonStateManager.Instance.state == DragonStateManager.State.Tutorial)
		{
			if(Input.GetMouseButtonDown(0))
			{
				handCursor.SetActive(false);
				grey.SetActive(false);
				DragonStateManager.Instance.EndTutorial();
			}
		}
	}
}
