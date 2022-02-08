using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class playSound : MonoBehaviour
{
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void play()
    {
        //btn.GetComponent<AudioSource>().enabled = false;
        //btn.GetComponent<AudioSource>().enabled = true;
        if(btn.name== "NumTxt")
        {
            btn.GetComponentInChildren<AudioSource>().volume = GameObject.Find("VolumSlider").GetComponent<Slider>().value;
            btn.GetComponentInChildren<AudioSource>().enabled = false;
            btn.GetComponentInChildren<AudioSource>().enabled = true;
        }
        else
        {
            btn.GetComponentInParent<AudioSource>().volume = GameObject.Find("VolumSlider").GetComponent<Slider>().value;
            btn.GetComponentInParent<AudioSource>().enabled = false;
            btn.GetComponentInParent<AudioSource>().enabled = true;
        }
        
    }
}
