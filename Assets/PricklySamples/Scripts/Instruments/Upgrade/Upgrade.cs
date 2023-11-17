using System;
using TMPro;
using UnityEngine;
using Prickly.Core;

namespace Prickly
{
    namespace Gameplay
    {
        [AddComponentMenu("Prickly Games/Gameplay/Upgrade", 51)]
        public class Upgrade : InGameObject, IInitializable<IUpgradable, int, Payment>
        {
            public Action OnUpgrade;
            public UpgradeType Type => _upgradeConfiguration.Type;

            [SerializeField] private UpgradeConfiguration _upgradeConfiguration;
            [SerializeField] private ButtonBehavior _purchaseButton;
            [SerializeField] private TMP_Text _priceText;

            private IUpgradable _upgradable;
            [NaughtyAttributes.ShowNonSerializedField] private int _level;
            private int _price;
            private Payment _payment;

            public void Init(IUpgradable upgradable, int level, Payment payment)
            {
                _upgradable = upgradable;
                _level = level;
                _payment = payment;
                _purchaseButton.Init(Purchase);
                GetPrice();

                UpdateView();
                _upgradable.OnUpgrade(_upgradeConfiguration.GetStat(_level));
            }

            public int GetLevel() => _level;
            private int GetPrice() => _price = _upgradeConfiguration.GetTransaction(_level).Cost;

            protected void OnLevelUp()
            {
                _level++;
                GetPrice();
                UpdateView();
                ValidInteractive();
                _upgradable.OnUpgrade(_upgradeConfiguration.GetStat(_level));
            }

            private void UpdateView()
            {
                string price = _level >= _upgradeConfiguration.MaxLevel ? "MAX" : $"{_price}";

                SetText($"{_level}", price);
            }

            private void SetText(string level, string price)
            {
                //_levelText.text = $"{level} / {_configuration.MaxLevel}";
                _priceText.text = price;
            }

            public void ValidInteractive()
            {
                _purchaseButton.SetInteractive(IsInteractive());
            }

            private bool IsInteractive() => _payment.CanPurchase(_upgradeConfiguration.GetTransaction(_level)) == true
                && _level < _upgradeConfiguration.MaxLevel;

            private void Purchase()
            {
                if (IsInteractive() == false)
                {
                    return;
                }

                _payment.OnPurchase(_upgradeConfiguration.GetTransaction(_level), OnUpgrade);
                OnLevelUp();
            }
        }
    }
}
