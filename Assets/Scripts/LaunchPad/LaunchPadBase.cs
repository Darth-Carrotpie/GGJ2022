using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadBase : MonoBehaviour
{
    public float LaunchPower = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.parent.name);
        if (collision.gameObject.GetComponent<Turtle>() != null)
        {
            Vector3 TargetVec = transform.forward + Vector3.up;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(TargetVec.normalized * LaunchPower, ForceMode.Impulse);

        }
    }
}
