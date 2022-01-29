using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleFactory : Singleton<TurtleFactory> {
    List<GameObject> turtles = new List<GameObject>();
    int currentPlayerID = 0;
    public GameObject turtlePrefab;
    bool matchStarted = false;
    public float turtleStandRadius = 3.5f;
    void Awake() {
        EventCoordinator.StartListening(EventName.Input.StartLevel(), OnMatchStarted);
    }
    void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.StartLevel(), OnMatchStarted);
    }
    void OnMatchStarted(GameMessage msg) {
        matchStarted = true;
    }

    public static void AddTurtle(PlayerTypeEnum turtleType) {
        GameObject newTurtle = Instantiate(Instance.turtlePrefab);
        Instance.turtles.Add(newTurtle);
        newTurtle.GetComponent<Turtle>().playerID = Instance.currentPlayerID;
        newTurtle.transform.parent = Instance.transform;
        if (turtleType == PlayerTypeEnum.HumanPlayer)
            newTurtle.GetComponent<Turtle>().SetPlayerToHuman();
        Instance.RePositionTurtles();
        Instance.currentPlayerID++;
    }
    public static void RemoveAITurtle() {
        RemoveTurtle(PlayerTypeEnum.AI);
    }
    public static void RemovePlayerTurtle() {
        RemoveTurtle(PlayerTypeEnum.HumanPlayer);
    }
    public static void RemoveTurtle(PlayerTypeEnum turtleType) {
        for (int i = Instance.turtles.Count - 1; i >= 0; i--) {
            if (Instance.turtles[i].GetComponent<Turtle>().playerType == turtleType) {
                Destroy(Instance.turtles[i]);
                Instance.turtles.RemoveAt(i);
            }
        }
        Instance.currentPlayerID--;
        Instance.RePositionTurtles();
    }

    public static void RemoveTurtle(Turtle targetTurtle) {
        foreach (GameObject turtle in Instance.turtles) {
            if (turtle.GetComponent<Turtle>() == targetTurtle) {
                Destroy(turtle);
            }
        }
        Instance.currentPlayerID--;
        Instance.RePositionTurtles();
    }

    void RePositionTurtles() {
        if (matchStarted)return;
        float angle = 1.5f / turtles.Count;
        for (int i = 0; i < turtles.Count; i++) {
            turtles[i].transform.position = CalculateNewPosition(angle * i);
            turtles[i].transform.LookAt(transform);
        }
    }
    Vector3 CalculateNewPosition(float angle) {
        float x = Mathf.Cos(angle) * turtleStandRadius;
        float y = 0;
        float z = Mathf.Sin(angle) * turtleStandRadius;
        return new Vector3(x, y, z);
    }
}