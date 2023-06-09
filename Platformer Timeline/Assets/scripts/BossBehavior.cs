using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //create a variable called bossHealth
    public int bossHealth = 10;
    public float attackRange = 3.5f;
    public float speed = 6;
    //create a series of bools to help transition us to our different phases
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    //create storage for our Transform 
    public Transform player;
    //create storage for our player manager script
    playermanager pManager;
    //create a storage location for a bool to check if boss is flipped
    public bool isFlipped = false;
    //start is called before the first frame update
    public Transform shotLocation;
    public float timer;
    public float coolDown;
    public GameObject projectile;
    void Start()
    {
        //sets and grabs the information we need to call our functions. 
        pManager = GameObject.FindGameObjectWithTag("Player").GetComponent<playermanager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called omnce per frame
    void Update()
    {
        //create a series of if else statements that will check to see if the boss
        //is below 7 and above 3, below 3 and above 1, and less than or equal to 0
        if (bossHealth < 7 && bossHealth > 3)
        {
            speed = 2;
            attackRange = 6;
            phase2 = true;
            Debug.Log("Phase2");
        }
        else if (bossHealth < 4 && bossHealth >= 1)
        {
            phase2 = false;
            phase3 = true;
            Debug.Log("Phase3");
        }
        else if (bossHealth <= 0)
        {
            phase3 = false;
            isDead = true;
            Debug.Log("isDead");
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        //bosses position
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }

    public void ProjectileShoot()
    {
        if (timer > coolDown)
        {
            if (phase2)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
            else if (phase3)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
        }
     }

}
