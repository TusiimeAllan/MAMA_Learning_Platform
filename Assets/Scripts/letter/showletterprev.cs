using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showletterprev : MonoBehaviour
{
  //  int count = 1;
    private Button but;
    public Button TheLetter;
    public Button[] btn;
    public Sprite[] let;
    public Sprite[] obj1;
    public Sprite[] obj2;
    public Sprite[] obj3;

    btn1 n;
    btn2 n2;
    btn3 n3;

    public AudioClip[] letsound;

    string[] txt_btn1 = { "irplane", "all", "andle", "og", "ggs", "ire", "iraffe", "at", "ce", "elly", "eys", "amp", "am", "est", "nion", "aint", "ueen", "adish", "nowman", "iger", "mbrella", "an", "all", "'mas", "ak", "ebra" };
    string[] txt_btn2 = { "pple", "alloon", "ar", "onkey", "lephant", "lower", "lasses", "oney", "nk", "ug", "ite", "eaf", "ilk", "et", "range", "encil", "uill", "ed", "poon", "rain", "niversity", "illage", "indow", "-ray", "arn", "ip" };
    string[] txt_btn3 = { "rm", "oat", "hicken", "oor", "yes", "ork", "oat", "orse", "sland", "uice", "iwi", "ion", "oon", "ut", "ven", "ie", "uilt", "obot", "tar", "ree", "rn", "iolin", "orm", "ylophone", "ogurt", "oo" };

    public Text wordxt;

    public Button b1;
    public Button b2;
    public Button b3;
    // private Button btn1,btn2,btn3;



    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(show);

    }

    void Update()
    {

    }
    void show()
    {
        if (showletter.count - 2 >= 0)
        {
            showletter.count -= 2 ;
            btn1.count -- ;
            btn2.count -- ;
            btn3.count --;
            letter.count--;

            TheLetter.image.sprite = let[showletter.count];

            btn[0].image.sprite = obj1[showletter.count];
            btn[1].image.sprite = obj2[showletter.count];
            btn[2].image.sprite = obj3[showletter.count];
            lettercolor();
            wordxt.text = "";
            showletter.count++;
        }
    }

    Color genRandomColor()
    {
        float r, g, b;
        r = UnityEngine.Random.Range(0f, 1f);
        g = UnityEngine.Random.Range(0f, 1f);
        b = UnityEngine.Random.Range(0f, 1f);

        return new Color(r, g, b);
    }
    void lettercolor()
    {
        switch (showletter.count)
        {
            case 0://a
                wordxt.color = Color.red; break;
            case 1://b
                wordxt.color = Color.blue; break;
            case 2://c
                wordxt.color = Color.red; break;
            case 3://d
                wordxt.color = Color.grey; break;
            case 4://e
                wordxt.color = Color.gray; break;
            case 5://f
                wordxt.color = Color.red; break;
            case 6://g
                wordxt.color = Color.red; break;
            case 7://h
                wordxt.color = Color.yellow; break;
            case 8://i
                wordxt.color = Color.gray; break;
            case 9://j
                wordxt.color = Color.grey; break;
            case 10://k
                wordxt.color = Color.yellow; break;
            case 11://l
                wordxt.color = Color.black; break;
            case 12://m
                wordxt.color = Color.yellow; break;
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

}
