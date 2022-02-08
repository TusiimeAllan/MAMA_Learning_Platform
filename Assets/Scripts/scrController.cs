using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrController : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedObject;
    public GameObject prefBalloon;
    private int totalMatched;
    [HideInInspector]
    public int currentLevel = 1;
    public GameObject soundObject;
    public AudioClip cheerSound;
    public Image gameOverImage;


    private void Awake()
    {
        totalMatched = 0;
        selectedObject = this.transform.gameObject;
    }

    public IEnumerator CheckWinCondition()
    {

        GameObject[] go = GameObject.FindGameObjectsWithTag("draggable");

        for (int i = 0; i < go.Length; i++)
        {



            if (go[i].GetComponent<scrDraggable>().matched && !go[i].GetComponent<scrDraggable>().pointTaken)
            {

                totalMatched++;
                go[i].GetComponent<scrDraggable>().pointTaken = true;


            }

        }


        if (totalMatched >= go.Length)
        {
            totalMatched = 0;
         //   selectedObject = this.transform.gameObject;
            Debug.Log(currentLevel);
            CelebrateLevel(); // Balonlar çıkar
            yield return new WaitForSeconds(3);
            ChangeLevel(1); // Diğer levele geç
        }

    }


    public void ChangeLevel(int levelAmount)
    {

        totalMatched = 0;
        currentLevel += levelAmount;
        GameObject[] levels = GameObject.FindGameObjectsWithTag("level");

        if (currentLevel <= levels.Length) // Eğer tüm leveller bitmemişse
        {

            foreach (GameObject l in levels)
            {

                if (l.name == currentLevel.ToString()) // eğer level adı şu anki levelle eşitse
                {
                    foreach (Transform t in l.transform)
                    {

                        t.gameObject.SetActive(true);

                    }

                }
                else
                {
                    foreach (Transform t in l.transform)
                    {
                        if (t.tag == "draggable") // Eğer draggable ise level değişirken yapılması gereken birtakım değişiklikler
                        {

                            t.position = t.gameObject.GetComponent<scrDraggable>().startingPos;
                            t.gameObject.GetComponent<scrDraggable>().matched = false;
                            t.gameObject.GetComponent<scrDraggable>().pointTaken = false;
                            t.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                        }


                        t.gameObject.SetActive(false);
                        
                    }

                }

            }
        }
        else // Finish the game
        {
            
            // sahneyi temizle
            foreach(GameObject obj in levels) 
            {
                if(obj.name == (currentLevel-1).ToString())
                {
                    foreach(Transform t in obj.transform)
                    {
                        t.gameObject.SetActive(false);
                    }

                }

            }

            FinishTheGame();

        }
    }


    public void CelebrateLevel()
    {

        for(int i = 0; i <= 20; i++)// balon falan
        {

            GameObject b = Instantiate(prefBalloon);
            b.transform.position = new Vector2(Random.Range(-10,10), Random.Range(-7,-15));
            soundObject.GetComponent<AudioSource>().PlayOneShot(cheerSound);
        }

    }

    public void FinishTheGame()
    {
        for (int i = 0; i <= 100; i++) // çakma son
        {

            GameObject b = Instantiate(prefBalloon);
            b.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-7, -55));
            soundObject.GetComponent<AudioSource>().PlayOneShot(cheerSound);
           gameOverImage.enabled = true;
        
        }

    }
}
