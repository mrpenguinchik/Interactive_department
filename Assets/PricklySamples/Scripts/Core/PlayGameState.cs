using NaughtyAttributes;
using Prickly;
using Prickly.Core;
using Prickly.Gameplay;
using UnityEngine;

public class PlayGameState : InGameObject, IInitializable<GameConfig>
{
    public static PlayGameState Instance;
    [Header("Core")]
    [SerializeField] private Environment _environment;
    [SerializeField] private Viewport _viewport;
    [SerializeField] private ValueCounter _valueCounter;
    [SerializeField] private UpgradeController _upgradeController;

    [HorizontalLine, Header("InGame")]
    [SerializeField] protected MainCamera _mainCamera;
    [SerializeField] private Player _player;

    private IController _controller;
    private int _levelIndex;

    private void Awake()
    {
        Instance = this;
    }

   virtual public void Init(GameConfig config)
    {
        //Level level = SetupEnvironment();
        _viewport?.Init();
        //_upgradeController?.Init(level.UpgradeZone);

      //  _controller = SetupPlayer(config);

        LevelStart();
    }

    private  Level SetupEnvironment()
    {
        Level level = _environment.Get(_levelIndex);

        return level;
    }

   virtual protected IController SetupPlayer(GameConfig  config)
    {
        IController controller = Instantiate(config.Controller);
        _mainCamera.Init(_player);
        _player.Init(controller, config.PlayerStat);

        return controller;
    }

    private void LevelStart()
    {
        print("--GAME STARTED--");
    }

    [Button]
    private void LevelComplete()
    {
        print("--LEVEL COMPLETE--");
    }

    [Button]
    private void LevelLose()
    {
        print("--LEVEL LOSE--");
    }

  

    /*print("--LEVEL STARTED--");
        Analytics.TrackEvent(Analytics.EventType.startLevel, _levelIndex, ValueCounter.Instance.GetValue(DataProvider.Keys.MONEY));

        _player.Init(_mainCamera);
        Level level = _enviroment.GetLevel(index);
        _instrumentController.Init(level.LevelConfig);
        level.UpgradeZone.OnStartInteract += () =>
        {
            _viewport.GetUpgradeScreen().SetActiveSmooth(true);
        };
        level.UpgradeZone.OnEndInteract += () =>
        {
            _viewport.GetUpgradeScreen().SetActive(false);
        };

        foreach (ThingsData thingsData in _thingsDatas)
        {
            thingsData.AllCount = level.GetItemsCountOfType(thingsData.ItemConvert.GarbageType);
        } 

        _tutorialController.Init(_thingsDatas, level, level.LevelConfig.Index);
        _upgradeController.Init(_player, level.UpgradeZone);
        _viewport.GetUpgradeScreen().Init(level.LevelConfig.MainInstrument);
        StartCoroutine(WaitLevelComplete(level));

        OnLevelStart?.Invoke();*/

    //[SerializeField] private PlayerActor _player;
    //[SerializeField] private Enviroment _enviroment;
    //[SerializeField] private Viewport _viewport;
    //[SerializeField] private Inventory _inventory;

    //[SerializeField] private int _level;
    //private GameConfig _config;
    /*public int CollectedGemCount {
        get
        {
            return _collectedGemCount;
        }
        set
        {
            if (value < 0) value = 0;

            _collectedGemCount = value;
            _viewport.GetInGame().ChangeGemCounter(_collectedGemCount, _levelContent.GemCountNeeded);
        }
    }
    public int _collectedGemCount;
    public int CollectedSafeCount;
    public int EnemyKilled;
    private ValueCounter _valueCounter;
    [SerializeField] private GridGenerator.LevelContent _levelContent;

    private bool _levelComplite;

    [SerializeField] private PowerUpgrade _powerUpgrade;
    [SerializeField] private HealthUpgrade _healthUpgrade;
    [SerializeField] private SpeedUpgrade _speedUpgrade;

    [SerializeField] private bool isTutorial;

    public void Init(GameConfig gameConfig)
    {
        _valueCounter = ValueCounter.Instance;
        _valueCounter.Init();

        DataProvider.LoadByKey(DataProvider.Keys._firstGame, out isTutorial, true);
        DataProvider.LoadByKey(DataProvider.Keys._pickedLevel, out _level, 0);

        _config = gameConfig;
        _viewport.Init(_player, _level);
        _inventory.Init(_player);

        _player.SetBoosters(_inventory, _powerUpgrade, _healthUpgrade, _speedUpgrade);
        _player.Init(_config.PlayerStats);

        _enviroment.Init(_level, _player, isTutorial);

        _levelContent = _enviroment.GetLevelContent();
        CollectedGemCount = 0;

        SetLevelRule(true);
    }

    public void AddReward(Item item)
    {
        Reward reward = _viewport.GetReward();
        reward.OnOpen(delegate
        {
            reward.OnClose(null);
            _controller.IsEnabled = true;
            _inventory.AddItem(item);
            CollectedSafeCount++;
	    });
        reward.SetItem(item);

        _controller.IsEnabled = false;
    }

    public void OnEnemyDie()
    {
        EnemyKilled++;
    }

    private IEnumerator WaitForWin(System.Func<bool> func)
    {
        yield return new WaitUntil(func);
        yield return new WaitForSeconds(0.5f);

        LevelComplete();

        Win win = _viewport.GetWin();

        bool isCompleteGems = CollectedGemCount >= _levelContent.GemsCount && _levelContent.GemsCount != 0;
        bool isCompleteSafes = CollectedSafeCount >= _levelContent.SafeCount && _levelContent.SafeCount != 0;
        bool isCompleteEnemies = EnemyKilled >= _levelContent.EnemyCount && _levelContent.EnemyCount != 0;

        AddExtraGems(3, isCompleteGems);
        AddExtraGems(3, isCompleteSafes);
        AddExtraGems(3, isCompleteEnemies);

        win.SetGemsStats(_collectedGemCount, _levelContent.GemsCount, isCompleteGems);
        win.SetSafeStats(CollectedSafeCount, _levelContent.SafeCount, isCompleteSafes);
        win.SetEnemyStats(EnemyKilled, _levelContent.EnemyCount, isCompleteEnemies);
        win.OnOpen(delegate
        {
            if (isTutorial == true)
            {
                DataProvider.SaveByKey(DataProvider.Keys._firstGame, false);
                SceneLoader.Instance.LoadScene("gameplay");
            }
            else
            {
                SceneLoader.Instance.LoadScene("GlobalMap");
            }
        });
        _controller.IsEnabled = false;
    }

    private void AddExtraGems(int count, bool canGet)
    {
        if (canGet == false)
            return;

        _valueCounter.Add(DataProvider.Keys._gems, count);
    }

    private IEnumerator WaitForLose(System.Func<bool> func)
    {
        yield return new WaitUntil(func);

        _viewport.GetLose().OnOpen(delegate
        {
            SceneLoader.Instance.LoadScene("gameplay");
        });
        _controller.IsEnabled = false;

        LevelLose();
    }

    [Button]
    private void LevelComplete()
    {
        print("--LEVEL COMPLETE--");
        _viewport.OnLevelComplete.Invoke();

        if (_levelComplite == false)
        {
            _level++;
            _levelComplite = true;
        }

        SaveProgress();
    }

    [Button]
    private void LevelLose()
    {
        print("--LEVEL LOSE--");
        _viewport.OnLevelLose?.Invoke();
    }

    public void SaveProgress()
    {
        int level = 0;
        DataProvider.LoadByKey(DataProvider.Keys._level, out level, 0);

        if (level <= _level)
        {
            DataProvider.SaveByKey(DataProvider.Keys._level, _level);
        }

        _valueCounter.Save();
        _viewport.GetUpgrader().Save();
        _inventory.Save();

        int gemCollected = PlayerPrefs.GetInt($"LG_{_level}", 0);
        int safeCollected = PlayerPrefs.GetInt($"LS_{_level}", 0);
        PlayerPrefs.SetInt($"LG_{_level}", gemCollected < _collectedGemCount ?_collectedGemCount : gemCollected);
        PlayerPrefs.SetInt($"LS_{_level}", safeCollected < CollectedSafeCount ? CollectedSafeCount : safeCollected);
    }

    private void LevelStart()
    {
        print("--GAME STARTED--");

        _controller = Instantiate(_config.ControllerObject).GetComponent<IController>();
        _controller.IsEnabled = true;
        _player.SetController(_controller);
    }

    public void OpenShop()
    {
        _viewport.GetShop().OnOpen(delegate { _controller.IsEnabled = true; });
        _controller.IsEnabled = false;
    }

    public void OpenUpgrade()
    {
        _viewport.GetUpgrader().OnOpen(delegate { _controller.IsEnabled = true; });
        _controller.IsEnabled = false;
    }

    public void OpenInventory()
    {
        _viewport.GetInventoryCanvas().OnOpen(delegate { _controller.IsEnabled = true; });
        _controller.IsEnabled = false;
    }

    public void BoostPower(float percent, float delay)
    {
        StartCoroutine(_player.BoostPower(percent, delay));
    }

    public void LevelContinue()
    {
        _viewport.GetInGame().OnNextLevelClick(delegate
        {
            SaveProgress();
            SceneLoader.Instance.LoadScene("GlobalMap");
        });

        _controller.IsEnabled = true;
        SetLevelRule(false);
    }

    private void SetLevelRule(bool isTarget)
    {
        _levelContent.GemCountNeeded = isTarget == true ? _levelContent.GemCountNeeded : _levelContent.GemsCount;
        _viewport.GetInGame().ChangeGemCounter(_collectedGemCount, _levelContent.GemCountNeeded);

        StopAllCoroutines();
        StartCoroutine(WaitForWin(() => CollectedGemCount >= _levelContent.GemCountNeeded));
        StartCoroutine(WaitForLose(() => _player.IsAlive == false));
    }*/
}
