using UnityEngine;
using Prickly.Gameplay;

namespace Prickly
{
    namespace Core
    {
        public class UpgradeController : InGameObject, IInitializable<UpgradeZone>
        {
            [SerializeField] private Upgradable _upgradable;
            [SerializeField] private Feedback _feedback;
            [SerializeField] private Upgrade[] _upgrades;
            [SerializeField] private int[] _levels;
            [SerializeField] private ValueCounter _valueCounter;

            public int[] Levels => _levels;
            private Payment _payment;

            public void Init(UpgradeZone upgradeZone)
            {
                upgradeZone.OnStartInteract += ValidInteractive;
                _payment = new Payment();

                Load();

                for (int i = 0; i < _levels.Length; i++)
                {
                    _upgrades[i].Init(_upgradable.GetUpgradable(_upgrades[i].Type), _levels[i], _payment);
                    _upgrades[i].OnUpgrade = OnCorrectPurchase;
                }
            }

            //public bool CanPurchase(Transaction transaction) => _valueCounter.GetValue(transaction.Money) >= transaction.Cost;
            public void OnCorrectPurchase()
            {
                ValidInteractive();
                _feedback.SmoothScale();
                Save();
            }

            private void ValidInteractive()
            {
                foreach (Upgrade upgrade in _upgrades)
                {
                    upgrade.ValidInteractive();
                }

                Save();
            }

            private void Load()
            {
                DataProvider.LoadByKey(Data.UPGRADE, out _levels, new int[_upgrades.Length]);
            }

            public void Save()
            {
                int[] level = new int[_upgrades.Length];

                for (int i = 0; i < level.Length; i++)
                {
                    level[i] = _upgrades[i].GetLevel();
                }

                DataProvider.SaveByKey(Data.UPGRADE, in level);
                _valueCounter.Save();
            }
        }
    }
}

public enum UpgradeType
{
    SPEED,
    CAPACITY,
    RADIUS
}
