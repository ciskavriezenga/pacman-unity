using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {
    public Transform[] waypoints;
    int curIndex = 0;
    public Vector2 startPos;
    public float speed = 0.3f;

    void Start() {
      transform.position = startPos; 
    }
    void FixedUpdate () {
        // Waypoint not reached yet? then move closer
        if (!FV_Utilities.equalVec2((Vector2)transform.position, waypoints[curIndex].position, 0.01f)) {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[curIndex].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        } else { // Waypoint reached, select next one
          curIndex = (curIndex + 1) % waypoints.Length;
          // alter Animation
          Vector2 dir = waypoints[curIndex].position - transform.position;
          GetComponent<Animator>().SetFloat("DirX", dir.x);
          GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
    }

    void OnTriggerEnter2D(Collider2D co) {
    if (co.name == "pacman")
        Destroy(co.gameObject);
    }
}
