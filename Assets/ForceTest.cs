using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ForceTest : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRig;
    [SerializeField] private float _angle;
    [SerializeField] private float _force;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _playerRig.AddForce(UtilsClass.GetVectorFromAngle(_angle) * _force);
    }
}
