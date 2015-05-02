using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	//runs when object is created
	void Start(){
		audio.Play();//playes audioclip
	}
	//runs every frame
	void Update(){
	}
	//runs when called during the animation
	public void DestroyMe(){	//destroys itself
		GameObject.Destroy (this.gameObject);
	}
}
