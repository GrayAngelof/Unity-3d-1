using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Контроллер управляющий моделью FlashLightModel
    /// </summary>
	public class FlashLightController : BaseController, IOnUpdate, IInitialization
	{
        /// <summary>
        /// объект фонарика
        /// </summary>
		private FlashLightModel _flashLight;

        /// <summary>
        ///  Метод для обновления в каждом кадре
        /// </summary>
        public void OnUpdate()
		{
			if (!IsActive) return;//если контроллер выключен то ничего не делаем
			
			if (_flashLight.EditBatteryCharge())//если заряд батареи фонарика может меняться
			{
				UiInterface.LightUiText.Text = _flashLight.BatteryChargeCurrent;//на графический интерфейс фонарика выводим цифрами текущий заряд батареи
				UiInterface.FlashLightUiBar.Fill = _flashLight.Charge;// на графический интерфейс фонарика выводим полоской текущий заряд батареи

                _flashLight.Rotation();//вращает фонарик вслед за персонажем

				if (_flashLight.BatteryChargeCurrent <= _flashLight.BatteryChargeMax/2)//если текущий заряд батареи фонарика меньше половины
				{
					UiInterface.FlashLightUiBar.SetColor(Color.red);//изменяет цвет полоски заряда на красный
				}
			}
			else//если заряд батари не может меняться
			{
				Off();//выключаем контроллер
			}
		}

        /// <summary>
        /// метод для старта контроллера
        /// </summary>
		public void OnStart()
		{
			_flashLight = Main.Instance.Inventory.FlashLight;//через одиночку мэйна в инветаре выбираем фонарик
            UiInterface.LightUiText.SetActive(false);//выключаем графический интерфейс с текстом
			UiInterface.FlashLightUiBar.SetActive(false);//выключаем графический интерфейс с полоской
        }

        /// <summary>
        /// Включение фонарика
        /// </summary>
		public override void On()
		{
			if (IsActive)return;//если контроллер уже включен, ничего не делаем
			if (_flashLight.BatteryChargeCurrent <= 0) return;//если батарейка разряжена, ничего не делаем
			base.On();// запускает включение контроллера реализованое в BaseController
            _flashLight.Switch(true);//включение источника освещения
			UiInterface.LightUiText.SetActive(true);//включение графического интерфейса с текстом
			UiInterface.FlashLightUiBar.SetActive(true);//включение графического интерфейса с полоской
            UiInterface.FlashLightUiBar.SetColor(Color.green);//изменение цвета полоски на зеленый
		}

        /// <summary>
        /// выключение фонарика
        /// </summary>
		public sealed override void Off()
		{
			if (!IsActive) return;//если контроллер уже выключен, ничего не делаем
            base.Off();// запускает выключение контроллера реализованое в BaseController
            _flashLight.Switch(false);// выключение источника освещения

            UiInterface.LightUiText.SetActive(false);//выключение графического интерфейса с текстом
            UiInterface.FlashLightUiBar.SetActive(false);//выключение графического интерфейса с полоской
        }
	}
}