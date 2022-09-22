using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Interactable interactable;
    public int scene;
   
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin()
    {
    }


    //-------------------------------------------------
    private void OnHandHoverEnd()
    {
    }


    //-------------------------------------------------
    private void HandHoverUpdate( Hand hand )
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabType != GrabTypes.None) {
            SceneManager.LoadScene(scene);
        }
    } 
}
