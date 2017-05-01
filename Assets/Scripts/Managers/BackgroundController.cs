using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
	public List<GameObject> backgrounds;
		
	void Spawn()
	{
		int which = Random.Range(0, backgrounds.Count);
		Instantiate(backgrounds[which], new Vector3(15, 0, 0), Quaternion.identity);
	}
}
