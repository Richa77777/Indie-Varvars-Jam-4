using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckList : MonoBehaviour
{
    [SerializeField] private GameObject _listok;

    public void ListCheck()
    {
        StartCoroutine(ListCheckCor());
    }

    private IEnumerator ListCheckCor()
    {
        _listok.SetActive(true);
        yield return new WaitForSeconds(3f);
        _listok.SetActive(false);
    }
}
