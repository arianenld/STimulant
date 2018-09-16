using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugParticles : MonoBehaviour {

	public GameObject[] drugParticles;

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

    private void Update()
    {
        UpdateSpheres();
    }

    private void UpdateSpheres()
    {
        if (Extents == _extents && SphereCount == _sphereCount && Mathf.Approximately(SphereSize, _sphereSize))
            return;

        // cleanup
        var spheres = GameObject.FindGameObjectsWithTag("Drug");
        foreach (var t in spheres)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(t);
            }
            else
            {
                Destroy(t);
            }
        }

        //var withTag = GameObject.FindWithTag("Plane");
        
        for (var i = 0; i < SphereCount; i++)
        {
        	 var planePos = GameObject.Find("Plane").Extents
            var o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.tag = "Drug";
            o.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);

            var color = new Color(200, 0, 0, 255);
            MeshRenderer gameObjectRenderer = o.GetComponent<MeshRenderer>();
 
			Material newMaterial = new Material(Shader.Find("Standard"));
			 
			newMaterial.color = color;
			gameObjectRenderer.material = newMaterial;
            // get random position
            var x = Random.Range(-planePos.x, planePos.x);
            var y = .3f; // sphere altitude relative to terrain below
            var z = Random.Range(-planePos.z, planePos.y);

            // now send a ray down terrain to adjust Y according terrain below
           /*var height = .2f; // should be higher than highest terrain altitude
            var origin = new Vector3(x, height, z);
            var ray = new Ray(origin, Vector3.down);
            RaycastHit hit;
            var maxDistance = 20000.0f;
            var nameToLayer = LayerMask.NameToLayer("Plane");
            var layerMask = 1 << nameToLayer;
            if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
            {
                var distance = hit.distance;
                y = height - distance + y; // adjust
            }
            else
            {
                Debug.LogWarning("Terrain not hit, using default height !");
            }*/

            // place !
            o.transform.localScale = new Vector3(.5f, .5f, .5f);
            o.transform.position = new Vector3(x, y, z);
        }

        _extents = Extents;
        _sphereCount = SphereCount;
        _sphereSize = SphereSize;
    }
}
