using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {
  public static float speed = 30; // Variavel que guarda velocidade do obstáculo
  Text score;

  void Start() {
    // Chama a função de aumentar a velocidade dos obstáculos após os primeiros 3s e depois a cada 2s
    InvokeRepeating("increaseSpeed", 3, 2);
    score = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
    GetComponent<Rigidbody>().velocity = transform.up * speed; // Adiciona velocidade ao obstáculo
  }

  void increaseSpeed() {
    speed += Time.deltaTime + 1.5f; // Aumenta a velocidade em: Tempo para executar último frame + 1.5f
  }

  private void OnBecameInvisible() {
    Destroy(gameObject); // Destrói o gameobject quando ele sair da tela
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      var highscore = PlayerPrefs.GetInt("highscore");

      if (highscore < int.Parse(score.text))
      {
        PlayerPrefs.SetInt("highscore", int.Parse(score.text));
        PlayerPrefs.Save();
      }

      Navigate.navigateInScript("EndGame");
    }
  }
}
