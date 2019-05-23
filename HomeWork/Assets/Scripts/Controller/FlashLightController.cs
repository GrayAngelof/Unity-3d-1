using My3dGame;
using UnityEngine;

namespace My3dGame.Controller
{
    public sealed class FlashlightController : BaseController
    {
        private Light _light;            // Ссылка на источник света

        private void Awake()
        {
            _light = GameObject.Find("Flashlight").GetComponent<Light>();
        }

        public void Start()
        {
            SetActiveFlashlight(false); // При старте сцены выключаем фонарик
        }
        public void Update()
        {
            if (!IsActive) return;       // Если контроллер неактивен, выходим из Update
            // Здесь описываем поведение фонарика: можно добавить максимальное время его работы, смену батареек и другое
        }
        private void SetActiveFlashlight(bool value)
        {
            _light.enabled = value;
        }
        public override void On()
        {
            if (IsActive) return;          // Если контроллер включен, повторно не включаем
            base.On();
            SetActiveFlashlight(true);
        }
        public override void Off()
        {
            if (!IsActive) return;        // Если контроллер выключен, повторно не выключаем
            base.Off();
            SetActiveFlashlight(false);
        }
    }
}