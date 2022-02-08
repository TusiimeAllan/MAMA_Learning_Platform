using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class SoundIconManager : MonoBehaviour
{
		/// <summary>
		/// The sound level slider reference.
		/// </summary>
		public Slider soundLevelSlider;

		/// <summary>
		/// The sound button image reference.
		/// </summary>
		public Image soundButtonImage;

		// Use this for initialization
		void Start ()
		{
				//Setting up the referecnes
				if (soundButtonImage == null) {
						soundButtonImage = GetComponent<Image> ();
				}

				if (soundLevelSlider == null) {
						soundLevelSlider = GameObject.FindGameObjectWithTag ("SoundLevelSlider").GetComponent<Slider> ();
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Check whether the music player is muted or not
				if (!MusicPlayer.instance.Muted) {
						//Set the sound icon relative to the value of sound level slider
						if (soundLevelSlider.value >= 0.6f) {
								soundButtonImage.sprite = MusicPlayer.instance.soundVolumeIcons [0];
						} else if (soundLevelSlider.value >= 0.3f && soundLevelSlider.value < 0.6f) {
								soundButtonImage.sprite = MusicPlayer.instance.soundVolumeIcons [1];
						} else if (soundLevelSlider.value > 0 && soundLevelSlider.value < 0.3f) {
								soundButtonImage.sprite = MusicPlayer.instance.soundVolumeIcons [2];
						} else if (soundLevelSlider.value == 0) {
								soundButtonImage.sprite = MusicPlayer.instance.soundVolumeIcons [3];
						}
				}
		}
}