using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SojaExiles

{
	public class OvenFlip: MonoBehaviour
	{
    	public SteamVR_Action_Boolean fireAction;
		public Animator openandcloseoven;
		public bool open;
    	public Interactable interactable;

		void Start()
		{
			interactable = GetComponent<Interactable>();
			openandcloseoven = GetComponent<Animator>();
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
			openandcloseoven.Play("OpenOven");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			openandcloseoven.Play("ClosingOven");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}