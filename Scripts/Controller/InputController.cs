using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Контроллер перехватывающий нажатые клавиши
    /// </summary>
	public class InputController : BaseController, IOnUpdate
	{
        /// <summary>
        /// Кнопка активации фонарика
        /// </summary>
		private KeyCode _activeFlashLight = KeyCode.F;
        /// <summary>
        /// Кнопка отмены 
        /// </summary>
		private KeyCode _cancel = KeyCode.Escape;
        /// <summary>
        /// Кнопка перезарядки оружия
        /// </summary>
		private KeyCode _reloadClip = KeyCode.R;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
		public InputController()
		{
			Cursor.lockState = CursorLockMode.Locked;//Фиксирует курсор мышки
		}

        /// <summary>
        /// Метод для обновления в каждом кадре
        /// </summary>
		public void OnUpdate()
		{
			if (!IsActive) return;//если контроллер отключен ничего не делаем
			if (Input.GetKeyDown(_activeFlashLight))//если нажата клавиша фонарика
			{
				Main.Instance.FlashLightController.Switch();//через одиночку мэйна преключаем контроллер фонарика
			}

			if (Input.GetKeyDown(KeyCode.Alpha1))//если нажата клавиша 1
			{
				SelectWeapon(0);//выбираем оружие под номером 0
			}

			if (Input.GetKeyDown(_cancel))//если нажата кнопка отмены
			{
				Main.Instance.WeaponController.Off();//отключаем контроллер оружия
				Main.Instance.FlashLightController.Off();//отключаем онтроллер фонарика
			}

			if (Input.GetKeyDown(_reloadClip))//если нажата кнопки перезарядки
			{
				Main.Instance.WeaponController.ReloadClip();//через одиночку мэйна у контроллера оружия вызываем метод перезарядки
            }
			if (Input.GetAxis("Mouse ScrollWheel") > 0)//если крутим колесико мышки вверх
			{
				MouseScroll(MouseScrollWheel.Up);//вызываем метод прокрутки мышки с параметром вверх
			}
			if (Input.GetAxis("Mouse ScrollWheel") < 0)//если крутим колесико мышки вниз
			{
				MouseScroll(MouseScrollWheel.Down);//вызываем метод прокрутки мышки с параметром вниз
            }
		}
        /// <summary>
        /// Выбор оружия по индексу в массиве
        /// </summary>
        /// <param name="value">индекс оружия в массиве с оружием</param>
		private void SelectWeapon(int value)
		{
			var tempWeapon = Main.Instance.Inventory.SelectWeapon(value);// в tempWeapon через одиночку мэйна в инветаре выбираем оружие с выбраным номером
            SelectWeapon(tempWeapon);//вызов метода выбора оружия с передачей конкретного экземляра оружия
		}

        /// <summary>
        /// прокрутка колесика мышки
        /// </summary>
        /// <param name="value">Крутим вверх или вниз по перечислителю прокрутки мышки</param>
		private void MouseScroll(MouseScrollWheel value)
		{
			var tempWeapon = Main.Instance.Inventory.SelectWeapon(value);// в tempWeapon через одиночку мэйна в инветаре выбираем оружие с выбраным номером
            SelectWeapon(tempWeapon);//вызов метода выбора оружия с передачей конкретного экземляра оружия
        }

        /// <summary>
        /// выбора оружия с передачей конкретного экземляра оружия
        /// </summary>
        /// <param name="weapon">экземляра оружия</param>
		private void SelectWeapon(Weapon weapon)
		{
			Main.Instance.WeaponController.Off();//отключение контроллера оружия, нужно для отключения при повторном нажатии на клавишу вызова оружия
			if (weapon != null)//если экземпляр оружия существует
			{
				Main.Instance.WeaponController.On(weapon);//через одиночку мэйна включаем контроллер оружия 
            }
		}
	}
}