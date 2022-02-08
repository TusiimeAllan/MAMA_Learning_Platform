using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public Button balloon;
    public Sprite[] BallonColor;
    public Sprite[] OnBallonImg;

    public Sprite[] questionImage;
    public Button questionButton;
    public int balloonIndex;
    public ImageChanger imagechanger;
    public AudioClip[] words;

    public Canvas canv;

    private float posY = -470f;
    private float minXpos = -600f;
    private float maxXpos = 600f;

   public bool stopBallon = false;

    // Start is called before the first frame update
    void Start()
    {
        imagechanger = GameObject.FindGameObjectWithTag("questionButton").GetComponent<ImageChanger>();
        InvokeRepeating("Spawn", 0.5f,1);
    }

    // Update is called once per frame
    void Update()
    {
        //shoot();
    }

    public void Spawn()
    {
        if (!stopBallon)
        {
            float posX = Random.Range(minXpos, maxXpos);
            Button ball = Instantiate(balloon);
            ball.transform.SetParent(canv.transform);
            ball.transform.localScale = Vector3.one;
            ball.transform.rotation = Quaternion.Euler(Vector3.zero);
            ball.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(posX, posY, 0);
            ball.gameObject.GetComponent<Image>().sprite = BallonColor[Random.Range(0, BallonColor.Length)];
            //ball.GetComponentInChildren<Image>().sprite = OnBallonImg[Random.Range(0,OnBallonImg.Length)];
            Image buttonImage = ball.GetComponent<Image>();
            Image[] img = ball.GetComponentsInChildren<Image>();

            foreach (Image image in img)
            {
                /*if (image != buttonImage)
                    image.sprite = OnBallonImg[Random.Range(0, OnBallonImg.Length)];*/
                if (image != buttonImage)
                {

                    if (imagechanger.questionIndex >= 0 && imagechanger.questionIndex < 15)
                    {
                        balloonIndex = Random.Range(0, 5);
                        image.sprite = OnBallonImg[balloonIndex];
                        // Debug.Log(imagechanger.questionIndex +"     "+balloonIndex);

                    }
                    else if (imagechanger.questionIndex >= 15 && imagechanger.questionIndex < 30)
                    {
                        balloonIndex = Random.Range(5, 10);
                        image.sprite = OnBallonImg[balloonIndex];
                        // Debug.Log(imagechanger.questionIndex + "     " + balloonIndex);

                    }
                    else if (imagechanger.questionIndex >= 30 && imagechanger.questionIndex < 45)
                    {
                        balloonIndex = Random.Range(10, 15);
                        image.sprite = OnBallonImg[balloonIndex];
                        // Debug.Log(imagechanger.questionIndex + "     " + balloonIndex);

                    }
                    else if (imagechanger.questionIndex >= 45 && imagechanger.questionIndex < 60)
                    {
                        balloonIndex = Random.Range(15, 20);
                        image.sprite = OnBallonImg[balloonIndex];
                        // Debug.Log(imagechanger.questionIndex + "     " + balloonIndex);

                    }
                    else if (imagechanger.questionIndex >= 60 && imagechanger.questionIndex < 78)
                    {
                        balloonIndex = Random.Range(20, OnBallonImg.Length);
                        image.sprite = OnBallonImg[balloonIndex];
                        // Debug.Log(imagechanger.questionIndex + "     " + balloonIndex);

                    }

                }

            }
        }
    }

    /*public void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(bul, transform.position, transform.rotation);
        }
           
    }*/

    public void StopTime(int x)
    {
        Time.timeScale = x;
    }
}
