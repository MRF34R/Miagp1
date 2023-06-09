using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Chase : StateMachineBehaviour
{
    
    //a box to store the player's transform information
    Transform player;
    //a box that stores the Bosses rigidbody
    Rigidbody2D rb;
    //create a box that will store the bosses behavior
    BossBehavior bossBehavior;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //set the reference for the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //set the reference for out bosses rb
        rb = animator.GetComponent<Rigidbody2D>();
        //set the reference for our boss behavior
        bossBehavior = animator.GetComponent<BossBehavior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //bossBehavior.LookAtPlayer();
        //declaring and setting the player to the target for our boss, locking the y axis
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        //Sets a new position for our boss to move towards
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossBehavior.speed * Time.deltaTime);
        //tell our rb to move to the newPos
        rb.MovePosition(newPos);
        //check the distance between the boss and player, set a trigger to start an attack
        float distance = Vector2.Distance(player.position, rb.position);

        if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && !bossBehavior.phase3)
        {
            Debug.Log("hit");
        }
        else if (distance < bossBehavior.attackRange && bossBehavior.phase2 && !bossBehavior.phase3)
        {

        }
        else if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && bossBehavior.phase3)
        {

        }
        else if (bossBehavior.isDead)
        {

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
}
