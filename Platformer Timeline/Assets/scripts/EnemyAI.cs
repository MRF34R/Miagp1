using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    //Refrence to waypoints
    public List<Transform> points;
    //create an int that will represent our indexed transforms in our list
    public int nextId;
    //help us change our next Id value
    private int idChangeValue = 1;
    //set the speed of our enemy
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        //Set and get a goal point based off our lists index
        Transform goalPoint = points[nextId];
        //Flip the enemy to look at the next goalPoint
        //Might change based off your sprites natural direction
        if (goalPoint.transform.position.x > transform.position.x)
        {//1
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {//-1
            transform.localScale = new Vector3(1, 1, 1);
        }
        //move our enemy towards our goalPoint
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //check the distance between the enemy and the goalPoint to trigger the next point
        if (Vector2.Distance(transform.position, goalPoint.position)< 1f)
        {
            //check if we are at the end of our waypoints if so -1 index
            if (nextId == points.Count-1)
            {
                idChangeValue = -1;
            }
            //check if we are the start of our waypoints if so +1 index
            if (nextId == 0)
            {
                idChangeValue = 1;
            }
            nextId += idChangeValue;
        }
    }
}
