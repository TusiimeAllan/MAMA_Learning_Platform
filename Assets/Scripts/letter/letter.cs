using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class letter : MonoBehaviour
{
    public static int count = 0;

    public AudioSource src;
    public AudioClip[] sound;

    private Button but;
    public Button next;
    private Button nx;

    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(show);
        nx = next.GetComponent<Button>();
    }
    void show()
    {
        play();
    }
    public void play()
    {
        src.PlayOneShot(sound[count]);
    }
}
