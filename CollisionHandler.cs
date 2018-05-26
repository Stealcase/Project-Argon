using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script that loads scenes

public class CollisionHandler : MonoBehaviour {
    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("ParticleEffect")][SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider other)
    {
        print("Player Triggered Something");
        StartDeathSequence();
        Invoke("ReloadScene", levelLoadDelay);
    }
    private void StartDeathSequence()
    {
        gameObject.SendMessage("KillMovement");
        deathFX.SetActive(true);
    }
    private void ReloadScene()  //string referenced
    {
        SceneManager.LoadScene(1);
    }
}
