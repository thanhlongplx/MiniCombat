using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform character1;
    public Transform character2;

    void Update()
    {
        if (character1 != null && character2 != null)
        {
            Vector3 midpoint = (character1.position + character2.position) / 2;
            transform.position = midpoint;
        }
    }
}