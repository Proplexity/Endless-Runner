using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


     public void CompleteLevel ()
      {
          completeLevelUI.SetActive(true);
          StartCoroutine(waiting());
      }
          public IEnumerator waiting ()
      {
          yield return new WaitForSeconds(3f);
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
 
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }

   

     int score = 0;

    public Text Score;
     

    public static GameManager instance;


    public GameObject completeLevelUI;

      bool gameHasEnded = false;

      public float restartDelay = 2f;

      public float transitionDelay = 3f;

    [SerializeField] Movement movement;

      public void EndGame ()
      {
          if (gameHasEnded == false)
         { gameHasEnded = true;
          Debug.Log("Game Over");
          Invoke("Restart", restartDelay);
         }
      }
      void Restart ()
      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }

    public void IncrementScore()
    {
        score++;
        Score.text = "Score: " + score;
        movement.speed += movement.speedIncreasePerPoint;
    }
  

    private void Awake()
    {
        instance = this;
    }

}


