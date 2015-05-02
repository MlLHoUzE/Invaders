using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
	[SerializeField] private Vector2 direction;

	public float SpeedPerFrame
	{
		get { return this.speed * Time.deltaTime; }
	}


	#region MonoBehaviour
	void Update(){
		this.rigidbody2D.AddForce(Vector2.up * speed);	//add a force to the shot to make it move
	}
	#endregion MonoBehaviour
}
