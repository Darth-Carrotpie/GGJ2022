using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Event Sent");
            EventCoordinator.TriggerEvent(EventName.Environment.StartChurchDestruction(),GameMessage.Write());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EventCoordinator.TriggerEvent(EventName.Environment.ChurchCleanUp(),GameMessage.Write());
        }

    }
}
