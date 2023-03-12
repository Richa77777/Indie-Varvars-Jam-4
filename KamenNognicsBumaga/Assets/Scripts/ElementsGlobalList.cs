using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsGlobalList : MonoBehaviour
{
    [SerializeField] private List<ElementObj> _listOfElements = new List<ElementObj>();

    public List<ElementObj> ListOfElementsGet => _listOfElements;
}

[System.Serializable]
public class ElementObj
{
    [SerializeField] private Element.Elements _elementObj;
    [SerializeField] private Sprite _sprite;

    public Element.Elements ElementObjGet => _elementObj;
    public Sprite SpriteGet => _sprite;
}