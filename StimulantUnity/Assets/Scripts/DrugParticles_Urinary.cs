using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugParticles_Urinary : MonoBehaviour {

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

    void Update(){
        if(PanelController.currentPanel == 17)
            UpdateSpheres();

            /*if(initialized){
                Initialized();
                SpawnSpheres();
            }*/

    }

    private void UpdateSpheres()
    {
        //timer += Time.deltaTime;
        /*var spheres = GameObject.FindGameObjectsWithTag("Drug");
        foreach (var t in spheres)
        {
            /*if(timer < delay){
                float step = speed * Time.deltaTime;
                t.transform.Translate(-step, 0f, 0f);            
            }*/

            //t.AddComponent("Movement");
        //}
        
        /*if(timer >= 5f){
            foreach(var t in spheres)
                Destroy(t);
            
            timer = 0;
            SpawnSpheres();
        }*/
    }

    private void SpawnSpheres(){
        float dx = -54.7146f;
        float dy = y;
        float dz = z;

        for (var i = 0; i < 8; i++)
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
            var parent = GameObject.Find("Panel17").transform;
            o.transform.parent = parent;
            Movement so = o.GetComponent<Movement>();
            so.lerpTime = so.lerpTime - subtract;

            o.transform.localScale = new Vector3(2f, 2f, 2f);

            if(i % 2 == 0){
                so.waypoints = Waypoints.GetWaypoints("Urinary");
                o.transform.localPosition = new Vector3(-54.7146f, 2.1792f, -267.04f);

            }

            else{
                so.waypoints = Waypoints.GetWaypoints("Urinary2");
                o.transform.localPosition = new Vector3(-18f, 2.2f, -267.04f);

            }

            subtract -= .15f;


           
            //o.transform.localPosition = new Vector3(-54.7146f, 2.1792f, -267.04f);
            dx += 2.2f;
        }

        /*for (var i = 0; i < 4; i++)
        {
            //var planePos = GameObject.Find("Plane").bounds;
            var o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.tag = "Drug";
            o.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);

            var color = new Color(200, 0, 0, 255);
            MeshRenderer gameObjectRenderer = o.GetComponent<MeshRenderer>();
 
            Material newMaterial = new Material(Shader.Find("Standard"));
            newMaterial.color = color;
            gameObjectRenderer.material = newMaterial;

            //var type = Type.GetType( "Movement" );
            o.AddComponent<Movement>();
            var parent = GameObject.Find("Panel17").transform;
            o.transform.parent = parent;
            Movement mov = o.GetComponent<Movement>();
            mov.lerpTime = .5f;

            mov.waypoints = Waypoints.GetWaypoints("Urinary2");
         

           
            o.transform.localScale = new Vector3(2f, 2f, 2f);
            o.transform.localPosition = new Vector3(-18f, 2.2f, -267.04f);
            dx += 2.2f;
        }*/
    }
}
