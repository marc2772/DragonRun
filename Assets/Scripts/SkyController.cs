using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
	public Light lighting;
	public GameObject sunAndMoon;
	public GameObject stars;
	private SpriteRenderer starsRenderer;

	public GameObject cloudPrefab;
	public List<Sprite> clouds;

	private float timeToSpawnCloud;
	private float time;

	void Awake()
	{
		starsRenderer = stars.GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		SetRandomTime();
	}

	void Update()
	{
		if(DragonStateManager.Instance.state == DragonStateManager.State.Alive)
		{
			time += Time.deltaTime;
			if(time > timeToSpawnCloud)
			{
				SpawnCloud();
				SetRandomTime();
				time = 0;
			}
		}
	}

	void FixedUpdate()
	{
		if(DragonStateManager.Instance.state == DragonStateManager.State.Alive)
		{
			//Rotate sun and moon
			Vector3 sunRotation = sunAndMoon.transform.rotation.eulerAngles;
			sunRotation.z -= 0.1f;
			sunAndMoon.transform.rotation = Quaternion.Euler(sunRotation);

			//Change lighting
			float intensity = 1 - Mathf.Abs((sunRotation.z - 180) / 180);
			lighting.intensity = intensity;

			//Rotate stars
			Vector3 starsRotation = stars.transform.rotation.eulerAngles;
			starsRotation.z -= 0.03f;
			stars.transform.rotation = Quaternion.Euler(starsRotation);

			Color starsColor = starsRenderer.color;
			starsColor.a = Mathf.Abs((sunRotation.z - 180) / 180);
			starsRenderer.color = starsColor;
		}
	}

	void SetRandomTime()
	{
		timeToSpawnCloud = Random.Range(2.0f, 10.0f);
	}

	void SpawnCloud()
	{
		int which = Random.Range(0, clouds.Count);

		Vector3 position = new Vector3(10.0f, Random.Range(0.0f, 4.0f), 5);

		GameObject cloud = Instantiate(cloudPrefab, position, Quaternion.identity);
		cloud.GetComponent<SpriteRenderer>().sprite = clouds[which];
	}
}
