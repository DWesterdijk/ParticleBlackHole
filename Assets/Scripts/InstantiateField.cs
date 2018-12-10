using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateField : MonoBehaviour {

    [SerializeField]
    private GameObject _fieldBlock;

    [SerializeField]
    private Vector3 _objPos;

    [SerializeField]
    private Transform _parentObj;

    private void Start()
    {
        //Invoke("InstantiateObjects", 1f);
        InstantiateObjects();
    }

    private void InstantiateObjects()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _objPos = new Vector3(_objPos.x = i, _objPos.y, _objPos.z = j);
                Instantiate(_fieldBlock, _objPos, Quaternion.identity, _parentObj);
                Debug.Log("Pos " + _objPos);
            }
        }
    }
}
