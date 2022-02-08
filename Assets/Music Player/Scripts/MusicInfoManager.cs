using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class MusicInfoManager : MonoBehaviour
{
		/// <summary>
		/// The music icon.
		/// </summary>
		public Image musicIcon;

		/// <summary>
		/// The music name.
		/// </summary>
		public Text musicName;

		/// <summary>
		/// The music info animator.
		/// </summary>
		public Animator musicInfoAnimator;

		// Use this for initialization
		void Start ()
		{
				if (musicInfoAnimator == null) {
						musicInfoAnimator = GetComponent<Animator> ();
				}

				ApplyInfo (0);
		}

		/// <summary>
		/// Set the music info.
		/// </summary>
		public void SetMusicInfo ()
		{
				if (MusicPlayer.instance.currentClipIndex >= 0 && MusicPlayer.instance.currentClipIndex < MusicPlayer.instance.musicClips.Count) {
						musicInfoAnimator.SetBool ("Toggle", false);
						ApplyInfo (MusicPlayer.instance.currentClipIndex);
				}
		}

		/// <summary>
		/// Apply the info.
		/// </summary>
		/// <param name="index">Index.</param>
		private void ApplyInfo (int index)
		{
				if (!(index >= 0 && index < MusicPlayer.instance.musicClips.Count)) {
						return;
				}

				musicIcon.sprite = MusicPlayer.instance.musicClips [index].icon;
				musicName.text = MusicPlayer.instance.musicClips [index].name;
		}
}