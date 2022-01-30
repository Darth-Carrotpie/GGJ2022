using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterRotator : MonoBehaviour {

    void Start() {
        EventCoordinator.StartListening(EventName.Environment.StartChurchDestruction(), OnStartChurchDestruction);
    }

    void OnStartChurchDestruction(GameMessage msg) {
        GetComponent<RFX4_CameraShake>().PlayShake();
    }

    void FixedUpdate() {
        RotateForFun();
    }

    void RotateForFun() {
        transform.localRotation = Quaternion.Euler(0, Mathf.Sin(Time.time), 0);
    }
}