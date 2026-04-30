using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour {
    public static void ReturnToPage(string name) {
        SceneManager.LoadScene(name);
    }
}
