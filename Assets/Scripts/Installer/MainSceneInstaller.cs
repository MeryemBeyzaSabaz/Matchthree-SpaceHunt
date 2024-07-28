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
            GameObject levelNew = Container.InstantiatePrefab(_mySettings.LevelList[_pLevel]);
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
            LoadPlayer();
            LevelUp();
            SavePlayer();
        }

        private void LevelUp()
        {
            _pLevel++;
        }

        private void SavePlayer()
        {
            PlayerPrefs.SetInt(EnvVar.PlayerlevelPref, _pLevel);
        }

        private void LoadPlayer()
        {
            _pLevel = PlayerPrefs.GetInt(EnvVar.PlayerlevelPref);
        }

        private void UnRegisterEvents()
        {
            PlayerEvents.LevelComplete += OnLevelComplete;
        }
    }
}