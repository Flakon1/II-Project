using System;
using System.Collections;
using UnityEngine;

public class ButtonsManager : MonoBehaviour {

    /* Attributes */

    private static TransitionsManager transitionsManager; // Attribute for transitions manager (reference to transitions manager)
    /* Main Methods */

    private void Awake() {
        transitionsManager = GameObject.Find("TransitionsManager").GetComponent<TransitionsManager>(); // Getting the transitions manager reference
    }

    /* Custom Methods */

    public static void ReturnToPage(string name) { // Returning to a scene using it's name
        transitionsManager.LoadPage(name);
    }

    public static void ToggleObject(GameObject obj) { // Toggle active modes of a object
        obj.SetActive(!obj.activeSelf);
    }
}
