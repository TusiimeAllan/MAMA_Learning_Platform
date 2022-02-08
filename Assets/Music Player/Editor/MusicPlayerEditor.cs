using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

[CustomEditor (typeof(MusicPlayer))]
public class MusicPlayerEditor :  Editor
{
		public override void OnInspectorGUI ()
		{
				SerializedObject attrib = new SerializedObject (target);
				MusicPlayer mp = (MusicPlayer)target;

				attrib.Update ();

				EditorGUILayout.Separator();
                #if !(UNITY_5 || UNITY_2017 || UNITY_2018_0 || UNITY_2018_1 || UNITY_2018_2)
					    //Unity 2018.3 or higher
					    EditorGUILayout.BeginHorizontal();
					    GUI.backgroundColor = Colors.cyanColor;
					    EditorGUILayout.Separator();
					    if (GUILayout.Button("Apply", GUILayout.Width(70), GUILayout.Height(30), GUILayout.ExpandWidth(false)))
					    {
						    PrefabUtility.ApplyPrefabInstance(mp.gameObject, InteractionMode.AutomatedAction);
					    }
					    GUI.backgroundColor = Colors.whiteColor;
					    EditorGUILayout.EndHorizontal();
                #endif

                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Please read the notes below", EditorStyles.boldLabel);
                EditorGUILayout.Separator ();

				EditorGUILayout.HelpBox ("!Important - The URL data must be an audio clip in Ogg (for Web/Standalones platforms), MP3 (for Phones Android/IOS platforms) or WAV ," +
                    " otherwise your Music will not be played for your selected platform. Note that the XM, IT, MOD or S3M format can also be streamed in, but realtime playback of these is not supported," +
                    " because all the data must be present before playback can begin.\n\nBefore you add the url , please make sure that it's valid and works correctly.\n\n" +
                    "When you use dropbox url , make sure to update url end 'dl=0' to 'dl=1' to make it downloadable file", MessageType.Info);
                EditorGUILayout.HelpBox ("Click on Add New Music Clip button to create new Music Clip in the list below", MessageType.Info);
				EditorGUILayout.HelpBox ("Important - Click on Apply button that located on the top to save your changes", MessageType.Info);
				EditorGUILayout.Separator ();

				GUILayout.BeginHorizontal ();
				GUI.backgroundColor = Colors.greenColor;         
				if (GUILayout.Button ("Add New Music Clip", GUILayout.Width (130), GUILayout.Height (20))) {
						mp.musicClips.Add (new MusicPlayer.MusicClip ());
				}
				GUI.backgroundColor = Colors.whiteColor;
				GUILayout.EndHorizontal ();

				EditorGUILayout.Separator ();
				mp.showContents = EditorGUILayout.Foldout (mp.showContents, "Music Clips");

				if (mp.showContents) {
						for (int i = 0; i < mp.musicClips.Count; i++) {
				
								EditorGUILayout.BeginHorizontal ();
								GUILayout.Space (10);
								EditorGUILayout.BeginVertical ();
								mp.musicClips [i].showContents = EditorGUILayout.Foldout (mp.musicClips [i].showContents, "Music Clip[" + i + "]");

								if (mp.musicClips [i].showContents) {
										EditorGUILayout.Separator ();
										GUI.backgroundColor = Colors.redColor;         
										if (GUILayout.Button ("Remove", GUILayout.Width (70), GUILayout.Height (20))) {
												bool isOk = EditorUtility.DisplayDialog ("Confirm Message", "Are you sure that you want to remove the selected item ?", "yes", "no");

												if (isOk) {
														mp.musicClips.RemoveAt (i);
														return;
												}
										}
										GUI.backgroundColor = Colors.whiteColor;
										EditorGUILayout.Separator ();
										mp.musicClips [i].type = (MusicPlayer.MusicClip.Type)EditorGUILayout.EnumPopup ("Type", mp.musicClips [i].type);
										EditorGUILayout.Separator ();

										if (mp.musicClips [i].type == MusicPlayer.MusicClip.Type.BUILT_IN || Application.isPlaying) {
												mp.musicClips [i].audioClip = EditorGUILayout.ObjectField ("Audio Clip", mp.musicClips [i].audioClip, typeof(AudioClip), true) as AudioClip;
										} else {
												mp.musicClips [i].audioType = (AudioType)EditorGUILayout.EnumPopup ("Audio Type", mp.musicClips [i].audioType);
												mp.musicClips [i].url = EditorGUILayout.TextField ("URL", mp.musicClips [i].url);
										}

										mp.musicClips [i].icon = EditorGUILayout.ObjectField ("Icon", mp.musicClips [i].icon, typeof(Sprite), true) as Sprite;
										mp.musicClips [i].name = EditorGUILayout.TextField ("Name", mp.musicClips [i].name);

										EditorGUILayout.Separator ();

										EditorGUILayout.BeginHorizontal ();

										EditorGUI.BeginDisabledGroup (i == mp.musicClips.Count - 1);
										if (GUILayout.Button ("▼", GUILayout.Width (22), GUILayout.Height (22))) {
												MoveDown (i, mp);
										}
										EditorGUI.EndDisabledGroup ();

										EditorGUI.BeginDisabledGroup (i - 1 < 0);
										if (GUILayout.Button ("▲", GUILayout.Width (22), GUILayout.Height (22))) {
												MoveUp (i, mp);
										}
										EditorGUI.EndDisabledGroup ();

										EditorGUILayout.EndHorizontal ();

										EditorGUILayout.Separator ();
										GUILayout.Box ("", GUILayout.ExpandWidth (true), GUILayout.Height (2));
								}
								EditorGUILayout.EndVertical ();
								EditorGUILayout.EndHorizontal ();
						}

						if (mp.musicClips.Count > 2) {
								EditorGUILayout.Separator ();
								GUILayout.BeginHorizontal ();
								GUI.backgroundColor = Colors.greenColor;         
								if (GUILayout.Button ("Add New Music Clip", GUILayout.Width (130), GUILayout.Height (20))) {
										mp.musicClips.Add (new MusicPlayer.MusicClip ());
								}
								GUI.backgroundColor = Colors.whiteColor;
								GUILayout.EndHorizontal ();
								EditorGUILayout.Separator ();
						}
				}

				EditorGUILayout.Separator ();

				EditorGUILayout.PropertyField (attrib.FindProperty ("audioSource"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("musicTime"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("soundLevelSlider"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("musicSlider"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("musicClipNumber"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("soundVolumeIcons"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("loopIcons"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("shuffleIcons"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("playIcon"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("pauseIcon"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("loadingIcon"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("loopButtonImage"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("shuffleButtonImage"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("downloadProgressImage"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("soundButtonImage"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("playButtonImage"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("playOnStart"), true);
				EditorGUILayout.PropertyField (attrib.FindProperty ("musicInfoAnimator"), true);

				attrib.ApplyModifiedProperties ();

				if (GUI.changed) {
						DirtyUtil.MarkSceneDirty ();
				}
		}

		private void MoveUp (int index, MusicPlayer mp)
		{
				MusicPlayer.MusicClip mc = mp.musicClips [index];
				mp.musicClips.RemoveAt (index);
				mp.musicClips.Insert (index - 1,mc);
		}

		private void MoveDown (int index, MusicPlayer mp)
		{
				MusicPlayer.MusicClip mc = mp.musicClips [index];
				mp.musicClips.RemoveAt (index);
				mp.musicClips.Insert (index+1,mc);
		}
}
