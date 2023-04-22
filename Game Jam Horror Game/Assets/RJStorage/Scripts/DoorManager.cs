using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    private GameObject obj;
    private Animator anim;

    [Header("doors")]
    //yes, im this lazy.
    public GameObject GObunkerDoor1;
    public bool bunkerdoor1open;

    public GameObject GObunkerDoor2;
    public bool bunkerdoor2open;

    public GameObject GOdoubleDoors1L;
    public GameObject GOdoubleDoors1R;
    public Animator doubleDoors1L;
    public Animator doubleDoors1R;
    public bool doubledoors1open = false;

    public GameObject GOalreadyOpenDoor;
    public bool alreadyopendooropen = true;

    public GameObject GOdoubleDoors2L;
    public GameObject GOdoubleDoors2R;
    public Animator doubleDoors2L;
    public Animator doubleDoors2R;
    public bool doubledoors2open = false;

    public GameObject GOtoiletL;
    public bool toiletLopen = false;
    
    public GameObject GOtoiletR;
    public bool toiletRopen = false;

    [Header("sounds")]
    public AudioClip bunkerdooropenSound;

    private AudioSource audiosrc;

    static public bool chaseOn;
    


    void Update()
    {
        //god this code is stinky
        //shouldn't be hard to add different open/closed noises but rn its just one noise per door
        if (InteractionManager.DoorInteracted)
        {
            obj = InteractionManager.interactedObject;
            audiosrc = obj.GetComponent<AudioSource>();
            anim = obj.GetComponent<Animator>();
            if (obj == GObunkerDoor1 && KeypadManager.KeypadOneComplete && bunkerdoor1open == false)
            {
                anim.Play("BunkerDoorOpen", 0, 0.0f);
                audiosrc.clip = bunkerdooropenSound;
                audiosrc.Play();
                bunkerdoor1open = true;
            }
            else if (obj == GObunkerDoor2 && KeypadManager.KeypadTwoComplete && bunkerdoor2open == false)
            {
                anim.Play("BunkerDoorOpen", 0, 0.0f);
                audiosrc.clip = bunkerdooropenSound;
                audiosrc.Play();
                bunkerdoor2open = true;
            }
            else if ((obj == GOdoubleDoors1L || obj == GOdoubleDoors1R) && InteractionManager.KeyGet1)
            {
                if (doubledoors1open)
                {
                    doubleDoors1L.Play("DC_DD1L", 0, 0.0f);
                    doubleDoors1R.Play("DC_DD1R", 0, 0.0f);
                }
                else if (!chaseOn)
                {
                    doubleDoors1L.Play("DO_DD1L", 0, 0.0f);
                    doubleDoors1R.Play("DO_DD1R", 0, 0.0f);
                }
                audiosrc.Play();
                doubledoors1open = !doubledoors1open;
            }
            else if ((obj == GOdoubleDoors2L || obj == GOdoubleDoors2R) && InteractionManager.KeyGet2)
            {
                if (doubledoors2open)
                {
                    doubleDoors2L.Play("DC_DD2L", 0, 0.0f);
                    doubleDoors2R.Play("DC_DD2R", 0, 0.0f);
                }
                else if (!chaseOn)
                {
                    doubleDoors2L.Play("DO_DD2L", 0, 0.0f);
                    doubleDoors2R.Play("DO_DD2R", 0, 0.0f);
                }
                audiosrc.Play();
                doubledoors2open = !doubledoors2open;
            }
            else if (obj == GOalreadyOpenDoor)
            {
                if (alreadyopendooropen)
                    anim.Play("DoorClose", 0, 0.0f);
                else if (!chaseOn)
                    anim.Play("DoorOpen", 0, 0.0f);
                audiosrc.Play();
                alreadyopendooropen = !alreadyopendooropen;
            } 
            else if (obj == GOtoiletL)
            {
                if (toiletLopen)
                    anim.Play("DC_T", 0, 0.0f);
                else if (!chaseOn)
                    anim.Play("DO_T", 0, 0.0f);
                audiosrc.Play();
                toiletLopen = !toiletLopen;
            }
            else if (obj == GOtoiletR)
            {
                if (toiletRopen)
                    anim.Play("DC_T", 0, 0.0f);
                else if (!chaseOn)
                    anim.Play("DO_T", 0, 0.0f);
                audiosrc.Play();
                toiletRopen = !toiletRopen;
            }
            InteractionManager.DoorInteracted = false;
        }
    }
}
