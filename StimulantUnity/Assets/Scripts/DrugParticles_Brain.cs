using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugParticles_Brain : MonoBehaviour {

	//public Light myLight;
	public float timer;
    public float speed;
    public float delay;

	// for tracking properties change
    private Vector3 _extents;
    private int _sphereCount;
    private float _sphereSize;

    /// <summary>
    ///     How far to place spheres randomly.
    /// </summary>
    public Vector3 Extents;
    public Vector3 gameObjectExtents;


    /// <summary>
    ///     How many spheres wanted.
    /// </summary>
    public int SphereCount;

    public float SphereSize;

    public float x;
    public float y;
    public float z;

    public bool initialized = false;

    float subtract = .3f;

    Waypoints wp;
    void Start(){
        //pController = new PanelController();
        //Initialized();
        SpawnSpheres();
        delay = 10f;
    }

    void Initialized(){
        gameObjectExtents = this.transform.position;
        timer = 0f;
        speed = 3f;
        x = gameObjectExtents.x - 10;
        y = gameObjectExtents.y + 12;
        z = gameObjectExtents.z;
        Extents = new Vector3(Mathf.Max(0.0f, x), Mathf.Max(0.0f, y), Mathf.Max(0.0f, z));
        initialized = true;

    }

    private void SpawnSpheres(){
        float dx = -54.7146f;
        float dy = y;
        float dz = z;

        for (var i = 0; i < 4; i++)
        {
            var o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.tag = "Drug";
            o.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);

            var color = new Color(200, 0, 0, 255);
            MeshRenderer gameObjectRenderer = o.GetComponent<MeshRenderer>();
 
            Material newMaterial = new Material(Shader.Find("Standard"));
            newMaterial.color = color;
            gameObjectRenderer.material = newMaterial;

            o.AddComponent<Movement>();
            var parent = GameObject.Find("Panel10").transform;
            o.transform.parent = parent;
            Movement so = o.GetComponent<Movement>();
            so.lerpTime = so.lerpTime - subtract;

            o.transform.localScale = new Vector3(2f, 2f, 2f);

            //if(i % 2 == 0)
           	so.waypoints = Waypoints.GetWaypoints("Brain");
            o.transform.localPosition = new Vector3(-28f, -1.4f, -383.1f);

            subtract -= .15f;
            dx += 2.2f;
        }

  
    }
}
