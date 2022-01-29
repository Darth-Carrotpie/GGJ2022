using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowIso : MonoBehaviour {
    public List<Transform> objectsToFollow;

    [Header("Camera follow Settings")]
    public Vector3 offset;
    public float followTime = 0.5f;
    [Header("Camera zoom Settings")]
    public float minZoom = 40f;
    public float maxZoom = 5f;
    public float limit = 50f;
    public float zoomSpeed = 10;

    private Camera cam;
    Vector3 velocity;
    void Start() {
        cam = GetComponent<Camera>();
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
    }

    void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
    }

    void OnStartGame(GameMessage msg) {
        objectsToFollow = TurtleFactory.GetPlayerTurtles();
    }
    void LateUpdate() {
        if (objectsToFollow.Count < 1) {
            //Debug.Log("Please insert atleast one Target to follow! in <" + this.GetType() + "> Script, on <" + gameObject.name + "> object.");
            //Debug.Break();
        } else {
            Vector3 pos = calculateCenter() + offset;
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, followTime);
            float zoomCalculate = Mathf.Lerp(maxZoom, minZoom, zooming() / limit);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomCalculate, Time.deltaTime * zoomSpeed);
        }
    }

    float zooming() {
        var objectsBounds = new Bounds(objectsToFollow[0].position, Vector3.zero);
        for (int i = 0; i < objectsToFollow.Count; i++) {
            objectsBounds.Encapsulate(objectsToFollow[i].position);
        }

        return objectsBounds.size.x;
    }

    Vector3 calculateCenter() {
        if (objectsToFollow.Count == 1)return objectsToFollow[0].position;

        var objectsBounds = new Bounds(objectsToFollow[0].position, Vector3.zero);
        for (int i = 0; i < objectsToFollow.Count; i++) {
            objectsBounds.Encapsulate(objectsToFollow[i].position);
        }
        return objectsBounds.center;
    }

}