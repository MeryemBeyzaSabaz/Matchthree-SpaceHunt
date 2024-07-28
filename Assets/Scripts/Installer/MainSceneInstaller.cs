using System;
using System.Collections.Generic;
using Events;
using Settings;
using UnityEngine;
using Zenject;

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
            _mySettings = projectSettings.MainSceneSettings;
        }

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnRegisterEvents();
        }

        public override void Start()
        {
            LoadPlayer();

            // _pLevel değerinin geçerli olup olmadığını kontrol ediyoruz
            if (_pLevel >= 0 && _pLevel < _mySettings.LevelList.Count)
            {
                GameObject levelNew = Container.InstantiatePrefab(_mySettings.LevelList[_pLevel]);
            }
            else
            {
                Debug.LogError("Geçersiz seviye indeksi: " + _pLevel);
                _pLevel = 0; // Geçersiz seviye indeksi olduğunda _pLevel'i sıfırlıyoruz
                SavePlayer();
                GameObject levelNew = Container.InstantiatePrefab(_mySettings.LevelList[_pLevel]); // Varsayılan olarak Level1'i yükler
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

        private void RegisterEvents()
        {
            PlayerEvents.LevelComplete += OnLevelComplete;
        }

        private void OnLevelComplete()
        {
            LevelUp();
            SavePlayer();
        }

        private void LevelUp()
        {
            _pLevel++;
            // Geçersiz bir değere ulaşıldığında sıfırlama
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

            // _pLevel'in geçerli bir indeks olup olmadığını kontrol ediyoruz
            if (_pLevel < 0 || _pLevel >= _mySettings.LevelList.Count)
            {
                Debug.LogError("Yüklenen geçersiz seviye indeksi: " + _pLevel);
                _pLevel = 0; // Geçersiz bir indeks olduğunda _pLevel'i sıfırlıyoruz
            }
        }

        private void UnRegisterEvents()
        {
            PlayerEvents.LevelComplete -= OnLevelComplete;
        }
    }
}
