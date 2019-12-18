using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour {

    public Text txtTimer;
    public float CurrentTime;
    public Text QuestionTxt;
    public GameObject[] Letters;
    public List<string> Alphabet;
    int IndexCurrentQuestion = 0;
    public List<Question> Task1 = new List<Question>
    {
        new Question("Кто говорит на всех языках ?", "Эхо"),
        new Question("Что может в одно и то же время: стоять и ходить, висеть и стоять","Пьяный батя"),
        new Question("У квадратного стола отпилили один","Стул"),
        new Question("Что самое дефицитное в нашей жизни","Смерть"),
        new Question("Что поднять с земли легко, но трудно ","Логично"),
        new Question("Сидит дед, в сто шуб одет","Димас"),
        new Question("Сидит девица в темнице","Да"),
        new Question("Не шагом ходит, не бегает, а прыгает","Заяц"),
        new Question("Кто на себе свой дом носит","Черепаха"),
        new Question("Ты со мною не знаком ? Я живу на социальном дне","Ты"),

    };

    // Use this for initialization
    void Start()
    {
        CurrentTime = Config.timerGame;
        Letters = GameObject.FindGameObjectsWithTag("Letter");
        Alphabet = new List<string>();

        for (int i = 1040; i < 1072; i++)
        {
            Alphabet.Add(((char)i).ToString());
        }

        NextQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.deltaTime;
        CurrentTime -= time;
        txtTimer.text = "0:" + (int)CurrentTime;
    }

    public void NextQuestion()
    {
        foreach (var item in Letters)
        {
            item.SetActive(true);
        }

        var rnd = new System.Random();
        IndexCurrentQuestion = rnd.Next(0, Task1.Count);
        QuestionTxt.text = Task1[IndexCurrentQuestion].Quest;
        var LetterVariant = new List<string>();

        for (int i = 0; i < Task1[IndexCurrentQuestion].Answer.Length; i++)
        {
            LetterVariant.Add(Task1[IndexCurrentQuestion].Answer[i].ToString());
        }

        var a = 30 - LetterVariant.Count;

        for (int i = 0; i < a; i++)
        {
            LetterVariant.Add(Alphabet[i]);
        }

        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].GetComponent<Letter>().Symbol = LetterVariant[i];
            Letters[i].GetComponent<Letter>().Init();
        }
    }
}
