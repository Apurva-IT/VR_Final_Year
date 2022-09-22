using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SojaExiles

{

	public class Drawer_Pull_X : MonoBehaviour
	{
    	public SteamVR_Action_Boolean fireAction;
		public Animator pull_01;
		public bool open;
    	public Interactable interactable;

		void Start()
		{
			interactable = GetComponent<Interactable>();
			pull_01 = GetComponent<Animator>();
			fireAction = SteamVR_Actions._default.InteractUI;
			open = false;
		}

		void Update() {
			if (interactable.hoveringHand != null) {
				SteamVR_Input_Sources source = interactable.hoveringHand.handType;

				if (fireAction[source].stateDown) {
					if (open == false) {
						StartCoroutine(opening());
					} else if (open == true) {
						StartCoroutine(closing());
					}
				}
			}
		}

		IEnumerator opening()
		{
			pull_01.Play("openpull_01");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			pull_01.Play("closepush_01");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}