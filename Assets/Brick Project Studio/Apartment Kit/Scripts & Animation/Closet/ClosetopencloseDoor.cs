﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SojaExiles

{
	public class ClosetopencloseDoor : MonoBehaviour
	{
    	public SteamVR_Action_Boolean fireAction;
    	public Interactable interactable;
		public Animator Closetopenandclose;
		public bool open;

		void Start()
		{
			interactable = GetComponent<Interactable>();
			Closetopenandclose = GetComponent<Animator>();
			fireAction = SteamVR_Actions._default.InteractUI;
			open = false;
		}

		void Update() {
			if (interactable.hoveringHand != null) {
				SteamVR_Input_Sources source = interactable.hoveringHand.handType;

				if (fireAction[source].stateDown) {
					if (!open) {
						StartCoroutine(opening());
					} else if (open) {
						StartCoroutine(closing());
					}
				}
			}
		}

		IEnumerator opening()
		{
			Closetopenandclose.Play("ClosetOpening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			Closetopenandclose.Play("ClosetClosing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}