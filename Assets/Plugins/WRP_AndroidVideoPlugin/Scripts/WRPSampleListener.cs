using UnityEngine;
using System.Collections;

public class WRPSampleListener : MonoBehaviour
{

	void Start ()
	{
		//WRPAndroidVideoPlayerBinding.onVideoPlaybackCompleteEvent += VideoPlayBackCompletedNormally;
		//WRPAndroidVideoPlayerBinding.onVideoEndBySkipEvent += VideoPlaybackEndedBySkipButton;
		//WRPAndroidVideoPlayerBinding.onVideoEndByMinimizeEvent += onVideoEndByMinimizing;
	}
	
	void VideoPlayBackCompletedNormally()
	{
		Debug.Log( "Video playback complete" );
	}
	
	void VideoPlaybackEndedBySkipButton()
	{
		Debug.Log( "Video playback ended by Skip Button" );
	}

	void onVideoEndByMinimizing()
	{
		Debug.Log( "Video playback ended by Minimizing" );
	}
}
