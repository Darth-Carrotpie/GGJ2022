using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public int playerID;
    public int inputID;
    PlayerInputs myInputs = null;
    public bool gameStarted = false;

    public void Create(int _playerID, PlayerInputs _inputs) {
        playerID = _playerID;
        myInputs = _inputs;
    }
    public void SetInputs(PlayerInputs inputs) {
        myInputs = inputs;
    }
    void Awake() {
        if (myInputs == null) {
            myInputs = InputsBucket.GetDefault();
        }
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
    }
    void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
    }
    void OnStartGame(GameMessage msg) {
        gameStarted = true;
    }
    void Update() {
        if (Input.GetKeyDown(myInputs.fireball)) {
            EventCoordinator.TriggerEvent(EventName.Input.Fireball(), GameMessage.Write().WithPlayerID(playerID));
        }
        if (!gameStarted)return;
        if (Input.GetKeyDown(myInputs.accelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Accelerate(), GameMessage.Write().WithContState(ContStateEnum.Start).WithPlayerID(playerID));
        }
        if (Input.GetKeyUp(myInputs.accelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Accelerate(), GameMessage.Write().WithContState(ContStateEnum.Stop).WithPlayerID(playerID));
        }
        if (Input.GetKeyDown(myInputs.decelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Decelerate(), GameMessage.Write().WithContState(ContStateEnum.Start).WithPlayerID(playerID));
        }
        if (Input.GetKeyUp(myInputs.decelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Decelerate(), GameMessage.Write().WithContState(ContStateEnum.Stop).WithPlayerID(playerID));
        }
        if (Input.GetKeyDown(myInputs.turnLeft)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Start).WithTurnSide(TurnSideEnum.Left).WithPlayerID(playerID));
        }
        if (Input.GetKeyUp(myInputs.turnLeft)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Stop).WithTurnSide(TurnSideEnum.Left).WithPlayerID(playerID));
        }
        if (Input.GetKeyDown(myInputs.turnRight)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Start).WithTurnSide(TurnSideEnum.Right).WithPlayerID(playerID));
        }
        if (Input.GetKeyUp(myInputs.turnRight)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Stop).WithTurnSide(TurnSideEnum.Right).WithPlayerID(playerID));
        }
        if (Input.GetKeyDown(myInputs.hide)) {
            EventCoordinator.TriggerEvent(EventName.Input.ChangeHidden(), GameMessage.Write().WithPlayerID(playerID));
        }
    }
}