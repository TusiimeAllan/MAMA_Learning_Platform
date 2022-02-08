using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneToPlay : MonoBehaviour
{
    private Button btn;
    // Start is called before the first frame update
    void Start() {
        btn = GetComponent<Button>();
        if (btn.tag == "Play")
            btn.onClick.AddListener(afterplay);
        else if(btn.tag == "Numbers")
            btn.onClick.AddListener(Numbers);
        else if(btn.tag == "GamesMenu")
            btn.onClick.AddListener(afterplay);
        else if(btn.tag == "MainMenu")
            btn.onClick.AddListener(MainMenu);
        else if (btn.tag == "BallonGame")
            btn.onClick.AddListener(BallonGame);
        else if (btn.tag == "LettersGame")
            btn.onClick.AddListener(LettersGame);
        else if (btn.tag == "quit")
            btn.onClick.AddListener(quit);
        else if (btn.tag == "NextLetter")
            btn.onClick.AddListener(NextLetter);
        else if (btn.tag == "PrevLetter")
            btn.onClick.AddListener(PrevLetter);

    }

    void afterplay() {
        SceneManager.LoadSceneAsync("afterPlay");
    }
    void Numbers()
    {
        SceneManager.LoadSceneAsync("Numbers");
    }
    void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        
    }
    void BallonGame()
    {
        SceneManager.LoadSceneAsync("game");

    }
    void LettersGame()
    {
        SceneManager.LoadSceneAsync("Letters");

    }
    void quit()
    {
        // UnityEditor.EditorApplication.isPlaying = false;
    }
    void NextLetter()
    {
        btn.GetComponent<AudioSource>().Play();
    }
    void PrevLetter()
    {
        btn.GetComponent<AudioSource>().Play();
    }



}
