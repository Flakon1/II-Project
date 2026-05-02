using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsManager : MonoBehaviour {

    /* Attributes */

    [SerializeField] private Animator pageAnimator; // Animator for page transition
    [SerializeField] private float pageTransitionTime; // Page transition time

    /* Custom methods */

    public void LoadPage(string name) { // Loading a page using coroutine (for transitions)
        StartCoroutine(LoadPageCoroutine(name));
    }
    private IEnumerator LoadPageCoroutine(string name) { // Coroutine for loading a page with transition
        pageAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(pageTransitionTime);
        SceneManager.LoadScene(name);
    }
}
