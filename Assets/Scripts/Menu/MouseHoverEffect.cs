using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject Effect;

    public bool on_off;

    void Start(){

        if(Effect.activeSelf){
            on_off = true;
        }else{
            on_off = false;
        }
    }
    
    void OnMouseOver()
    {
        Effect.SetActive(true);
    }

    void OnMouseExit()
    {
        if(on_off==false){
            Effect.SetActive(false);
        }
    }
}
