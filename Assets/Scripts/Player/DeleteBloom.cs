using UnityEngine;

public class DeleteBloom : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 0.15f);
    }
}
