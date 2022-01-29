using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_fireball : MonoBehaviour
{

    public GameObject effect;
    public Transform effectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("0")){
            Instantiate(effect, effectTransform.position, effectTransform.rotation);
        }
    }
}
