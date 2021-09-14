using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_UI : MonoBehaviour
{
  [SerializeField] GameObject menu_UI;
  public void GoBack()
  {
    menu_UI.SetActive(true);
    gameObject.SetActive(false);
  }
}
