using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionCleanUp : MonoBehaviour
{
    Mesh mesh = null;
    float volume;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().sharedMesh;
        volume = VolumeOfMesh(mesh);
        EventCoordinator.StartListening(EventName.Environment.ChurchCleanUp(), OnChurchCleanUp);
        string msg = "The volume of the mesh is " + volume + " cube units.";
        //Debug.Log(msg);
    }
    private void OnDestroy()
    {
        EventCoordinator.StopListening(EventName.Environment.ChurchCleanUp(), OnChurchCleanUp);
    }
    public float VolumeOfMesh(Mesh mesh)
    {
        float volume = 0;

        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i + 0]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            volume += SignedVolumeOfTriangle(p1, p2, p3);
        }
        return Mathf.Abs(volume);
    }
    float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float v321 = p3.x * p2.y * p1.z;
        float v231 = p2.x * p3.y * p1.z;
        float v312 = p3.x * p1.y * p2.z;
        float v132 = p1.x * p3.y * p2.z;
        float v213 = p2.x * p1.y * p3.z;
        float v123 = p1.x * p2.y * p3.z;

        return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnChurchCleanUp(GameMessage msg)
    {
        StartCoroutine(ChurchCleanUp());
    }
    IEnumerator ChurchCleanUp()
    {
        float time = Random.RandomRange(0f,5f);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
