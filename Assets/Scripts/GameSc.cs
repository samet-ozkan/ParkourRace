using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSc : MonoBehaviour
{

    public GameObject player1Win;
    public GameObject player2Win;

    void Start(){
        player1Win.SetActive(false);
        player2Win.SetActive(false);
    }
    public void P1Win(){
        player1Win.SetActive(true);
        Time.timeScale = 0f;
    }

    public void P2Win(){
        player2Win.SetActive(true);  
        Time.timeScale = 0f;
    }
}
