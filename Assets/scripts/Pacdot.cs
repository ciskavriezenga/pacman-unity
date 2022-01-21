using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
  public Score highscore;
  //public GameObject gameObject;

  // OnTriggerEnter2D is called when Pacman triggers a pellet
  void OnTriggerEnter2D(Collider2D co)
  {
    Debug.Log("trigger!");
    if (co.name == "pacman")
    {
      Destroy(gameObject);
      highscore.increment();
    }
  }
}
