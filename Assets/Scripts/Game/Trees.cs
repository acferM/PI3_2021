using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour {
  [SerializeField] GameObject trees;

  private void Start()
  {
    spawnTree();
  }

  public void spawnTree()
  {
    var newTree = Instantiate(trees, transform.position, Quaternion.identity);

    newTree.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -Obstacle.speed);
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("tree"))
    {
      spawnTree();
    }
  }
}
