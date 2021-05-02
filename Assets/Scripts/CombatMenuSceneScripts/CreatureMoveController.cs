using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMoveController : MonoBehaviour
{
    Vector2 moveTo = new Vector2(0,0);
    public float speed = 4f;

    public void updatePosAndMoveTo(float newLoc)
    {
        gameObject.transform.localPosition = new Vector2(0,newLoc);
        moveTo.y = newLoc;
    }

    public void updateMoveTo(float newLoc)
    {
        moveTo.y = newLoc;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector2.MoveTowards(transform.localPosition, moveTo, speed);
    }

    public Vector2 GetMoveTo()
    {
        return moveTo;
    } 
}
