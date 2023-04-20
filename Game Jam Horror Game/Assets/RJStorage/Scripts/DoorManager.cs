using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [Header("doors")]
    //yes, im this lazy.
    public GameObject GObunkerDoor1;
    public Animator bunkerDoor1;

    public GameObject GObunkerDoor2;
    public Animator bunkerDoor2;

    public GameObject GOdoubleDoors1L;
    public GameObject GOdoubleDoors1R;
    public Animator doubleDoors1L;
    public Animator doubleDoors1R;

    public GameObject GOalreadyOpenDoor;
    public Animator alreadyOpenDoor;

    public GameObject GOdoubleDoors2L;
    public GameObject GOdoubleDoors2R;
    public Animator doubleDoors2L;
    public Animator doubleDoors2R;

    public GameObject GOtoiletL;
    public GameObject GOtoiletR;
    public Animator ToiletL;
    public Animator ToiletR;


    void Update()
    {
        if (InteractionManager.DoorInteracted == true)
        {
            
        }
    }
}
