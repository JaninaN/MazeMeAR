using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private int l1_buildIndex, l2_buildIndex, l3_buildIndex, l4_buildIndex;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        l1_buildIndex = 1;
        l2_buildIndex = 2;
        l3_buildIndex = 3;
        l4_buildIndex = 4;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void PlayLevelOne()
    {
        GameObject newCanvas = Instantiate(canvas, transform.position, transform.rotation, transform.parent);
        
        DontDestroyOnLoad(newCanvas);
        Destroy(transform.gameObject);
        SceneManager.LoadScene(l1_buildIndex);
    }
}
