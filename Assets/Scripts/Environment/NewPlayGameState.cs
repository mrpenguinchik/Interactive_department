using Prickly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayGameState : PlayGameState
{
    [SerializeField] private TestWindow[] _testWindows;
    [SerializeField] private NewViewPort _newViewPort;
    [SerializeField] private FPS _fplayer;
    [SerializeField] private TestZone[] _testZones;
    private IController _controller;
    public override void Init(GameConfig config)
    {
        base.Init(config);
        //StartProgrammingTest();
        for (int i = 0; i < _testWindows.Length; i++)
        {
            int k = i;
            print(_testZones[i]);
            _testZones[k].OnStartInteract += () =>
           {
              
               _testWindows[k].Init();
               _testWindows[k].Show(true);
           };
            _testZones[k].OnEndInteract += () =>
            {

                _testWindows[k].Hide(false);
            };
        }
      
        _controller = SetupPlayer(config);
    }
   override protected IController SetupPlayer(GameConfig config)
    {
        IController controller = Instantiate(config.Controller);
        _mainCamera.Init(_fplayer);
        _fplayer.Init(controller, config.PlayerStat);

        return controller;
    }


}
