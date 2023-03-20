using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playermanager : MonoBehaviour
{
    //Set max health
    public int maxHealth;
    public int currentHealth;
    PlayerMovement playerMovement;
    public int coinCount;
    BossBehavior bossBehavior;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        UpdateScore(0);
        coinCount = (0);
    }
    public void UpdateScore(int scoreToAdd)
    {
        coinCount += scoreToAdd;
        scoreText.text = "Score:" + coinCount;
    }
    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coinCount++;
                UpdateScore(1);
                Debug.Log("You've found a coin");
                return true;
            case "Speed+":
                // call function here
                return true;
            default:
                Debug.Log("Item tag or refrence not set.");
                return false;
        }
    }
    public void takeDamage()
    {
        currentHealth -= 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
