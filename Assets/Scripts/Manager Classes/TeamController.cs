using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour {

    int currentPlayerAmount;
    int currentAIAmount;
    public int AIAmount;

    void Start() {
        EventCoordinator.StartListening(EventName.Input.PlayerAmountSelected(), OnPlayerAmountSelected);
        CreateInitialTurtles();
    }

    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.PlayerAmountSelected(), OnPlayerAmountSelected);
    }

    void CreateInitialTurtles() {
        for (int i = 0; i < AIAmount; i++) {
            TurtleFactory.AddTurtle(PlayerTypeEnum.AI);
        }
        TurtleFactory.AddTurtle(PlayerTypeEnum.HumanPlayer);
        currentPlayerAmount++;
    }

    void OnPlayerAmountSelected(GameMessage msg) {
        if (currentPlayerAmount != msg.playerAmount) {
            int difference = msg.playerAmount - currentPlayerAmount;
            if (difference > 0) {
                for (int i = 0; i < difference; i++) {
                    TurtleFactory.AddTurtle(PlayerTypeEnum.HumanPlayer);
                }
            }
            if (difference < 0) {
                for (int i = 0; i < -difference; i++) {
                    TurtleFactory.RemovePlayerTurtle();
                }
            }
            currentPlayerAmount = msg.playerAmount;
        }
    }
}