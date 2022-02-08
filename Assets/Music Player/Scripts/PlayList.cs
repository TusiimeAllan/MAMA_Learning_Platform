using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class PlayList : MonoBehaviour
{
		/// <summary>
		/// The play list item prefab.
		/// </summary>
		public GameObject playListItemPrefab;

		/// <summary>
		/// The play list item parent.
		/// </summary>
		public Transform playListItemParent;

		/// <summary>
		/// The play list items.
		/// </summary>
		public List<PlayListItem> playListItems = new List<PlayListItem> ();

		/// <summary>
		/// The static instance of this class.
		/// </summary>
		public static PlayList instance;

		void Awake ()
		{
				if (instance == null) {
						instance = this;
				}
		}

		// Use this for initialization
		void Start ()
		{
				//Create the items of the play list based on the music clips of the music player
				for (int i = 0; i < MusicPlayer.instance.musicClips.Count; i++) {
						if (MusicPlayer.instance.musicClips [i].type == MusicPlayer.MusicClip.Type.BUILT_IN) {
								AddNewItem (MusicPlayer.instance.musicClips [i], i);
						} else if (MusicPlayer.instance.musicClips [i].type == MusicPlayer.MusicClip.Type.URL) {
								MusicPlayer.instance.musicClips [i].audioClip = null;
								AddNewItem (MusicPlayer.instance.musicClips [i], i);
						}
				}
		}

		void Update ()
		{

		}

		/// <summary>
		/// Add new item.
		/// </summary>
		/// <param name="musicClip">Music clip.</param>
		/// <param name="index">Index reference.</param>
		public void AddNewItem (MusicPlayer.MusicClip musicClip, int index)
		{
				GameObject itemGameObject = Instantiate (playListItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
				itemGameObject.transform.SetParent (playListItemParent);
				itemGameObject.transform.localScale = Vector3.one;
				itemGameObject.name = "Item" + index;

				PlayListItem playListItemComp = itemGameObject.GetComponent<PlayListItem> ();
				playListItemComp.SetName (musicClip.name);
				playListItemComp.SetNumber ((index + 1) + ".");
				if (musicClip.audioClip != null)
						playListItemComp.SetLength (CommonUtil.TimeToString (musicClip.audioClip.length));
				playListItemComp.index = index;

				playListItems.Add (playListItemComp);
		}

		/// <summary>
		/// Select the item of the given index.
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="isPlayable">Whether current list item is playable or not.</param>
		public void SelectItem (int index,bool isPlayable)
		{
			playListItems [index].SetSelected (isPlayable);
		}

		/// <summary>
		/// UnSselect the item of the given index.
		/// </summary>
		/// <param name="index">Index of item.</param>
		public void UnSelectItem (int index)
		{
				playListItems [index].SetUnSelected ();
		}

		/// <summary>
		/// Set the play icon for an item of the given index.
		/// </summary>
		/// <param name="index">Index of item.</param>
		public void SetPlayIcon (int index)
		{
				playListItems [index].SetPlayIcon ();
		}

		/// <summary>
		/// Set the pause icon for an item of the given index.
		/// </summary>
		/// <param name="index">Index of item.</param>
		public void SetPauseIcon (int index)
		{
				playListItems [index].SetPauseIcon ();
		}

		/// <summary>
		/// Get a play list item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="index">Index of play the list item.</param>
		public PlayListItem GetItem(int index){
				if (!(index >= 0 && index < playListItems.Count)) {
						return null;
				}

				return playListItems [index];
		}
}
