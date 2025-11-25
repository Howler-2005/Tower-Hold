using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI count;
    public static int Money;
    public int startMoney = 400;
    public float Count = 2f;
    public float timeBetween;

    private void Start()
    {
        Money = startMoney;
        
    }

    private void Update()
    {
        MoneyCounter();
        wavecountdown();

    }

    void MoneyCounter()
    {
        Text.text = "Money :" + Money.ToString();
    }
    void wavecountdown()
    {

        count.text = "Next wave : " + Count.ToString();

        if (Count <= 0f)
        {
            Count = timeBetween;
        }

        Count -= Time.deltaTime;


    }
}
