using UnityEngine;
using System.Collections;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class ParticlesRandomColor : MonoBehaviour
{
		/// <summary>
		/// The particle system component.
		/// </summary>
		public ParticleSystem ps;

		/// <summary>
		/// The alpha of the color.
		/// </summary>
		[Range(0,255)]
		public float alpha = 126;

		/// <summary>
		/// The is running flag.
		/// </summary>
		public bool isRunning;

		/// <summary>
		/// The sleep time.
		/// </summary>
		private float sleepTime = 0.5f;

		// Use this for initialization
		IEnumerator Start ()
		{
				while (isRunning) {
						if (GetComponent<ParticleSystem>() != null) {
								//Create new random color
								ps.startColor = new Color (Random.Range (0, 255), Random.Range (0, 255), Random.Range (0, 255), alpha) / 255.0f;
						}
						yield return new WaitForSeconds (sleepTime);
				}
		}
}