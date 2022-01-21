using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Pacdots : MonoBehaviour
{
  public Score highscore;
  private List<GameObject> dots = new List<GameObject>();
  public GameObject sceneData;
  // Start is called before the first frame update
  void Start()
  {
    Vector2 size = sceneData.GetComponent<SceneData>().mazeSize;
    int width = (int) size.x;
    Vector3 p = new Vector3(0,0,0);
    // NOTE: 790 - hardcoded value based on trial and error .. could be calculated
    for(int i = 0; i < 775; i++) {
      int posIndex = i;
      p.x = (float)(posIndex % width + 2);
      p.y = (float)(posIndex / width + 2);

      // check if there is a collider at this index, otherwise, add dot
      Collider2D collider = Physics2D.OverlapPoint(p);
      if(collider == null) {
        GameObject dot = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/prefabs/pacdot.prefab", typeof(Object));
        Instantiate(dot, p, Quaternion.identity);
        dot.GetComponent<Pacdot>().highscore = highscore;
        dots.Add(dot);
      }
    }

  }

  // Update is called once per frame
  void Update()
  {
  }
}
