using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyDart : MonoBehaviour
{
    spawner spawn;
    public ImageChanger imagechanger;
    scoreControler SC;
   

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,3);

        spawn = GameObject.Find("Canvas").GetComponent<spawner>();
        imagechanger = GameObject.FindGameObjectWithTag("questionButton").GetComponent<ImageChanger>();
        SC = GameObject.Find("scoreTxt").GetComponent<scoreControler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ballon")
        {
            balloonsUp ins = collision.gameObject.GetComponent<balloonsUp>();
            if (imagechanger.questionIndex == (ins.balloonImageIndex * 3) ||
                imagechanger.questionIndex == (ins.balloonImageIndex * 3) + 1 ||
                imagechanger.questionIndex == (ins.balloonImageIndex * 3) + 2
                )
            {
                //Debug.Log(ins.balloonImageIndex + "     " + imagechanger.questionIndex);
                imagechanger.QuestionImageChange();
                SC.score += 10;
            }
            else
            {
                SC.wrongAnswersCounter++;
                Debug.Log("Wrong Answer:"+SC.wrongAnswersCounter);

            }

        }

        Destroy(this.gameObject);
    }
   
}
