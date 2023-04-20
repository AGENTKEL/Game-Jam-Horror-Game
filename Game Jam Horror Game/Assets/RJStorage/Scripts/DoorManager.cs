using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [Header("doors")]
    //yes, im this lazy.
    public GameObject GObunkerDoor1;
    public Animator bunkerDoor1;
    public bool bunkerdoor1open;

    public GameObject GObunkerDoor2;
    public Animator bunkerDoor2;
    public bool bunkerdoor2open;

    public GameObject GOdoubleDoors1L;
    public GameObject GOdoubleDoors1R;
    public Animator doubleDoors1L;
    public Animator doubleDoors1R;
    public bool doubledoors1open = false;

    public GameObject GOalreadyOpenDoor;
    public Animator alreadyOpenDoor;
    public bool alreadyopendooropen = true;

    public GameObject GOdoubleDoors2L;
    public GameObject GOdoubleDoors2R;
    public Animator doubleDoors2L;
    public Animator doubleDoors2R;
    public bool doubledoors2open = false;

    public GameObject GOtoiletL;
    public Animator ToiletL;
    public bool toiletLopen = false;
    
    public GameObject GOtoiletR;
    public Animator ToiletR;
    public bool toiletRopen = false;

    [Header("sounds")]
    public AudioClip bunkerdooropenSound;

    private AudioSource audiosrc;

    void Update()
    {
        //god this code is stinky
        // just realised i can generalise this with interactionmanager.interactedobject (i should make that a shorter variable)
        // as in like, interactionmanager.interactedobject.play("dooropen", 0, 0.0f);
        // this only doesn't work if it's the bunker doors or a locked door, which is a majority of them i have just realised
        // i guess i could still do it but include a little if (interactionmanager.interactedobject == bunkerdoor1 && KeypadManager.KeypadOneComplete && !bunkderdoor1open)
        // idk it'd have to include something like that but theres something here!
        if (InteractionManager.DoorInteracted == true)
        {
            audiosrc = InteractionManager.interactedObject.GetComponent<AudioSource>();
            if (InteractionManager.interactedObject == GObunkerDoor1 && KeypadManager.KeypadOneComplete && bunkerdoor1open == false)
            {
                bunkerDoor1.Play("BunkerDoorOpen", 0, 0.0f);
                audiosrc.clip = bunkerdooropenSound;
                audiosrc.Play();
                bunkerdoor1open = true;
            }
            else if (InteractionManager.interactedObject == GObunkerDoor2 && KeypadManager.KeypadTwoComplete && bunkerdoor2open == false)
            {
                bunkerDoor2.Play("BunkerDoorOpen", 0, 0.0f);
                audiosrc.clip = bunkerdooropenSound;
                audiosrc.Play();
                bunkerdoor2open = true;
            }
            else if (InteractionManager.interactedObject == GOdoubleDoors1L || GOdoubleDoors1R)
            {
                
            }
            else if (InteractionManager.interactedObject == GOalreadyOpenDoor)
            {
                
            }
            else if (InteractionManager.interactedObject == GOdoubleDoors2L || GOdoubleDoors2R)
            {
                
            }
            else if (InteractionManager.interactedObject == GOtoiletL)
            {
                
            }
            else if (InteractionManager.interactedObject == GOtoiletR)
            {
                
            }
            InteractionManager.DoorInteracted = false;
        }
    }
}
