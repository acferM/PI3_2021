using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
  [SerializeField] GameObject spawner;
  [SerializeField] GameObject Credits;
  [SerializeField] GameObject Game_UI;
  [SerializeField] Text highscoreTxt;

  void Start()
  {
    Time.timeScale = 0;
    highscoreTxt.text = PlayerPrefs.GetInt("highscore").ToString();
    Obstacle.speed = 30;
  }

  public void OpenCredits() {
    Credits.SetActive(true);
    this.gameObject.SetActive(false);
  }

  public void StartGame()
  {
    Time.timeScale = 1;
    spawner.SetActive(true);
    Game_UI.SetActive(true);
    gameObject.SetActive(false);
  }
}
