using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Transform[] platformPosition = new Transform[3];
    int direction = 1;
    public float speed;
    Vector2 target;
    // Start is called once per frame
    void Update()
    {
        target = currentMovementTarget();

        platformPosition[0].position = Vector2.Lerp(platformPosition[0].position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platformPosition[0].position).magnitude;

        if (distance <= .5f)
        {
            direction *= -1;
        }
    }
    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return platformPosition[1].position;
        }
        else
        {
            return platformPosition[2].position;
        }
    }
}
