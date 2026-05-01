using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour {

    /* Custom Methods */

    public static void ReturnToPage(string name) { // Returning to a scene using it's name
        SceneManager.LoadScene(name);
    }
    public static void ToggleObject(GameObject obj) { // Toggle active modes of a object
        obj.SetActive(!obj.activeSelf);
    }
}
