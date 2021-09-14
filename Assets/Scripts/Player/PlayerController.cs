using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  [SerializeField] Transform[] positions = new Transform[3]; // Variavel que guarda possíveis posições do player
  [SerializeField] float changePositionVelocity; // Variavel que guarda velocidade de movimento do player
  [SerializeField] Rigidbody playerRigidbody; // Variavel que recebe componente de Rigidbody
  [SerializeField] Animator animator; // Variavel que recebe componente de Animator
  int playerPositionIndex = 1; // Variavel que guarda em que pista esta o player
  bool canMove = true; // Variavel que controla se o player pode se mover
  public static bool canJump = true; // Variavel que controla se o player pode pular
  bool isMoving = false; // Variavel que indica se o player esta em movimento
  bool isNewTouch = true; // Variavel que indica se há um novo toque na tela
  int direction = 0; // Variavel que indica direção do movimento do player

  float touchStartX, touchEndX; // Variaveis que guardam inicio e fim do toque na tela X
  float touchStartY, touchEndY; // Variaveis que guardam inicio e fim do toque na tela Y

  void Update() {
    /*  Verifica se tecla -> foi pressionada    Verifica se o player      Verifica se o player
    .                                           ja esta na direita        Pode se mover no momento */
    if (Input.GetKeyDown(KeyCode.RightArrow) && playerPositionIndex < 2 && canMove){
      playerPositionIndex++; // Indico que o player moveu uma casa para direita
      direction = 1; // Indico que a direção é para direita
      isMoving = true; // Digo que o player esta se movendo
    }
    /*  Verifica se tecla <- foi pressionada    Verifica se o player      Verifica se o player
    .                                           ja esta na esquerda       Pode se mover no momento */
    else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerPositionIndex > 0 && canMove) {
      playerPositionIndex--; // Indico que o player moveu uma casa para esquerda
      direction = -1; // Indico que a direção é para esquerda
      isMoving = true; // Digo que o player esta se movendo
    }

    if (Input.touchCount == 1) { // Verifica se há um dedo na tela
      if (Input.GetTouch(0).phase == TouchPhase.Began) { // Verifica se o dedo acabou de tocar na tela
        touchStartX = Input.GetTouch(0).position.x; // Marca o X inicial do dedo
        touchStartY = Input.GetTouch(0).position.y; // Marca o Y inicial do dedo
      }

      if (Input.GetTouch(0).phase == TouchPhase.Moved && isNewTouch) { // Verifica se o dedo se moveu em um novo toque
        touchEndX = Input.GetTouch(0).position.x; // Marca o X final do dedo
        touchEndY = Input.GetTouch(0).position.y; // Marca o y final do dedo

        if (Mathf.Abs(touchEndX - touchStartX) > 100) { // Verifica se a distância do deslize é maior que 300
          isNewTouch = false; // Mudo variável de controle indicando que esta ocorrendo um toque antigo
          if (touchEndX - touchStartX < 0 && playerPositionIndex > 0 && canMove) { // Verifica se há espaço para movimento
            playerPositionIndex--; // Indico que o player moveu uma casa para esquerda
            direction = -1; // Indico que a direção é para esquerda
            isMoving = true; // Digo que o player esta se movendo
          } else if (touchEndX - touchStartX > 0 && playerPositionIndex < 2 && canMove) { // Verifica se há espaço para movimento
            playerPositionIndex++; // Indico que o player moveu uma casa para direita
            direction = 1; // Indico que a direção é para direita
            isMoving = true; // Digo que o player esta se movendo
          }
        } else if (touchEndY - touchStartY > 100 && canJump) {
          isNewTouch = false; // Mudo variável de controle indicando que esta ocorrendo um toque antigo
          jump(); // Executo função para pular
        }
      }

      if (Input.GetTouch(0).phase == TouchPhase.Ended) { // Verifica se o dedo saiu e voltou para tela
        isNewTouch = true; // Modifica variável de controle indicando que é um novo toque
      }
    }
  }

  void FixedUpdate() {
    if (isMoving) {
      canMove = false; // Desabilito a movimentação do player
      // Coloco a velocidade do player como x: velocidade * direção, y: 0, z: 0
      playerRigidbody.velocity = new Vector3(changePositionVelocity * direction, 0, 0);

      //  Verifico se a posição X do player é maior ou igual a posição da pista a sua direta  OU Verifico se a posição X do player é menor ou igual a posição da pista a sua direta
      if (transform.position.x >= positions[playerPositionIndex].position.x && direction == 1 || transform.position.x <= positions[playerPositionIndex].position.x && direction == -1)
        stopMoving(); // Chamo a função que faz o player parar de se mover
    }
  }

  void stopMoving() {
    canMove = true;
    isMoving = false;
    playerRigidbody.velocity = Vector3.zero;
    // Reinicio todas as variaveis
  }

  void jump() {
    animator.SetBool("isJumping", true);
  }
}
