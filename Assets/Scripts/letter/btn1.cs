using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btn1 : MonoBehaviour
{
    public AudioSource src;
    public AudioClip[] sound; 

    string[] txt_btn1 = { "irplane", "all", "andle", "og", "ggs", "ire", "iraffe", "at", "ce", "elly", "eys", "amp", "am", "est", "nion", "aint", "ueen", "adish", "nowman", "iger", "mbrella", "an", "all", "'mas", "ak", "ebra" };
    public Text txt;
    private Button but;
    public static int count = 0;
    public Button next;
    private Button nx;

    //string s = "";
 
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(show);
        nx = next.GetComponent<Button>();
    }

    void show()
    {
        txt.text = txt_btn1[count];
        play();
    }
    public void play()
    {
        src.PlayOneShot(sound[count]);
    }
    Color genRandomColor()
    {
        float r, g, b;
        r = UnityEngine.Random.Range(0f, 1f);
        g = UnityEngine.Random.Range(0f, 1f);
        b = UnityEngine.Random.Range(0f, 1f);

        return new Color(r, g, b);
    }

}
