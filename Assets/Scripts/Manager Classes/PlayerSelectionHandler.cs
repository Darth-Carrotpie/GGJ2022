using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionHandler : MonoBehaviour {
    public void SelectOne() {
        EventCoordinator.TriggerEvent(EventName.Input.PlayerAmountSelected(), GameMessage.Write().WithPlayerAmount(1));
    }
    public void SelectTwo() {
        EventCoordinator.TriggerEvent(EventName.Input.PlayerAmountSelected(), GameMessage.Write().WithPlayerAmount(2));
    }
    public void SelectThree() {
        EventCoordinator.TriggerEvent(EventName.Input.PlayerAmountSelected(), GameMessage.Write().WithPlayerAmount(3));
    }
    public void SelectFour() {
        EventCoordinator.TriggerEvent(EventName.Input.PlayerAmountSelected(), GameMessage.Write().WithPlayerAmount(4));
    }
}