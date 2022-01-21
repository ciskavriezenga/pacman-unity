//#define DEBUG_PM_MOV

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PacmanMovement : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        // Make the game run as fast as possible
        Application.targetFrameRate = 100;
    }

    Vector2 MoveTo(Vector2 start, Vector2 end, float fraction)
    {
        Vector2 delta = end - start;
        Vector2 deltaFraction = delta * new Vector2(fraction, fraction);
        return start + deltaFraction;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*
         * Move c loser to Destination
         *
         * There are three options:
         *
         *   transform.position += moveDir * speed * Time.deltaTime;
         *   Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
         *
         *   Vector2 newPos = MoveTo(transform.position, dest, speed);
         *
         *   Vector2 newPos = Vector2.Lerp(transform.position, dest, speed);
         */
        Vector2 newPos = Vector2.Lerp(transform.position, dest, speed);

        GetComponent<Rigidbody2D>().MovePosition(newPos);

        // TODO create method that checks for equalness but with a variable delta

        Vector2 pos = (Vector2)transform.position;        

        // Check for Input if not moving
#if DEBUG_PM_MOV
        Debug.Log("pos vec3" + ((transform.position).ToString("F8")));
        Debug.Log("pos" + (((Vector2)transform.position).ToString("F8")));
        Debug.Log("des" + (dest.ToString("F8")));
#endif
        //if ((Vector2)transform.position == dest) {
        if (FV_Utilities.equalVec2((Vector2)transform.position, dest, 0.01f))
        {
            // reset to grid
            //  transform.position = (Vector2)(Vector2Int.RoundToInt(transform.position));

            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down))
                dest = (Vector2)transform.position + Vector2.down;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left))
                dest = (Vector2)transform.position + Vector2.left;
            dest = (Vector2)(Vector2Int.RoundToInt(dest));
            // Animation Parameters
            Vector2 dir = dest - (Vector2)transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
            // TODO - line cast from up and down side if going to right.
            // to prefend getting stuck at corners.
            // TODO 2 - continue tutorial
        }

    }



    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + Vector2.Scale(dir, new Vector2(1.5f, 1.5f)), pos);

#if DEBUG_PM_MOV
        Debug.Log("dir" + (dir));
        Debug.Log("pos + dir" + (pos + dir));
        Debug.Log("hit.col equal pacman? " + (hit.collider == GetComponent<Collider2D>()));
        if ((hit.collider == GetComponent<Collider2D>()) && pos.x > 18.9)
        {
            Debug.Log("**************** ");
            Debug.Log("col name: " + hit.collider.name);
            Debug.Log("pos.x = " + pos.x + "    pos.x + dir.x = " + (pos.x + dir.x));
            Debug.Log("**************** ");
        }
#endif
        // check for hit with Pac-Man himself --> nothing in-between
        // otherwise there must have been a wall.
        return (hit.collider == GetComponent<Collider2D>());
    }
}
