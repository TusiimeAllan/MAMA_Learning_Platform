using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    
    
    
    public int a,b;
    public GameObject TheQuestion;
    public GameObject WrongPanel;
    public GameObject CorrectPanel;
    public GameObject levelMusic;
    public Button ButtonOne;
    public Button ButtonTwo;
    public Button ButtonThree;
    public Button Reset;
    public int AddingOrSubtracting;
    public int ButtonOneAnswer;
    public int ButtonThreeAnswer;
    public string QuestionText;

    private void Start(){
        
        AddOrSubtractQuestion();
        ForButtonOne();
        ForButtonTwo();
        ForButtonThree();
        WrongPanel.SetActive(false);
        CorrectPanel.SetActive(false);
        

    }
    
    //public void Correct(){
      //  QnA.RemoveAt(CurrentQuestion);
    //}
    
    
   public int AddOrSubtractQuestion(){
        int operand1 = Mathf.FloorToInt(Random.value * 10);
        int operand2 = Mathf.FloorToInt(Random.value * 10);
        
        

        AddingOrSubtracting = Mathf.FloorToInt(Random.value * 2);
        //Determining whether its adding or subtracting by using 0 and 2
        if (AddingOrSubtracting == 0){
            
            QuestionText = "What is " + operand1 + "-" + operand2 + " = ? ";
            if(operand1>operand2){
            a = operand1 - operand2;
            TheQuestion.GetComponent<TextMeshProUGUI>().text = QuestionText;
            }
        }
        else{
            
            QuestionText = "What is " + operand1 + "+" + operand2 + " = ? ";
            b = operand1 + operand2;
            TheQuestion.GetComponent<TextMeshProUGUI>().text = QuestionText;
            
        }
        return (a);
        return (b);


        
    }


    
    
    public void ForButtonOne(){
        if (AddingOrSubtracting == 0){
            int ButtonOneAnswer = a + Mathf.FloorToInt(Random.value * 10);
            ButtonOne.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Is it " + ButtonOneAnswer + " ?" ;
            
        }
        else{
            ButtonOneAnswer =  b + Mathf.FloorToInt(Random.value * 10);
            ButtonOne.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Is it " + ButtonOneAnswer + "?";

        }
        void IsCorrect(){
            Debug.Log("Wrong answer");
        }
         

    }
    public void ForButtonTwo(){
        if (AddingOrSubtracting == 0){
            
            ButtonTwo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Is it " + a + "?";

        }
        else{
            
            ButtonTwo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Is it " + b + "?";

        }

        void IsCorrect2(){
            Debug.Log("correct answer");
        }
         

    }
    public void ForButtonThree(){
        if (AddingOrSubtracting == 0){
            int ButtonThreeAnswer = a + Mathf.FloorToInt(Random.value * 10);
            ButtonThree.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Is it " + ButtonThreeAnswer + "?";

        }
        else{
            ButtonThreeAnswer = b + Mathf.FloorToInt(Random.value * 10);
            ButtonThree.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Is it " + ButtonThreeAnswer + "?";

        }
        void IsCorrect3(){
            Debug.Log("wrong answer");
        }
         

    }

    public void ForReset(){
         SceneManager.LoadScene("QuizScene");




    }

    public void ForButtonOneWrong(){
        WrongPanel.SetActive(true);
        WrongPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "WRONG";
    }
    public void ForButtonTwoCorrect(){
        CorrectPanel.SetActive(true);
        CorrectPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "CORRECT";
    }
    public void ForButtonThreeWrong(){
        WrongPanel.SetActive(true);
        WrongPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "WRONG";
    }
    
    
    
    
   // void SetAnswers()
 //   {
   //     for (int i = 0; i < options.length; i++)
     //   {
       //     options[i].GetComponent<AnswerScript>().isCorrect = false;
         //   options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[CurrentQuestion].Answers[i];
//
  //          if(QnA[CurrentQuestion].CorrectAnswer == i+1){
    //            options[i].GetComponent<AnswerScript>().isCorrect = true;
      //      }
        //}
        
        //}
        
        
    
}
