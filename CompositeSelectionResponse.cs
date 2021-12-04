using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    [SerializeField] private GameObject selectionResponseHolder;

    private List<ISelectionResponse> _selectionResponses;
    private int _currentIndex;
    private Transform _selection;

    private void Start()
    {
        _selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>().ToList();
        for (int i = 0; i < _selectionResponses.Count; i++)
            print("" + _selectionResponses[i]);
    }

    [ContextMenu("Next")]
    public void Next()
    {
        _selectionResponses[_currentIndex].OnDeselect(_selection);
        _currentIndex = (_currentIndex + 1) % _selectionResponses.Count;
        _selectionResponses[_currentIndex].OnSelect(_selection);
    }

    public void OnSelect(Transform selection)
    {
        if (HasSelection())
        {
            _selection = selection;
            _selectionResponses[_currentIndex].OnSelect(selection);
        }
    }
    public void OnDeselect(Transform selection)
    {
        _selection = null;
        if (HasSelection())
        {
            _selectionResponses[_currentIndex].OnDeselect(selection);
        }
    }

    public bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < _selectionResponses.Count;
    }
}
