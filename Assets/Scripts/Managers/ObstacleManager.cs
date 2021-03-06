﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	public List<GameObject> obstacles;

	private float timeToSpawnObstacles;
	private float time;

	void Start()
	{
		SetRandomTime();
	}

	void Update()
	{
		if(DragonStateManager.Instance.state == DragonStateManager.State.Alive)
		{
			time += Time.deltaTime;
			if(time > timeToSpawnObstacles)
			{
				SpawnObstacle();
				SetRandomTime();
				time = 0;
			}
		}
	}

	void SetRandomTime()
	{
		timeToSpawnObstacles = Random.Range(0.0f, 3.0f);
	}

	void SpawnObstacle()
	{
		int which = Random.Range(0, obstacles.Count);

		Vector3 position = new Vector3(10.0f, Random.Range(-4.0f, 4.0f), -1);

		/*GameObject obstacle = */Instantiate(obstacles[which], position, Quaternion.identity);
	}
}
