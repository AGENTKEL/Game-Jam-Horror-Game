using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKill : MonoBehaviour
{
    public GameObject deathStinger;
    public GameObject gameoverStinger;
    public GameObject ambientOff;
    public GameObject chaseMusicOff;
    public GameObject deathScreen;



    public void KillPlayer()
    {
        Instantiate(deathStinger);
        Invoke("DeathScreen", 2f);
    }

    public void DeathScreen()
    {
        Instantiate(gameoverStinger);
        deathScreen.SetActive(true);
        Destroy(ambientOff);
        Destroy(chaseMusicOff);
        Time.timeScale = 0f;
        PlayerController.mouseUnlocked = true;
    }
}
