using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour {
    int playerAmount;
    bool gameStarted;
    void Start() {
        EventCoordinator.StartListening(EventName.System.PlayerDeath(), OnDeath);
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StartListening(EventName.Input.PlayerAmountSelected(), OnPlayerAmountSelected);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.PlayerDeath(), OnDeath);
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StopListening(EventName.Input.PlayerAmountSelected(), OnPlayerAmountSelected);
    }
    void OnDeath(GameMessage msg) {
        if (gameStarted)
            if (msg.sourceTurtle.IsHumanPlayer)
                TurtleFactory.RemoveTurtle(msg.sourceTurtle);
        if (playerAmount == 0) {
            EventCoordinator.TriggerEvent(EventName.System.GameEnd(), GameMessage.Write().WithSourceTurtle(null));
        }
        if (playerAmount == 1) {
            if (TurtleFactory.GetAITurtleCount() == 0) {
                Turtle turtle = TurtleFactory.GetPlayerTurtles()[0].GetComponent<Turtle>();
                EventCoordinator.TriggerEvent(EventName.System.GameEnd(), GameMessage.Write().WithSourceTurtle(turtle));
            }
        }
    }
    void OnPlayerAmountSelected(GameMessage msg) {
        if (!gameStarted)
            playerAmount = msg.playerAmount;
    }
    void OnStartGame(GameMessage msg) {
        gameStarted = true;
    }
}