using UnityEngine;
using System.Collections;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class DirtyUtil
{
		public static void MarkSceneDirty ()
		{
			#if UNITY_EDITOR
				if(!EditorSceneManager.GetActiveScene().isDirty && !Application.isPlaying){
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene()); 
				}
			#endif
		}
}