using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
	public GameObject gameOver;
	public GameObject highScoreText;
	public TextMesh distance;

	private float highScore;

	void Start()
	{
		gameOver.SetActive(false);
		highScoreText.SetActive(false);

		highScore = PlayerPrefs.GetFloat("HighScore", 0.0f);
	}

	public void Die()
	{
		gameOver.SetActive(true);
		highScoreText.SetActive(true);
		highScoreText.GetComponent<TextMesh>().text = "Highest distance: " + PlayerPrefs.GetFloat("HighScore").ToString("F1");
	}

	public void SetDistance(float dist)
	{
		distance.text = dist.ToString("F1");

		if(dist > highScore)
			PlayerPrefs.SetFloat("HighScore", dist);
	}
}