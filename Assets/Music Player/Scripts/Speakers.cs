using UnityEngine;
using System.Collections;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class Speakers : MonoBehaviour
{
		/// <summary>
		/// The samples number.
		/// </summary>
		[Range (0, 100)]
		public int samplesNum = 15;
		
		/// <summary>
		/// The scale factor.
		/// </summary>
		[Range (0, 10)]
		public float scaleFactor = 1;

		/// <summary>
		/// The scale range of the speakers.
		/// </summary>
		public Vector2 scaleRange;

		/// <summary>
		/// The specturms manager reference.
		/// </summary>
		public SpectrumsManager specturmsManager;

		/// <summary>
		/// The speakers references.
		/// </summary>
		public Transform[] speakers;

		/// <summary>
		/// Temp scale.
		/// </summary>
		private Vector3 tempScale;

		/// <summary>
		/// The scale of the speakers.
		/// </summary>
		private float scale;

		void Start ()
		{
				if (specturmsManager == null) {
						Debug.Log ("Spectrums Manager is undefined in <i>" + name + "</i>");
				}
		}

		// Update is called once per frame
		void Update ()
		{
				if (specturmsManager == null) {
						return;
				}

				//Check whether the samplesNum is in the samples array range
				if (samplesNum >= 0 && samplesNum < specturmsManager.samples.Length) {
						scale = 0;
						///Calculate the scale of the speakers using specturm samples values
						for (int i = 0; i < samplesNum; i++) {
								scale += specturmsManager.samples [i] * scaleFactor;
						}
				}

				//Clamp the scale value
				scale = Mathf.Clamp (scale, scaleRange.x, scaleRange.y);

				//Apply the scale on the speakers
				foreach (Transform trans in speakers) {
						tempScale.x = tempScale.y = scale;
						tempScale.z = 1;
						trans.localScale = tempScale;
				}
		}
}