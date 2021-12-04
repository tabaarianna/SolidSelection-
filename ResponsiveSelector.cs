using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    [SerializeField] private List<Transform> selectables;
    [SerializeField] private float threshold= 0.97f;

    private Transform _selection;

    public void Check(Ray ray)
    {
        _selection = null;

        var closest = 0f;

        for (int i = 0; i < selectables.Count; i++)
        {
            var vector1 = ray.direction;
            var vector2 = selectables[i].transform.position - ray.origin;

            var lookpercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            //selectables[i].LookPercentage = lookpercentage;

            if(lookpercentage > threshold && lookpercentage > closest)
            {
                closest = lookpercentage;
                _selection = selectables[i].transform;
            }
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }

}
