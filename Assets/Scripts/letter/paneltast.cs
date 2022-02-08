using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paneltast : MonoBehaviour
{
    showletter sl;

    public GameObject img;
    public GameObject letterBut1;
    public GameObject letterBut2;
    public GameObject letterBut3;
    public GameObject check;
    public GameObject tx1;
    public GameObject tx2;
    public GameObject tx3;
    public GameObject shape;
    public GameObject bk;

    private Button but;

    public GameObject panel;

    public Sprite[] lettergroup1;
    public Sprite[] lettergroup2;
    public Sprite[] lettergroup3;

    public Sprite[] imaggroup1;
    public Sprite[] imaggroup2;
    public Sprite[] imaggroup3;

    string[] txt1 = { "pple", "alloon", "ar", "onkey", "lephant", "lower", "lasses", "oney", "nk" };
    string[] txt2 = { "ug", "ite", "eaf", "ilk", "et", "range", "encil", "uill", "ed" };
    string[] txt3 = { "poon", "rain", "niversity", "illage", "indow", "-ray", "arn", "ip" };

    string[] let1 = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
    string[] let2 = { "J", "K", "L", "M", "N", "O", "P", "Q", "R" };
    string[] let3 = { "S", "T", "U", "V", "W", "X", "Y", "Z" };

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject cup;

    public Sprite deflt;
    public Sprite right;
    public Sprite wrong;

    public AudioSource src;
    public AudioClip soundright;
    public AudioClip soundwrong;
    public AudioClip soundcong;

    int testnum = 0;

    public Text word;
    public Text misslet;

    public Button[] btn;
    int checkuiznum = 1;
    public static int checkuizcount = 0;
    int lt1, lt2;

    int randcorrectbtn;
    int randimg;

    public GameObject winIMG;

    void Start()
    {
        sl = GameObject.Find("Next").GetComponent<showletter>();
        img.SetActive(false);

        letterBut1.SetActive(false);
        letterBut2.SetActive(false);
        letterBut3.SetActive(false);
        check.SetActive(false);
        tx1.SetActive(false);
        tx2.SetActive(false);
        tx3.SetActive(false);
        shape.SetActive(false);
        bk.SetActive(false);


        but = GetComponent<Button>();
        but.onClick.AddListener(show);

        btn[0].onClick.AddListener(but1);
        btn[1].onClick.AddListener(but2);
        btn[2].onClick.AddListener(but3);
    }

    void show()
    {
        img.SetActive(false);

        letterBut1.SetActive(true);
        letterBut2.SetActive(true);
        letterBut3.SetActive(true);
        check.SetActive (true);
        tx1.SetActive(true);
        tx2.SetActive(true);
        tx3.SetActive(true);
        shape.SetActive(true);
        bk.SetActive(true);

        
        check.GetComponent<Button>().image.sprite = deflt;
        if (checkuiznum == 1)
        {
            
            randimg = Random.Range(0, 9);
            shape.GetComponent<Button>().image.sprite = imaggroup1[randimg];         /// choose the image of object of test

            randcorrectbtn = Random.Range(0, 2);                                    /// choose the button of correct answer
            btn[randcorrectbtn].image.sprite = lettergroup1[randimg];              /// put correct latter (answer) on button

            word.text = txt1[randimg];                                             /// show word of object
            misslet.text = "";                                                     /// missing letter empty

            lt1 = randimg + 2;
            lt2 = randimg - 2;

            if (randimg + 2 > 8) lt1 = 0;
            if (randimg - 2 < 0) lt2 = 8;

            if (randcorrectbtn == 0)                                              /// if correct letter on button 1
            {
                letterBut2.GetComponent<Button>().image.sprite = lettergroup1[lt1];                            /// put random letter on button 2
                letterBut3.GetComponent<Button>().image.sprite = lettergroup1[lt2];                            /// put random letter on button 3
            }
            else if (randcorrectbtn == 1)                                              /// if correct letter on button 2
            {
                letterBut1.GetComponent<Button>().image.sprite = lettergroup1[lt1];                            /// put random letter on button 1
                letterBut3.GetComponent<Button>().image.sprite = lettergroup1[lt2];                            /// put random letter on button 3
            }
            else                                                                  /// if correct letter on button 3
            {
                letterBut1.GetComponent<Button>().image.sprite = lettergroup1[lt1];                            /// put random letter on button 1
                letterBut2.GetComponent<Button>().image.sprite = lettergroup1[lt2];                            /// put random letter on button 2
            }
            checkuizcount++;
            but.enabled = false;

            if (checkuizcount == 4)
            {
                letterBut1.SetActive(false);
                letterBut2.SetActive(false);
                letterBut3.SetActive(false);
                check.SetActive(false);
                tx1.SetActive(false);
                tx2.SetActive(false);
                tx3.SetActive(false);
                shape.SetActive(false);
                bk.SetActive(false);

                star2.GetComponent<Button>().image.color = Color.blue;
                star3.GetComponent<Button>().image.color = Color.blue;

                playright(soundcong);
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                //cup.SetActive(true);
                but.enabled = true;

            }
            if (checkuizcount == 5)
            {
                checkuiznum = 2;
                checkuizcount = 0;
                uppanel();
            }
        }

        else if (checkuiznum == 2)
        {
            letterBut1.SetActive(true);
            letterBut2.SetActive(true);
            letterBut3.SetActive(true);
            check.SetActive(true);
            tx1.SetActive(true);
            tx2.SetActive(true);
            tx3.SetActive(true);
            shape.SetActive(true);
            bk.SetActive(true);

            randimg = Random.Range(0, 9);
            shape.GetComponent<Button>().image.sprite = imaggroup2[randimg];                              /// choose the image of object of test

            randcorrectbtn = Random.Range(0, 2);                                    /// choose the button of correct answer
            btn[randcorrectbtn].image.sprite = lettergroup2[randimg];              /// put correct latter (answer) on button

            word.text = txt2[randimg];                                             /// show word of object
            misslet.text = "";                                                     /// missing letter empty

            lt1 = randimg + 2;
            lt2 = randimg - 2;

            if (randimg + 2 > 8) lt1 = 0;
            if (randimg - 2 < 0) lt2 = 8;

            if (randcorrectbtn == 0)                                              /// if correct letter on button 1
            {
                letterBut2.GetComponent<Button>().image.sprite = lettergroup2[lt1];                            /// put random letter on button 2
                letterBut3.GetComponent<Button>().image.sprite = lettergroup2[lt2];                            /// put random letter on button 3

            }
            else if (randcorrectbtn == 1)                                              /// if correct letter on button 2
            {
                letterBut1.GetComponent<Button>().image.sprite = lettergroup2[lt1];                            /// put random letter on button 1
                letterBut3.GetComponent<Button>().image.sprite = lettergroup2[lt2];                            /// put random letter on button 3

            }
            else                                                                  /// if correct letter on button 3
            {
                letterBut1.GetComponent<Button>().image.sprite = lettergroup2[lt1];                            /// put random letter on button 1
                letterBut2.GetComponent<Button>().image.sprite = lettergroup2[lt2];                            /// put random letter on button 2
            }
            checkuizcount++;
            but.enabled = false;

            if (checkuizcount == 5)
            {
                letterBut1.SetActive(false);
                letterBut2.SetActive(false);
                letterBut3.SetActive(false);
                check.SetActive(false);
                tx1.SetActive(false);
                tx2.SetActive(false);
                tx3.SetActive(false);
                shape.SetActive(false);
                bk.SetActive(false);

                star2.GetComponent<Button>().image.color = Color.white;
                star3.GetComponent<Button>().image.color = Color.blue;

                playright(soundcong);
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
               //    cup.SetActive(true);
                but.enabled = true;

            }
            if (checkuizcount == 6)
            {
                checkuiznum = 3;
                checkuizcount = 0;
                uppanel();
            }
        }

        else
        {
            letterBut1.SetActive(true);
            letterBut2.SetActive(true);
            letterBut3.SetActive(true);
            check.SetActive(true);
            tx1.SetActive(true);
            tx2.SetActive(true);
            tx3.SetActive(true);
            shape.SetActive(true);
            bk.SetActive(true); 

            randimg = Random.Range(0, 8);
            shape.GetComponent<Button>().image.sprite = imaggroup3[randimg];                              /// choose the image of object of test

            randcorrectbtn = Random.Range(0, 2);                                    /// choose the button of correct answer
            btn[randcorrectbtn].image.sprite = lettergroup3[randimg];              /// put correct latter (answer) on button

            word.text = txt3[randimg];                                             /// show word of object
            misslet.text = "";                                                     /// missing letter empty

            lt1 = randimg + 2;
            lt2 = randimg - 2;

            if (randimg + 2 > 7) lt1 = 0;
            if (randimg - 2 < 0) lt2 = 7;

            if (randcorrectbtn == 0)                                              /// if correct letter on button 1
            {
                letterBut2.GetComponent<Button>().image.sprite = lettergroup3[lt1];                            /// put random letter on button 2
                letterBut3.GetComponent<Button>().image.sprite = lettergroup3[lt2];                            /// put random letter on button 3

            }
            else if (randcorrectbtn == 1)                                              /// if correct letter on button 2
            {
                letterBut1.GetComponent<Button>().image.sprite = lettergroup3[lt1];                            /// put random letter on button 1
                letterBut3.GetComponent<Button>().image.sprite = lettergroup3[lt2];                            /// put random letter on button 3

            }
            else                                                                  /// if correct letter on button 3
            {
                letterBut1.GetComponent<Button>().image.sprite = lettergroup3[lt1];                            /// put random letter on button 1
                letterBut2.GetComponent<Button>().image.sprite = lettergroup3[lt2];                            /// put random letter on button 2
            }
            checkuizcount++;
            but.enabled = false;

            if (checkuizcount == 5)
            {
                letterBut1.SetActive(false);
                letterBut2.SetActive(false);
                letterBut3.SetActive(false);
                check.SetActive(false);
                tx1.SetActive(false);
                tx2.SetActive(false);
                tx3.SetActive(false);
                shape.SetActive(false);
                bk.SetActive(false);

                star3.GetComponent<Button>().image.color = Color.white;

                playright(soundcong);
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                cup.SetActive(true);
                but.enabled = true;

            }
            if (checkuizcount == 6)
            {
                checkuiznum = 0;
                checkuizcount = 0;
                uppanel();
            }
        }
    
    }

    void but1()
    {
        if (randcorrectbtn == 0)
        {
            if (checkuiznum == 1) misslet.text = let1[randimg];
            else if (checkuiznum == 2) misslet.text = let2[randimg];
            else  misslet.text = let3[randimg];

            check.GetComponent<Button>().image.sprite = right;
            playright(soundright);
            but.enabled = true;
        }
        else
        {
            check.GetComponent<Button>().image.sprite = wrong;
            playright(soundwrong);

        }
    }

    void but2()
    {
        if (randcorrectbtn == 1)
        {
            if (checkuiznum == 1) misslet.text = let1[randimg];
            else if (checkuiznum == 2) misslet.text = let2[randimg];
            else  misslet.text = let3[randimg];

            check.GetComponent<Button>().image.sprite = right;
            playright(soundright);
            but.enabled = true;
        }
        else
        {
            check.GetComponent<Button>().image.sprite = wrong;
            playright(soundwrong);

        }
    }

    void but3()
    {
        if (randcorrectbtn == 2)
        {
            if (checkuiznum == 1) misslet.text = let1[randimg];
            else if (checkuiznum == 2) misslet.text = let2[randimg];
            else misslet.text = let3[randimg];

            check.GetComponent<Button>().image.sprite = right;
            playright(soundright);
            but.enabled = true;
        }
        else
        {
            check.GetComponent<Button>().image.sprite = wrong;
            playright(soundwrong);
        }
    }
    public void playright(AudioClip x)
    {
        src.PlayOneShot(x);
    }

    public void uppanel()
    {
        testnum++;
        letterBut1.SetActive(false);
        letterBut2.SetActive(false);
        letterBut3.SetActive(false);
        check.SetActive(false);
        tx1.SetActive(false);
        tx2.SetActive(false);
        tx3.SetActive(false);
        shape.SetActive(false);
        bk.SetActive(false);

        Animator anim = panel.GetComponent<Animator>();
        if (anim != null)
        {
            bool isdown = anim.GetBool("down");
            anim.SetBool("down", false);
        }
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        cup.SetActive(false);

        sl.l.SetActive(true);
        sl.b1.SetActive(true);
        sl.b2.SetActive(true);
        sl.b3.SetActive(true);
        GameObject.Find("Next").GetComponent<Button>().enabled = true;
        GameObject.Find("previous").GetComponent<Button>().enabled = true;
        but.enabled = false;

        if(testnum == 3)
        {
            StartCoroutine(win());
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
