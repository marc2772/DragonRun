using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : Singleton<TutorialManager>
{
	public GameObject handCursor;
	public GameObject grey;
	public bool isActive = true;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Click();
		}
	}

	void Click()
	{
		isActive = false;
		handCursor.SetActive(false);
		grey.SetActive(false);
		DragonController.Instance.SetKinematic(false);
	}
}
