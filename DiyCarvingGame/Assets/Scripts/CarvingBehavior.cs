using System.Collections;
using System.Collections.Generic;
using EzySlice;
using UnityEngine;

public class CarvingBehavior : MonoBehaviour
{
    Material material;
    GameObject cuttedObject;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Banana")
            Debug.Log("Collided");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cutting"))
        {
            material = other.GetComponent<MeshRenderer>().material;
            cuttedObject = other.gameObject;
            if (cuttedObject != null)
            {
                //SlicedHull cutted = Cut(cuttedObject, material);
                //GameObject upperHull = cutted.CreateUpperHull(cuttedObject, material);
                ////upperHull.AddComponent<BoxCollider>();
                //upperHull.AddComponent<MeshCollider>().convex = true;
                //upperHull.AddComponent<Rigidbody>();
                //upperHull.layer = LayerMask.NameToLayer("Cutting");
                //GameObject lowerHull = cutted.CreateLowerHull(upperHull, material);
                ////lowerHull.AddComponent<BoxCollider>();
                //lowerHull.AddComponent<MeshCollider>().convex = true;
                //lowerHull.AddComponent<Rigidbody>();
                //lowerHull.layer = LayerMask.NameToLayer("Cutting");
                // Destroy(cuttedObject,0.02f);


                SlicedHull cutted = Cut(cuttedObject, material);
                GameObject upperHull = cutted.CreateUpperHull(cuttedObject, material);
                upperHull.AddComponent<MeshCollider>();
                //upperHull.layer = LayerMask.NameToLayer("Cutting");
                ////upperHull.AddComponent<Rigidbody>();

                GameObject lowerHull = cutted.CreateLowerHull(cuttedObject, material);
                lowerHull.AddComponent<MeshCollider>();
                //lowerHull.layer = LayerMask.NameToLayer("Cutting");
                ////lowerHull.AddComponent<Rigidbody>();
                //// Destroy(cuttedObject, 0.02f);

                material= upperHull.GetComponent<MeshRenderer>().material;
                SlicedHull cutt2= Cut(upperHull, material);
                GameObject upper = cutted.CreateUpperHull(upperHull, material);
                upper.AddComponent<MeshCollider>().convex=true;
                upper.layer = LayerMask.NameToLayer("Cutting");
                upper.AddComponent<Rigidbody>();

                material = lowerHull.GetComponent<MeshRenderer>().material;
                SlicedHull cutt3 = Cut(lowerHull, material);
                GameObject lower = cutted.CreateLowerHull(lowerHull, material);
                lower.AddComponent<MeshCollider>().convex = true;
                lower.layer = LayerMask.NameToLayer("Cutting");
                lower.AddComponent<Rigidbody>();
                Destroy(upper, 0.02f);
                Destroy(lower, 0.02f);
                //Destroy(upperHull, 0.02f);
                //Destroy(lowerHull, 0.02f);
            }
        }
    }

        public SlicedHull Cut(GameObject obj, Material crossSectionMaterial = null)
        {
            return obj.Slice(transform.position, transform.up, crossSectionMaterial);
        }
    }
