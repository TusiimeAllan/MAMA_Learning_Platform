using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

[DisallowMultipleComponent]
public class MusicTime : MonoBehaviour
{
		/// <summary>
		/// The time text.
		/// </summary>
		public Text timeText;

		// Use this for initialization
		void Start ()
		{
				//Setting up the references
				if (timeText == null) {
						timeText = GetComponent<Text> ();
				}
		}

		/// <summary>
		/// Set the time.
		/// </summary>
		/// <param name="time">Time.</param>
		/// <param name="totalTime">Total time.</param>
		public void SetTime (float time, string totalTime)
		{
				if (timeText == null) {
						return;
				}

				timeText.text = CommonUtil.TimeToString (time) + " / " + totalTime;
		}
}