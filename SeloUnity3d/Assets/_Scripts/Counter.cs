using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    public GameObject FinishMenu;
    public GameObject FinishMenu1;
    public Text MenuText;
    public Text MenuText1;

    public Image scala;

    public float TimerDown; //Время в секундах которое отсчитает таймер
    public Text timerText;
    private int min, sec;
    private string m, s;
    bool Time_Start = false;

    public static float drunk;
    public static float drunk_effect;
    public int count;
    public Text countText;

	public AudioClip coin;
	public AudioClip BottleDrink;
    public AudioClip Loose;
    public AudioClip Win;
    AudioSource audio;

	void Start () {
        drunk_effect = 0;
        count = 0;
        drunk = 0;
        countText.text = "Опьянение";
        timerText.text = "На старт!";
    }

    void Awake() {audio = GetComponent<AudioSource>(); }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (FinishMenu.gameObject.activeInHierarchy == false)
            {
                FinishMenu.gameObject.SetActive(true);
                FinishMenu1.gameObject.SetActive(true);
                Time.timeScale = 0;
                audio.Stop();
            }

            other.gameObject.SetActive(false);
            count = (int)(TimerDown * drunk);

            drunk_effect = 0;

            MenuText.text = "Вы приехали в село и получили " + count.ToString() + " балла(ов)";
            MenuText1.text = "Вы приехали в село и получили " + count.ToString() + " балла(ов)";

            audio.PlayOneShot(Win, 1);
        }


        if (other.gameObject.CompareTag("Start"))
        {
            Time_Start = true;
            other.gameObject.SetActive(false);
        }

            if (other.gameObject.CompareTag("Pick Up"))
        {
			audio.PlayOneShot(coin, 1);
            other.gameObject.SetActive(false);
            TimerDown += 5;
        }

		if (other.gameObject.CompareTag("Drink"))
		{
			audio.PlayOneShot(BottleDrink, 1);
			other.gameObject.SetActive(false);
            drunk++; drunk_effect++;
            scala.transform.localScale = new Vector3(drunk, 1f, 1f);
        }
	}

    void Update()
    {
        if (Time_Start == true)
        {
            if (TimerDown > 0) TimerDown -= Time.deltaTime; //Если время которое нужно отсчитать еще осталось убавляем от него время обновления экрана (в одну секунду будет убавляться полная единица)
            else if (TimerDown < 0) TimerDown = 0; //Если временная переменная ушла в отрицательное число (все возможно) то приравниваем ее к нулю
                 else
            {
                if (FinishMenu.gameObject.activeInHierarchy == false) //Сюда дописываем действия которые произойдут после конца отсчета
                {
                    FinishMenu.gameObject.SetActive(true);
                    FinishMenu1.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    audio.Stop();
                } 
                drunk_effect = 0;

                MenuText.text = "Вы не приехали в село (0((0((";
                MenuText1.text = "Вы не приехали в село (0((0((";

                audio.PlayOneShot(Loose, 0.2f);
            }
            CurrentTime();
            NormalTime();
            timerText.text = m + ":" + s;
        }
    }
    void CurrentTime()
    {
        if (TimerDown > 60)
        {
            sec = (int)(TimerDown % 60);
            min = (int)((TimerDown - sec) / 60);
        }
        else { sec = (int)TimerDown; min = 0; }
    }

    void NormalTime()
    {
        if (sec < 10) s = "0" + sec.ToString(); else s = sec.ToString();
        if (min < 10) m = "0" + min.ToString(); else m = min.ToString();
    }

}