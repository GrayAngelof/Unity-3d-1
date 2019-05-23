using UnityEngine;
using System.Collections.Generic;
using My3dGame.Controller; // Подключаем пространство имен, в котором находятся контроллеры
//using My3dGame.Helper;     // Подключаем пространство имен, в котором находятся хэлперы

namespace My3dGame
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        public GameObject ControllersGameObject { get; private set; }
        public InputController InputController1 { get; private set; }
        private FlashlightController _flashlightController;
        public static Main Instance { get; private set; }

        void Start()
        {
            Instance = this;
            ControllersGameObject = new GameObject { name = "Controllers" };
            InputController1 = ControllersGameObject.AddComponent<InputController>();
            _flashlightController = ControllersGameObject.AddComponent<FlashlightController>();
        }
        #region Property      

        /// <summary>
        /// Получить контроллер фонарика
        /// </summary>
        public FlashlightController GetFlashlightController
        {
            get { return _flashlightController; }
        }

        /// <summary>
        /// Получить контроллер ввода данных
        /// </summary>
        /// <returns></returns>
        public InputController GetInputController()
        {
            return InputController1;
        }
        #endregion
    }
}