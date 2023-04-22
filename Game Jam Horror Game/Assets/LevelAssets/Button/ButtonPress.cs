using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ButtonPress : MonoBehaviour
{
    public GameObject monster;
    public GameObject obstacles;
    public GameObject ambience;
    public GameObject ambienceBlows;
    public GameObject chaseMusic;
    public GameObject chaseMusicStart;
    public GameObject timerStart;
    public GameObject jumpscareOff;
    public Animator glassDoorOpen;
    public Animator glassDoorOpen2;
    public Animator monsterRage;
    public MonsterAI monsterAI;
    public GameObject explosions;

    public void ButtonPressed()
    {
        ambience.SetActive(false);
        ambienceBlows.SetActive(true);
        monster.SetActive(true);
        obstacles.SetActive(true);
        chaseMusicStart.SetActive(true);
        timerStart.SetActive(true);
        jumpscareOff.SetActive(false);
        explosions.SetActive(true);
        monsterRage.SetTrigger("Rage");
        glassDoorOpen.SetBool("Opened", true);
        glassDoorOpen2.SetBool("Opened", true);
        Invoke("MonsterCanMove", 3f);
        DoorManager.chaseOn = true;
    }

    public void MonsterCanMove()
    {
        monsterAI.sightRange = 500f;
        chaseMusic.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
