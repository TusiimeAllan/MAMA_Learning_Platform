using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btn3 : MonoBehaviour
{

    public AudioSource src;
    public AudioClip[] sound;

    string[] txt_btn3 = { "rm", "oat", "hicken", "oor", "yes", "ork", "oat", "orse", "sland", "uice", "iwi", "ion", "oon", "ut", "ven", "ie", "uilt", "obot", "tar", "ree", "rn", "iolin", "orm", "ylophone", "ogurt", "oo" };
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
        txt.text = txt_btn3[count];
        play();
       // txt.color = genRandomColor();

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
