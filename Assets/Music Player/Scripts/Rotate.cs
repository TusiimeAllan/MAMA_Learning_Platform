using UnityEngine;
using System.Collections;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class Rotate : MonoBehaviour {

	/// <summary>
	/// The rotation speed.
	/// </summary>
	public float speed = 10;

	/// <summary>
	/// Whether to rotate or not.
	/// </summary>
	public bool interactable = true;

	/// <summary>
	/// The direction vector.
	/// </summary>
	private Vector3 direction = new Vector3 (0, 0, 1);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
				
		if (interactable) {
			transform.Rotate (direction * speed * Time.deltaTime);
		}
	}
}
