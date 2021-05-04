using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMove : SupervisedObject
{
    [SerializeField] IKeyPad key;
    [SerializeField] KeyPad keypad;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigid;

    public float speed = 1;
    private Vector3 moveVector;

    private void Start()
    {
        key = keypad;
        keypad.InputVector().Subscribe(x => moveVector = x);
    }

    public override void SupervisedUpdate(SuperviserData d)
    {
        if (d.Active == true)
        {
            var factor = (5 * moveVector.magnitude - rigid.velocity.magnitude) / Time.fixedDeltaTime;

            rigid.AddForce(moveVector * factor);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(moveVector),
                20.0f * Time.deltaTime);
        }
    }
}
