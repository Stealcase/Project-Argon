using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        
    }
	void OnParticleCollision (GameObject other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();
        print(gameObject.name +"Collided with Particles");
        Destroy(gameObject);

    }
}
