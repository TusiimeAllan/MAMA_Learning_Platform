using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    spawner spawn;
    [HideInInspector]
    public int questionIndex;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Canvas").GetComponent<spawner>();
        QuestionImageChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            spawn.questionButton.GetComponent<AudioSource>().Play();
        }
    }

    public int QuestionindexSetter()
    {
        int onQuestionButton = Random.Range(0, spawn.questionImage.Length);

        return onQuestionButton;
    }

    public void QuestionImageChange()
    {
        questionIndex = QuestionindexSetter();
        spawn.questionButton.image.sprite = spawn.questionImage[questionIndex];
        spawn.questionButton.GetComponent<AudioSource>().clip = spawn.words[questionIndex];
        spawn.questionButton.GetComponent<AudioSource>().Play();
    }
}
