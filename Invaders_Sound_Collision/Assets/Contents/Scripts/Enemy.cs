using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	[SerializeField] private Vector2 direction;
	[SerializeField] private GameObject explosion = null;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public int scoreValue;
	private GameController gameController;
	public float SpeedPerFrame
	{
		get { return this.speed * Time.deltaTime; }
	}
	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		
	}
	
	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		audio.Play();
	}
		
	#region MonoBehaviour
	void Update(){
		this.rigidbody2D.AddForce(Vector2.up * speed);
	}
	#endregion MonoBehaviour

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Boundary"){
			return;
		}
		if(other.tag == "Player"){
			GameObject explosionObject = Object.Instantiate(this.explosion) as GameObject;
			explosionObject.transform.position = this.gameObject.transform.position;
			Object.Destroy(this.gameObject);
			Object.Destroy(other.gameObject);
			gameController.AddScore(scoreValue);
		}

	}
}
