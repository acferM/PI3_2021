using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
  [SerializeField] Transform[] positions = new Transform[3]; // Variavel que guarda possíveis posições de spawn
  [SerializeField] GameObject[] Obstacles; // Variavel que guarda prefab do obstáculo
  [SerializeField] float spawnCooldown; // Variavel que guarda tempo para prox spawn
  float lastSpawn = 0; // Variavel que guarda quando aconteceu o último spawn
  int lastChosen = -1; // Variavel que guarda ultima pista escolhida para spawn


  void Update() {
    //  Verifica se o tempo atual é maior o igual a ultima vez que ocorreu um spawn + tempo para prox cooldown
    if (Time.time >= lastSpawn + spawnCooldown / (Obstacle.speed / 100)) {
      Transform position = selectRoad(); // Seleciona uma pista aleatória

      int obstacle = Random.Range(0, Obstacles.Length);

      // Cria um objeto do prefab Obstacle na posição da pista selecionada
      Instantiate(
        Obstacles[obstacle],
        new Vector3(position.position.x + 1.3f, transform.position.y, transform.position.z),
        Obstacles[obstacle].transform.rotation
      ); ;

      lastSpawn = Time.time; // Atualizo o último spawn
      var discount = Time.deltaTime + 0.03f; // Calculo o disconto do tempo que demora para ter um prox spawn
      spawnCooldown = spawnCooldown - discount > 0.3f ? spawnCooldown - discount : spawnCooldown;
      // Digo que o tempo para prox cooldown é seu valor atual - o disconto, isso se o seu valor - o desconto
      // Não for menor que o limite de 0.4s
    }
  }

  Transform selectRoad() {
    List<Transform> availablePlaces = new List<Transform>(); // Lista de possíveis posições para spawn
    int randomPosition; // Variavel que indica valor aleatório para escolher a posição do spawn

    // Verifico o valor da última casa escolhida
    switch (lastChosen) {
        // se for a casa da esquerda:
        case 0: {
          availablePlaces.Add(positions[1]);
          availablePlaces.Add(positions[2]);
          // Deixe a casa do meio e a da direita disponíveis

          randomPosition = Random.Range(0, 2); // Selecione casa aleatória
          lastChosen = randomPosition == 0 ? 1 : 2; // Atualiza a última casa escolhida

          return availablePlaces[randomPosition]; // Retorna a posição da casa
        }

        // se for a casa do meio:
        case 1: {
          availablePlaces.Add(positions[0]);
          availablePlaces.Add(positions[2]);
          // Deixe a casa da esquerda e a da direita disponíveis

          randomPosition = Random.Range(0, 2); // Selecione casa aleatória
          lastChosen = randomPosition == 0 ? 0 : 2; // Atualiza a última casa escolhida

          return availablePlaces[randomPosition]; // Retorna a posição da casa
        }

        // se for a casa da direita:
        case 2: {
          availablePlaces.Add(positions[0]);
          availablePlaces.Add(positions[1]);
          // Deixe a casa do meio e a da esquerda disponíveis

          randomPosition = Random.Range(0, 2); // Selecione casa aleatória
          lastChosen = randomPosition; // Atualiza a última casa escolhida

          return availablePlaces[randomPosition]; // Retorna a posição da casa
        }

        // Se não for nenhuma das opções acima (Começo do jogo)
        default: {
          availablePlaces.Add(positions[0]);
          availablePlaces.Add(positions[1]);
          availablePlaces.Add(positions[2]);
          // Deixe todas as casas disponíveis

          randomPosition = Random.Range(0, 3); // Selecione casa aleatória
          lastChosen = randomPosition; // Atualiza a última casa escolhida

          return availablePlaces[randomPosition]; // Retorna a posição da casa
        }
      }
  }
}
