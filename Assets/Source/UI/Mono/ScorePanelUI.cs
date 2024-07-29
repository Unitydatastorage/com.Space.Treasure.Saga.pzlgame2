using System;
using Source.Game;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Source.UI.Mono
{
    public class ScorePanelUI : MonoBehaviour
    {
        private GameStats _gameStats;
        private GameSettingsScriptable _gameSettingsScriptable;
        
        [FormerlySerializedAs("_itemCounterUI")] [SerializeField] private ItemCounter itemCounter;
        private ItemCounter[] _itemCounterUis;

        [Inject]
        private void Container(GameStats gameStats, GameSettingsScriptable gameSettingsScriptable)
        {
            _gameStats = gameStats;
            _gameSettingsScriptable = gameSettingsScriptable;
            _gameStats.OnStartLevel += OnStartLevel;
            _gameStats.OnItemScoreUpdate += OnItemScoreUpdate;
        }

        private void OnItemScoreUpdate(int val, int maxVal, int id)
        {
            if (_itemCounterUis != null && _itemCounterUis.Length > id)
            {
                _itemCounterUis[id].UpdateCounter(val, maxVal);
            }
        }

        private void OnStartLevel()
        {
            if (_itemCounterUis != null && _itemCounterUis.Length > 0)
            {
                for (int i = 0; i < _gameSettingsScriptable.EggSprites.Length; i++)
                {
                    Destroy(_itemCounterUis[i].gameObject);
                }
            }
            _itemCounterUis = new ItemCounter[_gameSettingsScriptable.EggSprites.Length];
            
            for (int i = 0; i < _gameSettingsScriptable.EggSprites.Length; i++)
            {
                Debug.Log("Score Created!" + _itemCounterUis.Length);
                _itemCounterUis[i] = Instantiate(itemCounter, transform);
                _itemCounterUis[i].SetSprite(_gameSettingsScriptable.EggSprites[i]);
            }
        }
    }
}