 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
 
 public class SwitchTrigger : MonoBehaviour {
    public SteamVR_Action_Boolean spawnAction;
    public int scene;
    public bool scuffed;
    public static Vector3 lastLocation = new Vector3(14f, 0f, 0f);

    // Use this for initialization
    void Start () {
        spawnAction = SteamVR_Actions._default.Menu;
        GameObject.Find("Player").transform.position = lastLocation;
    }
     
    // Update is called once per frame
    void Update () {
        if (spawnAction[SteamVR_Input_Sources.Any].stateDown) {
            if (scuffed) {
                lastLocation = GameObject.Find("Player").transform.position;
            }
            SceneManager.LoadScene(scene);
        }
    }
 }