using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _elementPrefab;

    [SerializeField] private GameObject _rockPool;
    [SerializeField] private GameObject _scissorsPool;
    [SerializeField] private GameObject _paperPool;

    [SerializeField] private int _countOfPrefabs = 0;

    private Collider2D _rockPoolCollider;
    private Collider2D _scissorsPoolCollider;
    private Collider2D _paperPoolCollider;

    private void Start()
    {
        _rockPoolCollider = _rockPool.GetComponent<Collider2D>();
        _scissorsPoolCollider = _scissorsPool.GetComponent<Collider2D>();
        _paperPoolCollider = _paperPool.GetComponent<Collider2D>();

        Bounds rockPoolbounds = _rockPoolCollider.bounds;
        Bounds scissorsPoolbounds = _scissorsPoolCollider.bounds;
        Bounds paperPoolbounds = _paperPoolCollider.bounds;

        float offsetX;
        float offsetY;

        GameObject rock;
        GameObject scissors;
        GameObject paper;

        for (int i = 0; i < _countOfPrefabs; i++)
        {
            rock = Instantiate(_elementPrefab, _rockPool.transform, true);
            scissors = Instantiate(_elementPrefab, _scissorsPool.transform, true);
            paper = Instantiate(_elementPrefab, _paperPool.transform,true);

            rock.layer = 7;
            scissors.layer = 8;
            paper.layer = 9;

            scissors.GetComponent<Element>().SetCurrentElement(Element.Elements.Scissors);
            paper.GetComponent<Element>().SetCurrentElement(Element.Elements.Paper);

            offsetX = Random.Range(-rockPoolbounds.extents.x, rockPoolbounds.extents.x);
            offsetY = Random.Range(-rockPoolbounds.extents.y, rockPoolbounds.extents.y);

            rock.transform.position = rockPoolbounds.center + new Vector3(offsetX, offsetY, 0);


            offsetX = Random.Range(-scissorsPoolbounds.extents.x, scissorsPoolbounds.extents.x);
            offsetY = Random.Range(-scissorsPoolbounds.extents.y, scissorsPoolbounds.extents.y);

            scissors.transform.position = scissorsPoolbounds.center + new Vector3(offsetX, offsetY, 0);


            offsetX = Random.Range(-paperPoolbounds.extents.x, paperPoolbounds.extents.x);
            offsetY = Random.Range(-paperPoolbounds.extents.y, paperPoolbounds.extents.y);

            paper.transform.position = paperPoolbounds.center + new Vector3(offsetX, offsetY, 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
