using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; 
public class WRPGuiManager : MonoBehaviour {

	
	public string videoName = "video_test";	// Type the name of your video here
	public float positionX = 400.0f;		// X postion for skip button
	public float positionY = 100.0f;		// Y position for skip button
	
	
	void Update () 
	{
		ButtonHeight = Screen.height/5;
		ButtonWidth =  Screen.width/2-20;
	}
	
	float ButtonHeight = Screen.height/5;
	float ButtonWidth = Screen.width/2-20;
	void OnGUI ()
	{
		GUI.color = Color.black;
		float ButtonPosx = 10;
		float ButtonPosy = 10;
		GUI.color = Color.white;
		if(GUI.Button(new Rect(ButtonPosx,ButtonPosy,ButtonWidth,ButtonHeight),"Play Movie"))
		{
			WRPAndroidVideoPlayerBinding.PlayVideo(videoName);
		}
		
		ButtonPosx += ButtonWidth+10;
		if(GUI.Button(new Rect(ButtonPosx,ButtonPosy,ButtonWidth,ButtonHeight),"Play Movie with Skip Button"))
		{
			WRPAndroidVideoPlayerBinding.PlayVideo(videoName, 0, 0);
		}
	}
}