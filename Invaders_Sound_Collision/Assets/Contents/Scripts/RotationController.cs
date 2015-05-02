using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour
{
	[SerializeField] private RotationController rotationController;
	[SerializeField] private float rotationSpeed = 0;

	public float RotationSpeed
	{
		get { return this.rotationSpeed; }
		set { this.rotationSpeed = value; }
	}

	private float RotationPerFrame
	{
		get { return this.rotationSpeed * Time.deltaTime; }
	}
	
	private bool isStopped = false;
	

	void Awake ()
	{
		// Stop the referenced RotationController from rotating.

		if (this.rotationController != null)
		{
			this.rotationController.Stop();
		}
	}

	void Update ()
	{
		if (this.isStopped == true)
		{
			return;
		}
		
		Rotate();
	}
	
	private void Rotate ()
	{
		this.transform.Rotate(Vector3.forward, this.RotationPerFrame);
	}
	
	public void Stop ()
	{
		this.isStopped = true;
	}
}

