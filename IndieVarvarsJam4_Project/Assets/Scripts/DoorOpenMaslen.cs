using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenMaslen : MonoBehaviour
{
    private Teleport _teleport;
    private ChangeShapeInCinemachine _comp;

    private void Start()
    {
        _teleport = GetComponent<Teleport>();
        _comp = GetComponent<ChangeShapeInCinemachine>();
    }

    public void TeleportS()
    {
        StartCoroutine(TeleportVrem());
    }
    
    private IEnumerator TeleportVrem()
    {
        yield return new WaitForSeconds(1.5f);
        _teleport.Teleportation();
        _comp.ChangeShape();
    }
}
