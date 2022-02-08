using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetermineShape : MonoBehaviour
{
    public Button Rectangle;
    public Button Square;
    public Button Triangle;
    public Button Circle;
    public GameObject CircleImage;
    public GameObject RectangleImage;
    public GameObject SquareImage;
    public GameObject TriangleImage;
    public GameObject WrongPanel;
    public GameObject CorrectPanel;
    public int TheRange;
    //public Image TheImage;
    
    // Start is called before the first frame update
    void Start(){
        RandomShape();
    }

    void Update(){
        if(WrongPanel.activeSelf){
            StartCoroutine(WaitToDeActivate());
        }

        if(CorrectPanel.activeSelf){
            StartCoroutine(WaitToReset());
        }
    }

    IEnumerator WaitToDeActivate(){
        yield return new WaitForSeconds(2f);
        WrongPanel.SetActive(false);
    }

    IEnumerator WaitToReset(){
        yield return new WaitForSeconds(1f);
        CorrectPanel.SetActive(false);
        RandomShape();
    }

   public void RandomShape(){
       TheRange = Random.Range(1, 4);
       
       if(TheRange == 1){
           TriangleImage.SetActive(true);
           CircleImage.SetActive(false);
           SquareImage.SetActive(false);
           RectangleImage.SetActive(false);

       }
       else if(TheRange == 2){
           CircleImage.SetActive(true);
           SquareImage.SetActive(false);
           RectangleImage.SetActive(false);
           TriangleImage.SetActive(false);
       }
       else if(TheRange == 3){
           SquareImage.SetActive(true); 
           RectangleImage.SetActive(false);
           TriangleImage.SetActive(false);
           CircleImage.SetActive(false);  
        }
       else if(TheRange == 4){
           RectangleImage.SetActive(true);
           SquareImage.SetActive(true);
           TriangleImage.SetActive(false);
           CircleImage.SetActive(false);

       }

    }
        
}
