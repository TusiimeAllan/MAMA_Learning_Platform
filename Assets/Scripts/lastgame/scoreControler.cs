using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreControler : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public int wrongAnswersCounter = 0;
    public GameObject gameOver;
    spawner spawn;
    shooting shot;
    public GameObject winIMG;

    public Image H1;
    public Image H2;
    public Image H3;

    spawner sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GameObject.Find("Canvas").GetComponent<spawner>();
        scoreText.text = score.ToString();
        spawn = GameObject.Find("Canvas").GetComponent<spawner>();
        shot = GameObject.Find("dart").GetComponent<shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if (wrongAnswersCounter == 1)
        {
            H1.color = new Color32(255, 255, 255, 112);
        }
        else if (wrongAnswersCounter == 2)
        {
            H2.color = new Color32(255, 255, 255, 112);
        }
        else if (wrongAnswersCounter == 3)
        {
            H3.color = new Color32(255, 255, 255, 112);
        }
        if (wrongAnswersCounter >= 3)
        {
            gameOver.SetActive(true);
            sp.stopBallon = true;
            spawn.StopTime(0);
            shot.StartShoot(false);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadSceneAsync("game");
            }
        }
        if(score == 100)
        {
            StartCoroutine(win());
        }
    }

    IEnumerator win()
    {
        winIMG.GetComponent<Image>().enabled = true;
        winIMG.GetComponent<Animator>().enabled = true;
        winIMG.GetComponent<AudioSource>().enabled = true;
        sp.stopBallon = true;
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync("afterPlay");
    }
}
