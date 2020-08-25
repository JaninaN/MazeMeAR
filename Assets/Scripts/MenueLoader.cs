using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueLoader : MonoBehaviour {
    
    private int m_buildIndex;
    public GameObject canvas;
    // Use this for initialization
    void Start()
    {
        m_buildIndex = 0;
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void goToMenue()
    {
        GameObject newCanvas = Instantiate(canvas, transform.position, transform.rotation, transform.parent);
        //canvas.transform.parent = this.transform.parent;
        DontDestroyOnLoad(newCanvas);
        Destroy(transform.gameObject);
        SceneManager.LoadScene(m_buildIndex);
    }
}
