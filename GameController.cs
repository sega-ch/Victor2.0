using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Header PanelHeader;
    private float _time;
    public Text txtTimer;
    public List<string> Alphabet;
    List<Questions> Quest = new List<Questions>
    { new Questions("вопрос", "ответ"),
        new Questions("Сколько мясяцев в году?", "12"),
        new Questions("Как зовут собак, котарая летала в космос и у неё имя другого животного", "Белка"),
        new Questions("Что сменяет солнце ночью?", "Луна"),
        new Questions("Кто жуёт морковь?", "Зайчик"),
        new Questions("Кто даёт молоко?", "Корова"),
        new Questions("Когда встаёт солнце?", "Утром"),
        new Questions("Кто проживает на дне океана?", "Губка Боб Квадратные штаны"),
        new Questions("Когда идёт снег?", "Зимой"),
        new Questions("Кто плавает под водой?", "Рыбы")
    } ;
      public Text QuestText;
    int CurrentIndex = 0;
       

	// Use this for initialization
	void Start ()
    {
        PanelHeader.InitHeader();
        _time = Config.time;
        Alphabet = new List<string>();
        for (int i = 1040; i < 1072; i++ )
        {
            Alphabet.Add(((char)i).ToString());
        }
        var r = new System.Random();
          CurrentIndex =  r.Next(0, Quest.Count);
        QuestText.text = Quest[CurrentIndex].Quest;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var delta = Time.deltaTime;
        _time -= delta;
        if (_time > 0)
        {
            txtTimer.text = "0:" + (int)_time;
        }
		
	}
}
