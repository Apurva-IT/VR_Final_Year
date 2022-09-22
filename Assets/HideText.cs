using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HideText : MonoBehaviour
{   
    public static bool hide;
    public GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        print("value of hide is " + hide);
        hide = false;
        print("working start");
        if (player == null) {
            player = GameObject.Find("Player");
            print("working player");
            player.transform.position = new Vector3(14f, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hide == true) {
            print("received hide true");
            StartCoroutine(deleting());
        }
        
    }

    IEnumerator deleting()
    {
        print("deleting text");
        TextMeshPro[] yourLabels = FindObjectsOfType<TextMeshPro>();
        foreach (TextMeshPro someLabel in yourLabels)
        {
            Destroy(someLabel);
        }
        hide = false;

        yield return new WaitForSeconds(.5f);
    }
}
