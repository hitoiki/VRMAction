using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class KeyPad : SupervisedObject, IKeyPad
{
    ReactiveProperty<bool> leftClick = new ReactiveProperty<bool>();
    ReactiveProperty<bool> rightClick = new ReactiveProperty<bool>();
    ReactiveProperty<bool> menuKey = new ReactiveProperty<bool>();
    ReactiveProperty<bool> shotKey = new ReactiveProperty<bool>();
    ReactiveProperty<bool> phaseChangeKey = new ReactiveProperty<bool>();
    ReactiveProperty<Vector3> inputVector = new ReactiveProperty<Vector3>();
    ReactiveProperty<Vector2> mouseCursur = new ReactiveProperty<Vector2>();
    public override void SupervisedUpdate(SuperviserData d)
    {
        if (d.Active == true)
        {
            KeyPadCheck();
        }
    }
    private void KeyPadCheck()
    {
        leftClick.Value = Input.GetMouseButton(0);
        rightClick.Value = Input.GetMouseButton(1);
        shotKey.Value = Input.GetMouseButton(0);
        menuKey.Value = Input.GetKey(KeyCode.Escape);
        phaseChangeKey.Value = Input.GetKey(KeyCode.Space);
        Vector3 recept = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) recept += Vector3.forward;

        if (Input.GetKey(KeyCode.S)) recept += Vector3.back;

        if (Input.GetKey(KeyCode.D)) recept += Vector3.right;

        if (Input.GetKey(KeyCode.A)) recept += Vector3.left;

        inputVector.Value = recept.normalized;
        mouseCursur.Value = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public ReactiveProperty<bool> LeftClick()
    {
        return leftClick;
    }

    public ReactiveProperty<bool> RightClick()
    {
        return rightClick;
    }

    public ReactiveProperty<bool> ShotKey()
    {
        return shotKey;
    }

    public ReactiveProperty<bool> MenuKey()
    {
        return menuKey;
    }

    public ReactiveProperty<bool> PhaseChangeKey()
    {
        return phaseChangeKey;
    }

    public ReactiveProperty<Vector3> InputVector()
    {
        return inputVector;
    }

    public ReactiveProperty<Vector2> MouseCursurPosition()
    {
        return mouseCursur;
    }


}
