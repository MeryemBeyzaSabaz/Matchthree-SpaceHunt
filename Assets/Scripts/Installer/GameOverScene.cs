using System;
using System.Collections.Generic;
using Events;
using Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameOverScene : MonoInstaller<GameOverScene>
    {
        [SerializeField] private Camera _camera;
        [Inject] private ProjectSettings projectSettings { get; set; }
        [Inject] private PlayerEvents PlayerEvents { get; set; }
  

        public override void InstallBindings()
        {
            Container.BindInstance(_camera);
        }

      

      

    

     
     

    }
}