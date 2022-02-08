using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class WRPAndroidVideoPlayerBinding  : MonoBehaviour {

	void Start () {
		
		// Should be called before using any Android Video Player function
		// To receive callbacks
		
		if( ( gameObject != null ) && ( gameObject.name != null ) )
		{
			if( !Application.isEditor )
			{
				using (AndroidJavaClass ajc = new AndroidJavaClass ("com.werplay.androidvideoplayerbasic.CallActivity"))
				{
					using (AndroidJavaObject ajo = ajc.CallStatic <AndroidJavaObject> ("getInstance"))
					{
						ajo.Call ("setObjectName", gameObject.name);
					}
				}

			}
		}
	}

	
	//Play Video with the given name
	//The video file must be placed in the Assets>Plugins>Android>res>raw folder
	//Leave out the file extension from the video name when calling this function
	//e.g. PlayVideo( video_test ) to play video_test.mp4
	public static void PlayVideo( string name )
	{
		Debug.Log( "playVideo" );
	
		if ( !Application.isEditor )
		{
			if(name.Length > 0)
			{
				using (AndroidJavaClass ajc = new AndroidJavaClass ("com.werplay.androidvideoplayerbasic.CallActivity"))
				{
					using (AndroidJavaObject ajo = ajc.CallStatic <AndroidJavaObject> ("getInstance"))
					{
						ajo.Call("playVideo", name);
					}
				}
			}
			else
			{
				Debug.Log("Error: invalid file name");
			}
		}
	}
	

	// Play a video from "Assets>Plugins>Android>res>raw" and just call this function with the name of the video file without extension + the top left pixal position of the skip button.
	//Play Video of given name while also showing the skip button
	//The video file must be placed in the Assets>Plugins>Android>res>raw folder
	//Leave out the file extension from the video name when calling this function
	//e.g. PlayVideo( video_test ) to play video_test.mp4
	//
	//xPosition and yPosition set the position of the Skip Button on the screen
	public static void PlayVideo( string name, float xPosition, float yPosition )
	{
		Debug.Log( "playVideo with Skip Button" );
		
		if ( !Application.isEditor )
		{
			if(name != null)
			{
				using (AndroidJavaClass ajc = new AndroidJavaClass ("com.werplay.androidvideoplayerbasic.CallActivity"))
				{
					using (AndroidJavaObject ajo = ajc.CallStatic <AndroidJavaObject> ("getInstance"))
					{

						ajo.Call("playVideoWithButton", name, xPosition, yPosition);
					}
				}
			}
			else
			{
				Debug.Log("Error: invalid file name");
			}	
		}
	} 
	
	#if UNITY_ANDROID
	public static event Action onVideoPlaybackCompleteEvent;
	public static event Action onVideoEndBySkipEvent;
	public static event Action onVideoEndByMinimizeEvent;

	//Called when the video playback is complete either because the video reached its end
	//or the Skip Button was pushed
	//The argument msg contains:
	//the string "Done" for video reaching its end;
	//the string "Skip" for when the Skip button is tapped
	//the string "Minimize" for when the video is Minimized
	public void VideoDonePlaying( string msg )
	{
		if( msg == "Done" )
		{
			if( onVideoPlaybackCompleteEvent != null )
			{
				onVideoPlaybackCompleteEvent();
			}
		}
		else if( msg == "Skip" )
		{
			if( onVideoEndBySkipEvent != null )
			{
				onVideoEndBySkipEvent();
			}
		}
		else if (msg == "Minimize")
		{
			if(onVideoEndByMinimizeEvent != null)
			{
				onVideoEndByMinimizeEvent();
			}
		}
	}

	#endif
}
