using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btn2 : MonoBehaviour
{
    public AudioSource src;
    public AudioClip[] sound;

    string[] txt_btn2 = { "pple", "alloon", "ar", "onkey", "lephant", "lower", "lasses", "oney", "nk", "ug", "ite", "eaf", "ilk", "et", "range", "encil", "uill", "ed", "poon", "rain", "niversity", "illage", "indow", "-ray", "arn", "ip" };
    public Text txt;
    private Button but;
    public static int count = 0;
    public Button next;
    private Button nx;

 
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(show);
        nx = next.GetComponent<Button>();
    }

   
    void Update()
    {
        
    }
    void show()
    {
        txt.text = txt_btn2[count];
        play();
        //txt.color = genRandomColor();

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
