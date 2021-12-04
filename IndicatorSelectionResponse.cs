using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public GameObject block;

    public void OnSelect(Transform selection)
    {
        if (block != null)
        {
            var height = selection.transform.localScale.y;
            block.transform.position = new Vector3(selection.transform.position.x, height * 2f, selection.transform.position.z);

        }
    }

    public void OnDeselect(Transform selection)
    {
        if (block != null)
        {
            block.transform.position = new Vector3(10,-10,10);

        }
    }
}
