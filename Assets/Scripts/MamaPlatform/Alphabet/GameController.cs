using System.Collections;
using System; 
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static char _letter = 'a';
    static int _correctAnswers = 5;
    static int _correctClicks;

    private void OnEnable(){
        GenerateBoard();
        UpdateDisplayLetter();
    }

    private static void GenerateBoard(){
        var clickables = FindObjectsOfType<Clickable>();
        int count = clickables.Length;

        List<char> charsList = new List<char>();

        for (int i = 0; i < _correctAnswers; i++)
        
            charsList.Add(_letter);
        
        for(int i = _correctAnswers; i < clickables.Length; i++)
        {
            var chosenLetter = ChooseInvalidRandomLetter();
            charsList.Add(chosenLetter);

        }

        charsList = charsList.OrderBy(t => UnityEngine.Random.Range(0, 10000)).ToList();
        for (int i = 0; i< clickables.Length; i++){
            clickables[i].SetLetter(charsList[i]);

        }
        FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
    }
    

        private static char ChooseInvalidRandomLetter(){
            int a = UnityEngine.Random.Range(0, 26);
            var randomLetter = (char)('a' + a);
            while (randomLetter == _letter){
                a = UnityEngine.Random.Range(0, 26);
                randomLetter = (char)('a' + a);
                
            }
            return randomLetter;
            
        }

        internal static void HandleCorrectLetterClick(){
            _correctClicks++;
            FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
            if(_correctClicks >= _correctAnswers){
                _letter++;
                
                UpdateDisplayLetter();
                _correctClicks = 0;
                GenerateBoard();
            }

        }

        private static void UpdateDisplayLetter(){
            foreach(var displayletter in FindObjectsOfType<DisplayLetter>()){
                    displayletter.SetLetter(_letter);
            }   

        } 


        

    

    
}
