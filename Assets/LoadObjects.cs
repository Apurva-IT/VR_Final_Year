 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using Valve.VR;
using Valve.VR.InteractionSystem;
 
 public class LoadObjects : MonoBehaviour {
    public SteamVR_Action_Boolean spawnAction;
    public GameObject[] prefabPoolInitial;
    public GameObject[] prefabPool;
    public int[] indexPool;
    HashSet<int> indexSet = new HashSet<int>();
    public int curIndex = 0;
    public GameObject player = null;

    // Use this for initialization
    void Start () {
        prefabCreation(5);
        spawnAction = SteamVR_Actions._default.GrabGrip;
        if (player == null) {
            player = GameObject.Find("VRCamera");
        }
    }
     
    // Update is called once per frame
    void Update () {
        if (spawnAction[SteamVR_Input_Sources.Any].stateDown) {
            spaceInstantiate();
        }
    }

    public void prefabCreation(int count)
    {
        prefabPoolInitial = Resources.LoadAll<GameObject>("Prefabs");
        prefabPool = new GameObject[prefabPoolInitial.Length-3];

        // for (int i = 0; i < prefabPoolInitial.Length; i++) {
        //     print(prefabPoolInitial[i]);
        // }

        for(int i = 1; i < prefabPoolInitial.Length-2; i++)
        {
            prefabPool[i-1] = prefabPoolInitial[i];
        }
        hashFill(count);
        curIndex = 0;
    }

    public void hashFill(int objCount)
    {
        // RANDOM
        // while(indexSet.Count < objCount) {
        //     indexSet.Add(Random.Range(0, prefabPool.Length));
        // }
        
        // ALPHABETICAL
        // int index = 0;
        // while(indexSet.Count < objCount) {
        //     indexSet.Add(index);
        //     print(prefabPoolInitial[index]);
        //     index++;
        // }

        // indexSet.CopyTo(indexPool);
        // indexPool = new int[indexSet.Count];

        indexPool = new int[] {4, 9, 2, 11, 3};
    }
    
    public void spaceInstantiate() // put on space click
    {
        if (curIndex < indexPool.Length) {
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
            Instantiate(prefabPool[indexPool[curIndex]], playerPos + player.transform.forward, player.transform.rotation); //relative to player
            curIndex += 1;
        }
    }
 }