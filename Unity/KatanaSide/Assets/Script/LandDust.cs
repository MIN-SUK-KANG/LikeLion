using UnityEngine;

public class LandDust : MonoBehaviour
{
    public float lifetime = 0.7f;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
