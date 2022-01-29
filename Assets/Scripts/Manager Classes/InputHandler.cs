using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public int playerID;
    PlayerInputs myInputs = null;

    public static string Accelerate() { return "Input_Accelerate"; }
    public static string Decelerate() { return "Input_Decelerate"; }
    public static string Turn() { return "Input_Turn"; }
    public static string Hide() { return "Input_Hide"; }
    public static string Fireball() { return "Input_Fireball"; }

    public void Create(int _playerID, PlayerInputs _inputs) {
        playerID = _playerID;
        myInputs = _inputs;
    }
    void Awake() {
        if (myInputs == null) {
            myInputs = InputsBucket.GetDefault();
        }
    }
    void Update() {
        if (Input.GetKeyDown(myInputs.accelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Accelerate(), GameMessage.Write().WithContState(ContStateEnum.Start));
        }
        if (Input.GetKeyUp(myInputs.accelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Accelerate(), GameMessage.Write().WithContState(ContStateEnum.Stop));
        }
        if (Input.GetKeyDown(myInputs.decelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Decelerate(), GameMessage.Write().WithContState(ContStateEnum.Start));
        }
        if (Input.GetKeyUp(myInputs.decelerate)) {
            EventCoordinator.TriggerEvent(EventName.Input.Decelerate(), GameMessage.Write().WithContState(ContStateEnum.Stop));
        }
        if (Input.GetKeyDown(myInputs.turnLeft)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Start).WithTurnSide(TurnSideEnum.Left));
        }
        if (Input.GetKeyUp(myInputs.turnLeft)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Stop).WithTurnSide(TurnSideEnum.Left));
        }
        if (Input.GetKeyDown(myInputs.turnRight)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Start).WithTurnSide(TurnSideEnum.Right));
        }
        if (Input.GetKeyUp(myInputs.turnRight)) {
            EventCoordinator.TriggerEvent(EventName.Input.Turn(), GameMessage.Write().WithContState(ContStateEnum.Stop).WithTurnSide(TurnSideEnum.Right));
        }
        if (Input.GetKeyDown(myInputs.hide)) {
            EventCoordinator.TriggerEvent(EventName.Input.ChangeHidden(), GameMessage.Write());
        }
        if (Input.GetKeyDown(myInputs.fireball)) {
            EventCoordinator.TriggerEvent(EventName.Input.Fireball(), GameMessage.Write());
            Debug.Log("Fireball!");
        }
    }
}