using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {
    PlayerTypeEnum playerType;

    public bool IsAI {
        get {
            return playerType == PlayerTypeEnum.AI;
        }
    }
    public bool IsHumanPlayer {
        get {
            return playerType == PlayerTypeEnum.HumanPlayer;
        }
    }
    public void SetPlayerToHuman() {
        playerType = PlayerTypeEnum.HumanPlayer;
    }

    void Start() {

    }

}