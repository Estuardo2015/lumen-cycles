using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
public class SelectOnInput : MonoBehaviour
{
	private bool buttonSelected;
	public GameObject selectedObject;
	public EventSystem eventSystem;
	
	//Use to Initialization
	void Start()
	{
	}
	
	//Update is called once per frame
	void Update ()
	{
		if (Input.GetAxisRaw ("Vertical") != 0  && buttonSelected == false)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		}
	}
	private void OnDisable()
	{
		buttonSelected = false;
	}

}
