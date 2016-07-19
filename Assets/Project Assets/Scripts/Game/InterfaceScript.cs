using UnityEngine;
using System.Collections;

public class InterfaceScript : MonoBehaviour {

    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject selectPanel;
    public GameObject game;
    void Awake()
    {
        // Check if we're starting in the correct unity scene.
        //if (GameObject.Find("StartUp") == null)
        //{
        //    Debug.LogWarning("[InterfaceScript] Deactivating InterfaceScript.");
        //    gameObject.SetActive(false);
        //    return;
        //}

        Scripts.interfaceScript = this;

        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }

        startPanel.SetActive(true);
        //gamePanel.SetActive(true);

        //selectPanel.SetActive(true);

        gameObject.transform.FindChild("FPS").gameObject.SetActive(true);

    }
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {

    }
}
