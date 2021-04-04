using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ForceTest : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRig;
    [SerializeField] private Transform transform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _playerRig.AddForce(UtilsClass.GetVectorFromAngle(transform.rotation.z) * 100f);
        
    }

    
}
