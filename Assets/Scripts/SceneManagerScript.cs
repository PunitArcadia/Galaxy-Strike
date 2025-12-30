using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] private int reloadTime = 2;

    public void ReloadScene()
    {
        StartCoroutine(ReloadAfterSec());
    }

    IEnumerator ReloadAfterSec()
    {
        yield return new WaitForSeconds(reloadTime);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
