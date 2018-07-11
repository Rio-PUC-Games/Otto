﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Tongue : MonoBehaviour {

    Transform intObject = null;

    public Animator anim;

    [HideInInspector]
    public static bool Agarrado;

    // Use this for initialization
    void Awake()
    {
        //anim.SetBool("dentroBoca", false);
    }
    void Start () {
        
        Agarrado = false;
    }
    
    // Update is called once per frame
    void Update () {
        if (intObject != null){
            print(intObject);   
        } else {
        }
    } 

    public void ShowTongue(bool active)
    {
        gameObject.SetActive(active);
        if (active == false)
        {
            anim.SetBool("dentroBoca", false);
            freeTongue();
        } else {

            anim.SetBool("dentroBoca", true);
            GetComponent<AudioSource>().Play();
        }
    }

    private void freeTongue() {
        
        if (intObject != null)
        {
            if (intObject.tag == "Objeto Interagível")
            {
                InteragibleObjects obj = intObject.GetComponent<InteragibleObjects>();

                if (obj.Fixed == false && obj.isFollowingPlayer)
                {
                    obj.freeObjectFromtongue();
                    intObject = null;
                    Agarrado = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Objeto Interagível"){
            intObject = other.transform;
            checkObject(other);
            Agarrado = true;
        }
    }

    // Se soltar o botão enquanto estiver tocando o objeto ele irá puxar o objeto ou ser puxado
    // Se ele largar fora do objeto nada acontece
    private void OnTriggerExit(Collider other)
    {
        //intObject = null; 

    }

    private void OnTriggerStay(Collider other)
    {
        checkObject(other);
    }

    private void checkObject(Collider other)
    {
        if (other.tag == "Objeto Interagível")
        {
            InteragibleObjects obj = other.GetComponent<InteragibleObjects>();

            if (obj.Fixed == false)
            {
                obj.pullObject(this.transform.parent);
            }
            else if (obj.Fixed == true)
            {
                //obj.pullPlayer(this.transform.parent);
            }
        }
    }


}
