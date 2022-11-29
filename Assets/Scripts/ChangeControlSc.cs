using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControlSc : MonoBehaviour
{
    public enum Controls{
        Control1, Control2, Control3, Control4
    }
    public GameObject player;
    public Controls control;
    public Controls toControl;
    private PlayerSc playerSc;
    void Start(){
        playerSc = player.GetComponent<PlayerSc>();
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            setControl(control, false);
            setControl(toControl, true);
            this.gameObject.SetActive(false);
        }
    }

    private void setControl(Controls control, bool enable){
        switch(control){
            case Controls.Control1:
                player.GetComponent<Control1Sc>().enabled = enable;
                break;
            case Controls.Control2:
                player.GetComponent<Control2Sc>().enabled = enable;
                break;
            case Controls.Control3:
                player.GetComponent<Control3Sc>().enabled = enable;
                break;
            case Controls.Control4:
                player.GetComponent<Control4Sc>().enabled = enable;
                break;
            default:
                break;
        }
    }
}
