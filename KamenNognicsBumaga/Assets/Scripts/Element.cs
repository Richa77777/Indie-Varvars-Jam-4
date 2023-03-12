using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public enum Elements
    {
        Rock,
        Scissors,
        Paper
    }

    [SerializeField] private Elements _currentElement;

    private ElementsGlobalList _elementsGlobalList;
    private SpriteRenderer _spriteRender;

    private GameObject _rockPool;
    private GameObject _scissorsPool;
    private GameObject _paperPool;

    public Elements CurrentElement
    {
        get => _currentElement;
        set
        {
            _currentElement = value;
            SetCurrentElementSprite();
        }
    }

    private void Awake()
    {
        _rockPool = GameObject.FindGameObjectWithTag("RockPool");
        _scissorsPool = GameObject.FindGameObjectWithTag("ScissorsPool");
        _paperPool = GameObject.FindGameObjectWithTag("PaperPool");

        _spriteRender = GetComponent<SpriteRenderer>();
        _elementsGlobalList = FindObjectOfType<ElementsGlobalList>(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Element collisionElement = collision.gameObject.GetComponent<Element>();

            if (_currentElement == Elements.Rock)
            {
                if (collisionElement.CurrentElement == Elements.Paper)
                {
                    SetCurrentElement(Elements.Paper);
                }
            }

            else if (_currentElement == Elements.Scissors)
            {
                if (collisionElement.CurrentElement == Elements.Rock)
                {
                    SetCurrentElement(Elements.Rock);
                }
            }

            else if (_currentElement == Elements.Paper)
            {
                if (collisionElement.CurrentElement == Elements.Scissors)
                {
                    SetCurrentElement(Elements.Scissors);
                }
            }
        }
    }

    public void SetCurrentElement(string stringElement)
    {
        Enum.TryParse(stringElement, out Elements element);
        CurrentElement = element;

        SetParent();
    }

    public void SetCurrentElement(Elements element)
    {
        CurrentElement = element;

        SetParent();
    }

    private void SetCurrentElementSprite()
    {
        switch (_currentElement)
        {
            case Elements.Rock:

                for (int i = 0; i < _elementsGlobalList.ListOfElementsGet.Count; i++)
                {
                    if (_elementsGlobalList.ListOfElementsGet[i].ElementObjGet == Elements.Rock)
                    {
                        _spriteRender.sprite = _elementsGlobalList.ListOfElementsGet[i].SpriteGet;
                    }
                }

                break;

            case Elements.Scissors:

                for (int i = 0; i < _elementsGlobalList.ListOfElementsGet.Count; i++)
                {
                    if (_elementsGlobalList.ListOfElementsGet[i].ElementObjGet == Elements.Scissors)
                    {
                        _spriteRender.sprite = _elementsGlobalList.ListOfElementsGet[i].SpriteGet;
                    }
                }

                break;

            case Elements.Paper:

                for (int i = 0; i < _elementsGlobalList.ListOfElementsGet.Count; i++)
                {
                    if (_elementsGlobalList.ListOfElementsGet[i].ElementObjGet == Elements.Paper)
                    {
                        _spriteRender.sprite = _elementsGlobalList.ListOfElementsGet[i].SpriteGet;
                    }
                }

                break;
        }
    }

    private void SetParent()
    {
        switch (_currentElement)
        {
            case Elements.Rock:
                gameObject.transform.SetParent(_rockPool.transform);
                break;

            case Elements.Scissors:
                gameObject.transform.SetParent(_scissorsPool.transform);
                break;

            case Elements.Paper:
                gameObject.transform.SetParent(_paperPool.transform);
                break;
        }
    }
}