using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkingEverything : MonoBehaviour
{
    public GameObject Playway;
    public GameObject Waldorf;
    public GameObject BankStreet;
    public GameObject Canvas1;
    public GameObject PlaywayGames;
    public GameObject WaldorfGames;
    public GameObject BankStreetGames;


    public void ActivatePlayway(){
        Playway.SetActive(true);
        Canvas1.SetActive(false);
    }
    public void ActivateWaldorf(){
        Waldorf.SetActive(true);
        Canvas1.SetActive(false);
    }
    public void ActivateBankStreet(){
        BankStreet.SetActive(true);
        Canvas1.SetActive(false);
    }
    public void ActivateBackForPlayway(){
        Playway.SetActive(false);
        Canvas1.SetActive(true);
    }
    public void ActivateBackForWaldorf(){
        Waldorf.SetActive(false);
        Canvas1.SetActive(true);
    }
    public void ActivateBackForBankStreet(){
        BankStreet.SetActive(false);
        Canvas1.SetActive(true);
    }
    public void EnglishGameLink(){
        SceneManager.LoadScene("English Game");
    }
    public void MathGameLink(){
        SceneManager.LoadScene("QuizScene");
    }
    public void BalloonGameLink(){
        SceneManager.LoadScene("lastgame");
    }
    public void NumbersGameLink(){
        SceneManager.LoadScene("Numbers");
    }
    public void EvenNumbersGameLink(){
        SceneManager.LoadScene("EvenNumbers");
    }
    public void OddNumbersGameLink(){
        SceneManager.LoadScene("OddNumbers");
    }
    public void VideoLessonsGameLink(){
        SceneManager.LoadScene("VideoLessons");
    }
    public void JigSawGameLink(){
        SceneManager.LoadScene("JigSaw");
    }
    public void ShapeIdentificationGameLink(){
        SceneManager.LoadScene("Shapeidentification");
    }
    public void ActivateBackForPlaywayGames(){
        PlaywayGames.SetActive(false);
        Canvas1.SetActive(true);
    }
    public void ActivateBackForWaldorfGames(){
        WaldorfGames.SetActive(false);
        Canvas1.SetActive(true);
    }
    public void ActivateBackForBankStreetGames(){
        BankStreetGames.SetActive(false);
        Canvas1.SetActive(true);
    }

    //Activating Respective pages

    public void ActivatePlaywayGames(){
        PlaywayGames.SetActive(true);
        Canvas1.SetActive(false);
    }
    public void ActivateWaldorfGames(){
        WaldorfGames.SetActive(true);
        Canvas1.SetActive(false);
    }
    public void ActivateBankStreetGames(){
        BankStreetGames.SetActive(true);
        Canvas1.SetActive(false);
    }

    // Activaing Custom
    public void CustomLink(){
        SceneManager.LoadScene("Menu");
    }
    public void SpellingGameLink(){
        SceneManager.LoadScene("Spelling");
    }
    public void MethodologyLink(){
        SceneManager.LoadScene("Methodology");
    }

    //public void ActivateCustom(){
      //  Playway.SetActive(true);
    //}
}
