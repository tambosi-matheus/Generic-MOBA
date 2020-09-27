using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static Util Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    public Vector3 Click(int distance, LayerMask mask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            GameObject obj = Pooler.Singleton.InstantiateFromPool("ClickFeedback");
            Pooler.Singleton.DestroyToPoolWithTimer("ClickFeedback", obj, 1f);
            obj.transform.position = hit.point;
            return hit.point;
        }

        return Vector3.zero;
    }

    public Vector3 DashMovimentation(Vector3 position, float distance)
    {
        Vector3 newPosition;
        newPosition = position + transform.forward * distance;
        return newPosition;
    }
    public void Instantiate(GameObject obj)
    {
        Instantiate(obj);
    }

    public void Instantiate(GameObject obj, Transform transform, Quaternion rotation)
    {
        Instantiate(obj, transform, rotation);
    }
}
