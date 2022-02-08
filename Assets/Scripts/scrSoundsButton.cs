using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrSoundsButton : MonoBehaviour
{

    public Sprite sprOn, sprOff;
    bool swapped = false;
    Button myButton;
    public AudioSource myAudio;

    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    public void OnClick()
    {

        swapped = !swapped;

        if (swapped)
        {
            myAudio.mute = true;
            myButton.image.sprite = sprOff;
        }
        else
        {
            myAudio.mute = false;
            myButton.image.sprite = sprOn;
        }


    }
}
