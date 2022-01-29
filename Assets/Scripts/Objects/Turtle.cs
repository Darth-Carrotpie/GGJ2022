using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {
    public PlayerTypeEnum playerType;
    public GameObject turtleModelPrefab;
    TurtleModel myModel;
    public int playerID;

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
        if (myModel == null) {
            GameObject newModel = Instantiate(turtleModelPrefab, Vector3.zero, Quaternion.identity);
            myModel = newModel.GetComponent<TurtleModel>();
            myModel.transform.parent = transform;
            myModel.transform.localPosition = Vector3.zero;
            myModel.transform.localRotation = Quaternion.identity;
        }
    }

    public void Die() {

    }

}