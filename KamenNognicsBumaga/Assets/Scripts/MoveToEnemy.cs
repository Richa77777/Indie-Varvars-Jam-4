using System.Collections;
using UnityEngine;

public class MoveToEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GameObject _rockPool;
    private GameObject _scissorsPool;
    private GameObject _paperPool;

    private Element _element;
    private GameObject _target = null;

    private void Start()
    {
        _element = GetComponent<Element>();

        _rockPool = GameObject.FindGameObjectWithTag("RockPool");
        _scissorsPool = GameObject.FindGameObjectWithTag("ScissorsPool");
        _paperPool = GameObject.FindGameObjectWithTag("PaperPool");
    }

    private void Update()
    {
        _target = FindNearestElement();
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (_target != null && FindNearestElement() != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }

        else if (_target == null && FindNearestElement() == null && FindNearestKillableElement() != null)
        {
            _target = FindNearestKillableElement();
            transform.position = Vector3.MoveTowards(transform.position, -_target.transform.position, _speed * Time.deltaTime);
        }
    }

    private GameObject FindNearestKillableElement()
    {
        GameObject element = null;

        switch (_element.CurrentElement)
        {
            case Element.Elements.Rock:
                element = FindPaper();
                break;

            case Element.Elements.Scissors:
                element = FindRock();
                break;

            case Element.Elements.Paper:
                element = FindScissors();
                break;
        }

        return element;
    }

    private GameObject FindNearestElement()
    {
        GameObject element = null;

        switch (_element.CurrentElement)
        {
            case Element.Elements.Rock:
                element = FindScissors();
                break;

            case Element.Elements.Scissors:
                element = FindPaper();
                break;

            case Element.Elements.Paper:
                element = FindRock();
                break;
        }

        return element;
    }

    private GameObject FindRock()
    {
        GameObject lastNearstObject = null;
        float lastNearstDistance = 0f;
        float currentDistance = 0f;

        for (int i = 0; i < _rockPool.transform.childCount; i++)
        {
            if (lastNearstObject == null)
            {
                lastNearstDistance = Vector3.Distance(transform.position, _rockPool.transform.GetChild(i).transform.position);
                lastNearstObject = _rockPool.transform.GetChild(i).gameObject;
            }

            else if (lastNearstObject != null)
            {
                currentDistance = Vector3.Distance(transform.position, _rockPool.transform.GetChild(i).transform.position);

                if (currentDistance < lastNearstDistance)
                {
                    lastNearstDistance = currentDistance;
                    lastNearstObject = _rockPool.transform.GetChild(i).gameObject;
                }
            }
        }

        return lastNearstObject;
    }

    private GameObject FindScissors()
    {
        GameObject lastNearstObject = null;
        float lastNearstDistance = 0f;
        float currentDistance = 0f;

        for (int i = 0; i < _scissorsPool.transform.childCount; i++)
        {
            if (lastNearstObject == null)
            {
                lastNearstDistance = Vector3.Distance(transform.position, _scissorsPool.transform.GetChild(i).transform.position);
                lastNearstObject = _scissorsPool.transform.GetChild(i).gameObject;
            }

            else if (lastNearstObject != null)
            {
                currentDistance = Vector3.Distance(transform.position, _scissorsPool.transform.GetChild(i).transform.position);

                if (currentDistance < lastNearstDistance)
                {
                    lastNearstDistance = currentDistance;
                    lastNearstObject = _scissorsPool.transform.GetChild(i).gameObject;
                }
            }
        }

        return lastNearstObject;
    }

    private GameObject FindPaper()
    {
        GameObject lastNearstObject = null;
        float lastNearstDistance = 0f;
        float currentDistance = 0f;

        for (int i = 0; i < _paperPool.transform.childCount; i++)
        {
            if (lastNearstObject == null)
            {
                lastNearstDistance = Vector3.Distance(transform.position, _paperPool.transform.GetChild(i).transform.position);
                lastNearstObject = _paperPool.transform.GetChild(i).gameObject;
            }

            else if (lastNearstObject != null)
            {
                currentDistance = Vector3.Distance(transform.position, _paperPool.transform.GetChild(i).transform.position);

                if (currentDistance < lastNearstDistance)
                {
                    lastNearstDistance = currentDistance;
                    lastNearstObject = _paperPool.transform.GetChild(i).gameObject;
                }
            }
        }

        return lastNearstObject;
    }
}
