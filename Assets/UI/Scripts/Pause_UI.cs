using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_UI : MonoBehaviour
{
  [SerializeField] GameObject Game_UI;

  public void play()
  {
    Time.timeScale = 1f;
    Game_UI.SetActive(true);
    gameObject.SetActive(false);
  }

  public void restart()
  {
    Navigate.navigateInScript("Level");
  }
}
