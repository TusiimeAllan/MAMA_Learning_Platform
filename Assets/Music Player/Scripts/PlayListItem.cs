using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class PlayListItem : MonoBehaviour
{
		/// <summary>
		/// The number reference of the item.
		/// </summary>
		public Text itemNumber;

		/// <summary>
		/// The name reference of the item.
		/// </summary>
		public Text itemName;

		/// <summary>
		/// The length reference of the item.
		/// </summary>
		public Text itemLength;

		/// <summary>
		/// The cover reference of the item.
		/// </summary>
		public Image cover;

		/// <summary>
		/// The play button image.
		/// </summary>
		public Image playButtonImage;

		/// <summary>
		/// The index of the item.
		/// </summary>
		public int index = -1;

		/// <summary>
		/// www instance, used to stream music files.
		/// </summary>
		private static WWW www;

		/// <summary>
		/// The initial length (total time).
		/// </summary>
		private string initalLength = "";

		// Use this for initialization
		void Start ()
		{
		}

		/// <summary>
		/// Set the number of the item.
		/// </summary>
		/// <param name="value">Value.</param>
		public void SetNumber (string value)
		{
				itemNumber.text = value;
		}

		/// <summary>
		/// Set the name of the item.
		/// </summary>
		/// <param name="value">Value.</param>
		public void SetName (string value)
		{
				itemName.text = value;
		}

		/// <summary>
		/// Set the length of the item.
		/// </summary>
		/// <param name="value">Value.</param>
		public void SetLength (string value)
		{
				itemLength.text = value;
		}

		/// <summary>
		/// Set the item as selected.
		/// </summary>
		public void SetSelected (bool isPlayable)
		{
				if(isPlayable)
					SetPauseIcon ();
				cover.enabled = true;
		}

		/// <summary>
		/// Set the item as unselected.
		/// </summary>
		public void SetUnSelected ()
		{
				SetPlayIcon ();
				cover.enabled = false;
				if (MusicPlayer.instance.musicClips [index].type == MusicPlayer.MusicClip.Type.URL) {
						//Destroy audio clip, to be streamed once more from the url
						MusicPlayer.instance.currentAudioClip = null;
						Destroy (MusicPlayer.instance.musicClips [index].audioClip);
				}
		}

		/// <summary>
		/// Set the play icon.
		/// </summary>
		public void SetPlayIcon ()
		{
				if (MusicPlayer.instance.musicClips [index].audioClip != null)
						playButtonImage.sprite = MusicPlayer.instance.playIcon;
		}

		/// <summary>
		/// Set the pause icon.
		/// </summary>
		public void SetPauseIcon ()
		{
				if (MusicPlayer.instance.musicClips [index].audioClip != null)
						playButtonImage.sprite = MusicPlayer.instance.pauseIcon;
		}


		/// <summary>
		/// Play button click event.
		/// </summary>
		public void PlayButtonClickEvent ()
		{
				if (MusicPlayer.instance.musicClips [index].audioClip == null) {
						if (MusicPlayer.instance.musicClips [index].type == MusicPlayer.MusicClip.Type.URL) {
								MusicPlayer.instance.SetUpMusicAudioClip (index, true);
						}
						return;
				}

				if (MusicPlayer.instance.musicClips [MusicPlayer.instance.currentClipIndex].audioClip.GetInstanceID () != MusicPlayer.instance.musicClips [index].audioClip.GetInstanceID ()) {
						MusicPlayer.instance.SetUpMusicAudioClip (index, true);
						return;
				}

				if (MusicPlayer.instance.IsPlaying && !MusicPlayer.instance.Interrupted) {
						MusicPlayer.instance.PauseAudioClip ();
				} else if (!MusicPlayer.instance.IsPlaying && MusicPlayer.instance.Interrupted) {
						MusicPlayer.instance.PlayAudioClip ();
				}
		}

		/// <summary>
		/// Whether the clip downloaded or not from the url.
		/// </summary>
		public static bool AudioClipDownloaded(){
				return www == null ? false : www.isDone;
		}

		/// <summary>
		/// Get audio clip download progress.
		/// </summary>
		/// <returns>The download progress.</returns>
		public static float GetAudioClipDownloadProgress(){
				return www == null ? -1 : www.progress;
		}

		/// <summary>
		/// Load the audio clip from URL.
		/// </summary>
		public void LoadAudioClipFromURL(bool isPlayable){
				StopAllCoroutines ();
				StartCoroutine (LoadAudioClipFromURLCoroutine (MusicPlayer.instance.musicClips [index].url, MusicPlayer.instance.musicClips [index].audioType,isPlayable));
		}

		/// <summary>
		/// Load the audio clip from URL Coroutine.
		/// </summary>
		private IEnumerator LoadAudioClipFromURLCoroutine (string url, AudioType audioType,bool isPlayable)
		{
				yield return 0;

                #if (UNITY_5 || UNITY_2017)
                      float progressLimit = 0.05f;
                #else
                      float progressLimit = 1;
                #endif

                if (!string.IsNullOrEmpty (url)) {

						Debug.Log ("Streaming new Audio Clip");

						SetLength ("Streaming...");
						playButtonImage.GetComponent<Button> ().interactable = false;
						playButtonImage.sprite = MusicPlayer.instance.loadingIcon;
						playButtonImage.GetComponent<Rotate> ().interactable = true;

						www = new WWW (url);

						while (www.progress < progressLimit) {
								yield return null;
						}

						if (string.IsNullOrEmpty (www.error)) {
								AudioClip audioClip = www.GetAudioClip (false, true, audioType);
								MusicPlayer.instance.musicClips [index].audioClip = audioClip;
								ResetAttributes ();

								MusicPlayer.instance.audioSource.clip = audioClip;
								MusicPlayer.instance.currentAudioClip = audioClip;
								MusicPlayer.instance.SetUpTotalTime ();
								if(isPlayable)
									MusicPlayer.instance.PlayAudioClip();

								if (string.IsNullOrEmpty (initalLength)) {
										initalLength = CommonUtil.TimeToString (audioClip.length);
								}
						} else {
								ResetAttributes ();
								Debug.Log (www.error);
						}
				}
		}

		/// <summary>
		/// Reset the attributes of the play list item.
		/// </summary>
		private void ResetAttributes(){
				if (MusicPlayer.instance.musicClips [index].audioClip != null) {
						SetLength (CommonUtil.TimeToString (MusicPlayer.instance.musicClips [index].audioClip.length));
				} else {
						if (!string.IsNullOrEmpty (initalLength)) {
								SetLength (initalLength);
						} else {
								SetLength ("00:00");
						}
				}
				playButtonImage.GetComponent<Button> ().interactable = true;
				playButtonImage.sprite = MusicPlayer.instance.playIcon;
				playButtonImage.GetComponent<Rotate> ().interactable = false;
				playButtonImage.transform.eulerAngles = Vector3.zero;
		}

		/// <summary>
		/// Reset this instance.
		/// </summary>
		public void Reset(){
			StopAllCoroutines ();
			ResetAttributes ();
		}
}