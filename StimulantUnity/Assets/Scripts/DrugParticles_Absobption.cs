using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugParticles_Absobption : MonoBehaviour {

	// Use this for initialization
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

    

    void Start(){
        //pController = new PanelController();
        Initialized();
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

    private void OnValidate()
    {
        SphereCount = 20;
        SphereSize = .5f;
    }

    private void Reset()
    {
        Extents = new Vector3(10f, 0.2f, 10f);
        SphereCount = 20;
        SphereSize = .5f;
    }

    void Update(){
        if(PanelController.currentPanel == 5)
            UpdateSpheres();

            /*if(initialized){
                Initialized();
                SpawnSpheres();
            }*/

    }

    private void UpdateSpheres()
    {
        timer += Time.deltaTime;

        var spheres = GameObject.FindGameObjectsWithTag("Drug");

        foreach (var t in spheres)
        {
            if(timer < delay){
                float step = speed * Time.deltaTime;
                t.transform.Translate(-step, 0f, 0f);            
            }
        }
        
        if(timer >= 5f){
            foreach(var t in spheres)
                Destroy(t);
            
            timer = 0;
            SpawnSpheres();
        }
    }

    private void SpawnSpheres(){
        float dx = x;
        float dy = y;
        float dz = z;

        for (var i = 0; i < 4; i++)
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
            // get random position
            /*var x = Random.Range(-455f, -450f);
            var y = Random.Range(-4.6f, -6.6f); // sphere altitude relative to terrain below
            var z = Random.Range(-289.4f, -279.4f);*/

           
            o.transform.localScale = new Vector3(2f, 2f, 2f);
            o.transform.position = new Vector3(dx, dy, dz);
            dx += 2.2f;
        }
    }
}
