using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public static int Money;
    public int startMoney = 400;

    private void Start()
    {
        Money = startMoney;
    }

    private void Update()
    {
        MoneyCounter();

    }

    void MoneyCounter()
    {
        Text.text = "money :" + Money.ToString();
    }
}
