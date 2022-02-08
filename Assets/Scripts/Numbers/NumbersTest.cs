using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumbersTest : MonoBehaviour
{
    public Button[] btn;
    public Sprite[] sp;
    public AudioClip[] audio;
    public Text NumTxt;
    public Text scr;
    public Text statusTxt;
    public Button statusBtn;

    public AudioClip[] success;
    public AudioClip[] fail;
    public AudioSource Resultsound;

    private string[] numTxtStr = {"One","Two","Three","Four","Five","Six","Seven","Eight","Nine"};
    private int score;

    public GameObject winIMG;

    int FbtnRand;

    int scoreToWin = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        scr.text = "0";
        statusTxt.text = "Select The Correct Number..";
        btn[0].onClick.AddListener(btn0);
        btn[1].onClick.AddListener(btn1);
        btn[2].onClick.AddListener(btn2);
        show();
    }

    // Update is called once per frame
    void Update()
    {  
        if(score == scoreToWin)
        {
            StartCoroutine(win());
        }
    }

    void show()
    {
        NumTxt.GetComponent<AudioSource>().enabled = false;
        int rand = Random.Range(0, 8);
        FbtnRand = Random.Range(0, 2);
        NumTxt.text = numTxtStr[rand];
        NumTxt.GetComponent<AudioSource>().clip = audio[rand];
        //NumTxt.GetComponent<AudioSource>().enabled = true;
        btn[FbtnRand].image.sprite = sp[rand];
        ////////////////
        int SbtnRand = Random.Range(0, 2);
        while (SbtnRand == FbtnRand)
        {
            SbtnRand = Random.Range(0, 2);
        }
        int TbtnRand = btn.Length - (FbtnRand+SbtnRand);
        //////////////
        int spRand;
        int firstsp = 0;
        for (int i=0; i<=1; i++)
        {
            spRand = Random.Range(0, 8);
            if (i == 0)
            {
                while (spRand == rand)
                {
                    spRand = Random.Range(0, 8);
                    firstsp = spRand;
                }
            }
            else
                {
                    while (spRand == rand || spRand == firstsp)
                    {
                        spRand = Random.Range(0, 8);
                    }
                }

            if (i == 0)
            {
                btn[SbtnRand].image.sprite = sp[spRand];
                firstsp = spRand;
            }
            else
            {
                btn[TbtnRand].image.sprite = sp[spRand];
            }
        }
    }

    void btn0()
    {
        if(FbtnRand == 0)
        {
            score += 10;
            scr.text = score.ToString();
            statusBtn.image.color = Color.green;
            statusTxt.text = "Good :)";
            Resultsound.clip = success[Random.Range(0, success.Length)];
            Resultsound.Play();
            if (score < scoreToWin)
            {
                show();
            }
        }
        else
        {
            statusBtn.image.color = Color.red;
            Resultsound.clip = fail[Random.Range(0, fail.Length)];
            Resultsound.Play();
            statusTxt.text = "Try again :(";
        }
    }
    void btn1()
    {
        if (FbtnRand == 1)
        {
            score += 10;
            scr.text = score.ToString();
            statusBtn.image.color = Color.green;
            statusTxt.text = "Good :)";
            Resultsound.clip = success[Random.Range(0, success.Length)];
            Resultsound.Play();
            if (score < scoreToWin)
            {
                show();
            }
        }
        else
        {
            statusBtn.image.color = Color.red;
            Resultsound.clip = fail[Random.Range(0, fail.Length)];
            Resultsound.Play();
            statusTxt.text = "Try again :(";
        }
    }
    void btn2()
    {
        if (FbtnRand == 2)
        {
            score += 10;
            scr.text = score.ToString();
            statusBtn.image.color = Color.green;
            statusTxt.text = "Good :)";
            Resultsound.clip = success[Random.Range(0, success.Length)];
            Resultsound.Play();
            if (score < scoreToWin)
            {
                show();
            }
        }
        else
        {
            statusBtn.image.color = Color.red;
            Resultsound.clip = fail[Random.Range(0, fail.Length)];
            Resultsound.Play();
            statusTxt.text = "Try again :(";
        }
    }

    public void StopTime(int x)
    {
        Time.timeScale = x;
    }

    IEnumerator win()
    {
        winIMG.GetComponent<Image>().enabled = true;
        winIMG.GetComponent<Animator>().enabled = true;
        winIMG.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("afterPlay");
    }
}
