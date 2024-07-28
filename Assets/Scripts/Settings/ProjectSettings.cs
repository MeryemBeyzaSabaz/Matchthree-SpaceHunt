using Components;
using Installers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(ProjectSettings), menuName = EnvVar.ProjectSettingsPath, order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        [SerializeField] private GridManager.Settings _gridManagerSettings;
        public GridManager.Settings GridManagerSettings => _gridManagerSettings;

        [SerializeField] private MainSceneInstaller.Settings _mainSceneSettings;

        public MainSceneInstaller.Settings MainSceneSettings
        {
            get { return this._mainSceneSettings; }
        }

        [Button]
        private void SetPlayerLevel(int level)
        {
            PlayerPrefs.SetInt(EnvVar.PlayerlevelPref, level);
        }
    }
}