using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugParticles : MonoBehaviour {

	public GameObject[] drugParticles;

    float timer = 0f;
    float speed = 1f;
    float delay;

	// for tracking properties change
    private Vector3 _extents;
    private int _sphereCount;
    private float _sphereSize;

    /// <summary>
    ///     How far to place spheres randomly.
    /// </summary>
    public Vector3 Extents;

    /// <summary>
    ///     How many spheres wanted.
    /// </summary>
    public int SphereCount;

    public float SphereSize;

    void Start(){
        SpawnSpheres();
        delay = 10f;
    }

    private void OnValidate()
    {
        // prevent wrong values to be entered
        Extents = new Vector3(Mathf.Max(0.0f, Extents.x), Mathf.Max(0.0f, Extents.y), Mathf.Max(0.0f, Extents.z));
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
    
        UpdateSpheres();              
        //transform.Translate(1f, 0f, 0f);

    }

    private void UpdateSpheres()
    {
        timer += Time.deltaTime;

        //if (Extents == _extents && SphereCount == _sphereCount && Mathf.Approximately(SphereSize, _sphereSize))
            //return;

        // cleanup
        var spheres = GameObject.FindGameObjectsWithTag("Drug");

        foreach (var t in spheres)
        {
            if(timer < delay){
                float step = speed * Time.deltaTime;
                //t.transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                t.transform.Translate(step, 0f, 0f);
                Debug.Log(t + " is moving");
            
            }
        }



        //var withTag = GameObject.FindWithTag("Plane");
        
        

        _extents = Extents;
        _sphereCount = SphereCount;
        _sphereSize = SphereSize;
    }

    private void SpawnSpheres(){

        for (var i = 0; i < 20; i++)
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
            var x = Random.Range(-5f, 5f);
            var y = Random.Range(-.3f, 5f); // sphere altitude relative to terrain below
            var z = Random.Range(-.41f, 5f);

           
            o.transform.localScale = new Vector3(.5f, .5f, .5f);
            o.transform.position = new Vector3(x, y, z);
        }
    }
}
