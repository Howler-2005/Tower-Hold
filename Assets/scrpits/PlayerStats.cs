using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI count;
    public TextMeshProUGUI live;
    public static int Money;
    public int startMoney = 400;
    public float Count = 2f;
    public float timeBetween;

    public static int Diff;
    public int difficulty = 25;

    public static int Lives;
    public int startlives = 20;

    private void Start()
    {
        Money = startMoney;
        Lives = startlives;
        Diff = difficulty;
    }

    private void Update()
    {
        MoneyCounter();
        wavecountdown();
        livecount();

    }

    void MoneyCounter()
    {
        Text.text = "Money :" + Money.ToString();
    }
    void wavecountdown()
    {

        count.text = "Next wave : " + Mathf.Round(Count).ToString();

        if (Count <= 0f)
        {
            Count = timeBetween;
            Diff += difficulty;
            Debug.Log(Diff);
        }

        Count -= Time.deltaTime;


    }

    void livecount()
    {
        live.text = Lives.ToString() + " LIVES";
    }
}
