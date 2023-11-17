using UnityEngine;
using Prickly.Gameplay;

public class Upgradable : MonoBehaviour
{
    //
    //write here upgradable fields
    //
    //[SerializeField] private Movement _movement;
    //[SerializeField] private StackController _stackController;
    //[SerializeField] private WaterGrower _grower;

    public IUpgradable GetUpgradable(UpgradeType upgradeType) => upgradeType switch
    {
      //  UpgradeType.SPEED => _movement,
//        UpgradeType.CAPACITY => _stackController,
  //      UpgradeType.RADIUS => _grower,
        _ => throw new System.ArgumentNullException()
    };
}
