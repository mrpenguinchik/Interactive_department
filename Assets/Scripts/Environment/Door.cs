using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Door : Interactable<IPlayer>
{
   [SerializeField] Transform door;
    protected override void OnInteract(IPlayer obj)
    {
       door.DORotate(new Vector3(-90, 0, -80), 2);
    }


}
