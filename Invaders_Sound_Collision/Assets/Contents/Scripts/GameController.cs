using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawn1, spawn2, spawn3, spawn4;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	private int randomSpawn;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (restart) //if restart is true then check to see if the player has pressed R to play again
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);//restart game
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);//causes a delay from when the game is started until the first wave spawns
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) //spawns enemies until the correct number of hazards have been spawned
				{
				int randomSpawn = Random.Range (1, 5);	// get a random number to determine which location to create an enemy
				switch(randomSpawn)						//spawn enemy based on the random number
				{
				case 1:
					Instantiate (hazard, spawn1, Quaternion.identity);
					break;
				case 2:
					Instantiate (hazard, spawn2, Quaternion.identity);
					break;
				case 3:
					Instantiate (hazard, spawn3, Quaternion.identity);
					break;
				default:
					Instantiate (hazard, spawn4, Quaternion.identity);
					break;
				}
					yield return new WaitForSeconds (spawnWait);//causes a pause between enemies in the same wave
				}
			yield return new WaitForSeconds (waveWait);//causes delay between the waves of enemies

			if (gameOver)//checks if game over is true
			{
				restartText.text = "Press 'R' to Restart";//set the restart text to prompt player to play again
				restart = true;							
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)	//updates the current score
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()	//updates the score text field
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()//causes game over text to appear
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
