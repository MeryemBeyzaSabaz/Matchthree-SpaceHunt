using System;
using System.Collections.Generic;
using Events;
using Settings;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        [SerializeField] private Camera _camera;
        [Inject] private ProjectSettings projectSettings { get; set; }
        [Inject] private PlayerEvents PlayerEvents { get; set; }
        private Settings _mySettings;
        private int _pLevel;

        public override void InstallBindings()
        {
            Container.BindInstance(_camera);
        }

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("Scene Loaded: " + scene.name);

            if (scene.name == "Login")
            {
                return;
            }

            _mySettings = projectSettings.MainSceneSettings;
            LoadPlayer();

            if (_pLevel >= 0 && _pLevel < _mySettings.LevelList.Count)
            {
                GameObject levelNew = Container.InstantiatePrefab(_mySettings.LevelList[_pLevel]);
            }
            else
            {
                Debug.LogError("Geçersiz seviye indeksi: " + _pLevel);
                _pLevel = 0;
                SavePlayer();
                GameObject levelNew = Container.InstantiatePrefab(_mySettings.LevelList[_pLevel]);
            }
        }

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnRegisterEvents();
        }

        private void RegisterEvents()
        {
            PlayerEvents.LevelComplete += OnLevelComplete;
        }

        private void UnRegisterEvents()
        {
            PlayerEvents.LevelComplete -= OnLevelComplete;
        }

        private void OnLevelComplete()
        {
            LevelUp();
            SavePlayer();
        }

        private void LevelUp()
        {
            _pLevel++;
            if (_pLevel >= _mySettings.LevelList.Count)
            {
                _pLevel = 0;
            }
        }

        private void SavePlayer()
        {
            PlayerPrefs.SetInt(EnvVar.PlayerlevelPref, _pLevel);
        }

        private void LoadPlayer()
        {
            _pLevel = PlayerPrefs.GetInt(EnvVar.PlayerlevelPref, 0);
            if (_pLevel < 0 || _pLevel >= _mySettings.LevelList.Count)
            {
                Debug.LogError("Yüklenen geçersiz seviye indeksi: " + _pLevel);
                _pLevel = 0;
            }
        }

        [Serializable]
        public class Settings
        {
            [SerializeField] private List<GameObject> _levelList;
            public List<GameObject> LevelList
            {
                get { return this._levelList; }
            }
        }
    }
}
