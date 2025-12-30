using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    private SceneManagerScript sceneManagerScript;
    private void Start()
    {
        sceneManagerScript = FindFirstObjectByType<SceneManagerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        sceneManagerScript.ReloadScene();
        Debug.Log($"hit {other.gameObject.name}");
    }
}
