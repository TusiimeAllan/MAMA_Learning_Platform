using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

[DisallowMultipleComponent]
public class SceneLoader : MonoBehaviour
{
		/// <summary>
		/// The name of the scene.
		/// </summary>
		public string sceneName;

		/// <summary>
		/// The delay time before loading the scene.
		/// </summary>
		public float sleepTime;

		// Use this for initialization
		void Start ()
		{
				Invoke ("LoadScene", sleepTime);				
		}

		private void LoadScene ()
		{
				if (!string.IsNullOrEmpty (sceneName)) {
						SceneManager.LoadScene (sceneName);
				}
		}
}
