using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateColor : MonoBehaviour {
    Material mat;
    public Color starCol;
    public Color endCol;
    public Color xplodeColor;

    void Start() {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
        EventCoordinator.StartListening(EventName.Environment.StartChurchDestruction(), OnStartChurchDestruction);
    }

    void OnStartChurchDestruction(GameMessage msg) {
        mat.color = xplodeColor;
    }

    void Update() {
        mat.color = Color.Lerp(starCol, endCol, Mathf.Sin(Time.time));
    }
}