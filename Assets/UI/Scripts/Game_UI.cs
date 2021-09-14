using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_UI : MonoBehaviour {
  [SerializeField] GameObject Pause_UI;
  [SerializeField] Text pointsTxt;

  void Start() {
    InvokeRepeating("addPoint", 1, 0.5f);
  }

  public void addPoint() {
    pointsTxt.text = (int.Parse(pointsTxt.text) + 1).ToString();
  }

  public void Pause() {
    Pause_UI.SetActive(true);
    Time.timeScale = 0;
    gameObject.SetActive(false);
  }
}
