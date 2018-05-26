using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    { //if more than one music player in scene, destroy ourselves
        //else 
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        print("number of music players in this scene" + numMusicPlayers);
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
 
}
