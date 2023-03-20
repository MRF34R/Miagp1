using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    playermanager manager;

    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //creates a location and reference for our player manager script
            playermanager manager = collision.GetComponent<playermanager>();
        }
        if (manager)
        {
            bool pickedUp = manager.PickupItem(gameObject);
            if (pickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
