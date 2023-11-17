using System;
using UnityEngine;
using Prickly.Utils;

public class Environment : MonoBehaviour
{
    [SerializeField] private LevelConfig[] _levelConfigs;

    private Level _currentLevel;

    [Serializable]
    public struct LevelConfig
    {
        [SerializeField] private Level _level;

        public Level Level => _level;
    }

    [Header("Debug")]
    [SerializeField] private bool _isDebug;
    [SerializeField] private int _levelDebug;

    public Level Get(int index)
    {
        int levelIndex = index;

#if UNITY_EDITOR
        if (_isDebug == true)
        {
            levelIndex = _levelDebug;
        }
#endif

        _currentLevel = Utils.GetElementOfArray(levelIndex, _levelConfigs).Level;
        _currentLevel.Init();
        UnlockSelectedLevel();
        return _currentLevel;
    }

    private void UnlockSelectedLevel()
    {
        foreach (LevelConfig levelConfig in _levelConfigs)
        {
            levelConfig.Level.Lock();
        }

        _currentLevel.Unlock();
    }
}