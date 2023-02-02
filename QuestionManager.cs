using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionManager : MonoBehaviour
{
    static string filePath = "C:/test.txt";                     //*********Source*********

    [Header("Quiz file settings")]
    [SerializeField] int countOfAnswers;          //Count of answers after Question
    public string[] questions;      //variable with questions   [not edit]
    public string[] answers;        //variable with answers     [not edit]


    int spaceBetweenQuestions;    
    string[] lines = File.ReadAllLines(filePath);

    void Start()
    {
        declareQandA();
    }


    void declareQandA()
    {
        int countOfQuestions = lines.Length / (countOfAnswers + 1);
        questions = new string[countOfQuestions];                   //declare count of questions
        answers = new string[countOfQuestions * countOfAnswers];    //declare count of answers

        for (int i = 0, qIndex = 0, aIndex = 0; i < lines.Length; i += countOfAnswers + 1)
        {
            questions[qIndex] = lines[i];                                                   //Set question[] 
            for (int j = i + 1; j < i + countOfAnswers + 1 && j < lines.Length; j++)
            {
                answers[aIndex] = lines[j];                                             //Set answer[]  
                aIndex++;
            }
            qIndex++;
        }
    }
}
