using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showletter : MonoBehaviour
{
    

    public static int count = 1;
    public static int quizcount = 1;

    public GameObject img;

    private Button but;
    public Button TheLetter;
    public Sprite[] let;
    public Sprite[] obj1;
    public Sprite[] obj2;
    public Sprite[] obj3;

    

    public AudioSource src;
    public AudioClip[] letsound;

    string[] txt_btn1= { "irplane", "all" ,"andle","og","ggs","ire","iraffe","at","ce","elly","eys","amp","am","est","nion","aint","ueen","adish", "nowman" , "iger" ,"mbrella", "an", "all" ,"'mas","ak", "ebra" };
    string[] txt_btn2 ={ "pple", "alloon", "ar", "onkey", "lephant", "lower", "lasses", "oney", "nk", "ug", "ite", "eaf", "ilk", "et", "range", "encil", "uill", "ed", "poon", "rain", "niversity", "illage", "indow", "-ray", "arn", "ip" };
    string[] txt_btn3 ={ "rm", "oat", "hicken", "oor", "yes", "ork", "oat", "orse", "sland", "uice", "iwi", "ion", "oon", "ut", "ven", "ie", "uilt", "obot", "tar", "ree", "rn", "iolin", "orm", "ylophone", "ogurt", "oo" };

    public Text wordxt;

    public GameObject l;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    // private Button btn1,btn2,btn3;


    //---------------------
    

    public GameObject panel;
    int x = 1;

    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(show);

    }

    void show()
    {
        if (count == 10 || count == 19 || count == 26)
        {
            Debug.Log("X =" + x + " count = "+count);
            img.SetActive(true);
            l.SetActive(false);
            b1.SetActive(false);
            b2.SetActive(false);
            b3.SetActive(false);
            wordxt.text = "";
            if (x < count)
            {
                pannel();
                but.enabled = false;
                GameObject.Find("previous").GetComponent<Button>().enabled = false;
                GameObject.Find("next").GetComponent<Button>().enabled = true;
                if (count == 26) {
                    count++;
                }
            }
        }
        if(count < 26)
        {
            TheLetter.image.sprite = let[count];
            b1.GetComponent<Image>().sprite = obj1[count];
            b2.GetComponent<Image>().sprite = obj2[count];
            b3.GetComponent<Image>().sprite = obj3[count];

            //  play();                                                                        /// to play letter sound

            lettercolor();

            wordxt.text = "";
            count++;
            btn1.count++;
            btn2.count++;
            btn3.count++;
            letter.count++;
        }
        
        
        
                
    }
  
    void lettercolor()
    {
        switch (count)
        {
            case 0://a
                wordxt.color = Color.red;break;
            case 1://b
                wordxt.color = Color.blue;break;
            case 2://c
                wordxt.color = Color.red;break;
            case 3://d
                wordxt.color = Color.grey;break;
            case 4://e
                wordxt.color = Color.gray;break;
            case 5://f
                wordxt.color = Color.red;break;
            case 6://g
                wordxt.color = Color.red;break;
            case 7://h
                wordxt.color = Color.yellow;break;
            case 8://i
                wordxt.color = Color.gray;break;
            case 9://j
                wordxt.color = Color.grey; break;
            case 10://k
                wordxt.color = Color.yellow; break;
            case 11://l
                wordxt.color = Color.black;break;
            case 12://m
                wordxt.color = Color.yellow;break;
            case 13://n
                wordxt.color = Color.yellow; break;
            case 14://o
                wordxt.color = Color.grey; break;
            case 15://p
                wordxt.color = Color.grey; break;
            case 16://q
                wordxt.color = Color.black; break;
            case 17://r
                wordxt.color = Color.red; break;
            case 18://s
                wordxt.color = Color.blue; break;
            case 19://t
                wordxt.color = Color.grey; break;
            case 20://u
                wordxt.color = Color.grey; break;
            case 21://v
                wordxt.color = Color.blue; break;
            case 22://w
                wordxt.color = Color.grey; break;
            case 23://x
                wordxt.color = Color.blue; break;
            case 24://y
                wordxt.color = Color.black; break;
            case 25://z
                wordxt.color = Color.red; break;

        };

    }

    public void pannel()
    {
        Animator anim = panel.GetComponent<Animator>();
        if (anim != null)
        {
            bool isdown = anim.GetBool("down");
            anim.SetBool("down", true);
            x = count;
        }
    }

    public void StopTime(int x)
    {
        Time.timeScale = x;
    }

    
}
