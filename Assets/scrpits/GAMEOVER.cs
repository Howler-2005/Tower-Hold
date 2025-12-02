using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void Update()
    {
        if ( GameManager.gameEnded)
        {
            return;
        }
        else
        {
            roundsText.text = PlayerStats.Rounds.ToString();
        }
      

       
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("TowerHold");
    }
    
}




