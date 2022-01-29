using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingManager_by_Stasys : MonoBehaviour
{
    public GameObject effect;
    public Transform effectTransform;
    public float projectile_scale = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        effect.transform.localScale = new Vector3(projectile_scale, projectile_scale, projectile_scale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
            Instantiate(effect, effectTransform.position, effectTransform.rotation);
        }
    }

}
