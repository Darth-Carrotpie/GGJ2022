using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplerHandler : MonoBehaviour
{
    public float ExplosionForce;
    public float ExplosionRadius;
    public float ExplosionUpwardsMotion;
    public PhysicMaterial _physicsmaterial;
    // Start is called before the first frame update
    void Start()
    {
        EventCoordinator.StartListening(EventName.Environment.StartChurchDestruction(), OnStartChurchDestruction);
        foreach (Transform child in this.transform)
        { 
            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.AddComponent<MeshCollider>();
            child.gameObject.GetComponent<MeshCollider>().convex = true;
            child.gameObject.GetComponent<MeshCollider>().convex = true;
            child.gameObject.GetComponent<MeshCollider>().material = _physicsmaterial;
            child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnDestroy()
    {
        EventCoordinator.StopListening(EventName.Environment.StartChurchDestruction(), OnStartChurchDestruction);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnStartChurchDestruction(GameMessage msg)
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            child.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,ExplosionUpwardsMotion,0),ForceMode.Impulse);
            child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce, transform.position,ExplosionRadius);
            child.gameObject.AddComponent<DestructionCleanUp>();
        }
    }
}
