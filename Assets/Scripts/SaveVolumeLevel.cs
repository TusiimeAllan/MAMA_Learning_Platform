using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveVolumeLevel : MonoBehaviour
{
     public Slider volum;
     public Slider music;

     AudioSource aud;

     public static float vol = 0.50f;
     public static float mus = 0.10f;

     public static float time = 0;

    public bool op = false;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.time = time;

        volum.value = vol;
        music.value = mus;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        vol = volum.value;
        mus = music.value;
        time = aud.time;
        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().name != "MainMenu"  && op == false)
        {
            GameObject.Find("Optionbtn").GetComponent<Button>().onClick.Invoke();
            op = true;
        }
    }

    public void Setfalse()
    {
        op = false;
    }
}
