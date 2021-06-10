using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReseter : MonoBehaviour {
  [SerializeField] Animator animator; // Variavel que recebe componente de Animator

  public void resetJump() {
    PlayerController.canJump = true;
    animator.SetBool("isJumping", false);
  }
}
