using UnityEngine;
using System.Collections;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

[DisallowMultipleComponent]
public class UIEvents : MonoBehaviour
{
		public void PlayButtonEvent ()
		{
				if (MusicPlayer.instance.IsPlaying && !MusicPlayer.instance.Interrupted) {
						MusicPlayer.instance.PauseAudioClip ();
				} else if (!MusicPlayer.instance.IsPlaying && MusicPlayer.instance.Interrupted) {
						MusicPlayer.instance.PlayAudioClip ();
				}
		}

		public void StopButtonEvent ()
		{
				MusicPlayer.instance.StopMusicAudioClip ();
		}

		public void SoundButtonEvent ()
		{
				if (MusicPlayer.instance.Muted) {
						MusicPlayer.instance.UnMuteAudioClip ();
				} else {
						MusicPlayer.instance.MuteAudioClip ();
				}
		}

		public void LoopButtonEvent ()
		{
				MusicPlayer.instance.ToggleLoop ();
		}

		public void ShuffleButtonEvent ()
		{
				MusicPlayer.instance.ToggleShuffle ();
		}

		public void NextMusicButtonEvent ()
		{
				MusicPlayer.instance.NextMusicClip ();
		}

		public void PreviousMusicButtonEvent ()
		{
				MusicPlayer.instance.PreviousMusicClip ();
		}

		public void SoundLevelSliderPotentialDrag ()
		{
				MusicPlayer.instance.UnMuteAudioClip ();
		}

		public void MusicSliderClick ()
		{
				if (MusicPlayer.instance.IsPlaying) {
						MusicPlayer.instance.clickBeganOnMusicSlider = false;
						MusicPlayer.instance.PlayAudioClipAtTime (MusicPlayer.instance.musicSlider.value);
				}
		}

		public void MusicSliderPotentialDrag ()
		{
				MusicPlayer.instance.clickBeganOnMusicSlider = true;
		}

		public void MusicSliderEndDrag ()
		{
				if (MusicPlayer.instance.clickBeganOnMusicSlider) {
						MusicPlayer.instance.clickBeganOnMusicSlider = false;
						if (MusicPlayer.instance.IsPlaying) {
								MusicPlayer.instance.PlayAudioClipAtTime (MusicPlayer.instance.musicSlider.value);
						}
				}
		}
}