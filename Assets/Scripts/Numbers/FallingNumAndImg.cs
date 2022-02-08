using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingNumAndImg : MonoBehaviour
{
    public Canvas[] canv;
    public Canvas[] apple;
    [HideInInspector]
    public int count;
    public int lastcount;
    private Button btn;
    public bool begin = true;
    bool ag = true;

    //Vector2 startpos = new Vector2(140, 315);

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        lastcount = count;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(show);
        show();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 9)
        {
            GameObject.FindGameObjectWithTag("NextTxt").GetComponent<Text>().text = "Finish";
        }
    }

    public void show()
    {
        if (begin && ag) {
            begin = false;
            if (count < 9)
            {
                if (count > 0)
                {
                    
                    Destroy(GameObject.FindGameObjectWithTag((count.ToString())));
                    for (int i = 0; i <= count; i++)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("apple" + (i + 1)));
                    }
                }
                GameObject.FindGameObjectWithTag("NextTxt").GetComponent<Text>().text = "Next Number";
                StartCoroutine(InsApple());
            }
            if (GameObject.FindGameObjectWithTag("NextTxt").GetComponent<Text>().text == "Finish")
            {
                SceneManager.LoadSceneAsync("NumbersTest");
            }
        }
        
    }  

    IEnumerator InsApple()
    {
        Instantiate(canv[count]);
        yield return new WaitForSeconds(1);
        for (int i = 0; i <= count; i++)
        {
            Instantiate(apple[i]);
            yield return new WaitForSeconds(1);
        }
        lastcount = count;
        count = count + 1;
        begin = true;
    }

    public void StopTime(int x)
    {
        Time.timeScale = x;
    }

    void again()
    {
        if (ag)
        {
            ag = false;
            if (count < 9)
            {
                if (count > 0)
                {

                    Destroy(GameObject.FindGameObjectWithTag((count.ToString())));
                    for (int i = 0; i <= count; i++)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("apple" + (i + 1)));
                    }
                }
                StartCoroutine(AgainInsApple());
            }
        }
    }

    IEnumerator AgainInsApple()
    { 
        Instantiate(canv[lastcount]);
        yield return new WaitForSeconds(1);
        for (int i = 0; i <= lastcount; i++)
        {
            Instantiate(apple[i]);
            yield return new WaitForSeconds(1);
        }
        ag = true;
    }
}
