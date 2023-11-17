using UnityEngine;

[CreateAssetMenu(fileName = nameof(UpgradeConfiguration), menuName = "Upgrade/Configuration", order = 51)]
public class UpgradeConfiguration : ScriptableObject
{
    [System.Serializable]
    private struct Configuration
    {
        [SerializeField] private float _stat;
        [SerializeField] private Transaction _transaction;

        public float Stat => _stat;
        public Transaction Transaction => _transaction;
    }

    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] private Configuration[] _configurations;

    public float GetStat(int level) => _configurations[level].Stat;
    public Transaction GetTransaction(int level) => _configurations[level].Transaction;
    public int MaxLevel => _configurations.Length;
    public UpgradeType Type => _upgradeType;
}