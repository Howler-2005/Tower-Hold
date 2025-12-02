using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded;

    public GameObject gameOverUI;

   
    private void Start()
    {
        gameOverUI.SetActive(false);
        gameEnded = false;
        
    }

    private void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        
    }

    void EndGame()
    {
        gameEnded = true;

        gameOverUI.SetActive(true);
    }


}
