using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
  static float speed = 30; // Variavel que guarda velocidade do obstáculo

  void Start() {
    // Chama a função de aumentar a velocidade dos obstáculos após os primeiros 3s e depois a cada 2s
    InvokeRepeating("increaseSpeed", 3, 2);

    GetComponent<Rigidbody>().velocity = transform.up * speed; // Adiciona velocidade ao obstáculo
  }

  void increaseSpeed() {
    speed += Time.deltaTime + 1.5f; // Aumenta a velocidade em: Tempo para executar último frame + 1.5f
  }

  private void OnBecameInvisible() {
    Destroy(this.gameObject); // Destrói o gameobject quando ele sair da tela
  }
}
