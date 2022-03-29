using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour
{
    public string menu;
    public string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level();
    }

    public void Level()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(menu);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(level);
        }
    }
}
