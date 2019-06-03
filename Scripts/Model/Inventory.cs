using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Инвентарь персонажа игрока
    /// </summary>
	public class Inventory : IInitialization
	{
        /// <summary>
        /// Массив с оружием
        /// </summary>
		private Weapon[] _weapons = new Weapon[5];

        /// <summary>
        /// Геттер возращающий массив оружия
        /// </summary>
		public Weapon[] Weapons => _weapons;
        /// <summary>
        /// Индекс выбраного оружия
        /// </summary>
		private int _selectIndexWeapon = 0;
        /// <summary>
        /// Фонарик
        /// </summary>
		public FlashLightModel FlashLight { get; private set; }

        /// <summary>
        /// Действия при старте
        /// </summary>
		public void OnStart()
		{
			_weapons = Main.Instance.Player.GetComponentsInChildren<Weapon>();//получение от одиночки мэйна всех дочерних компонентов оружия

			foreach (var weapon in Weapons)//перебор всего массива с оружием
			{
				weapon.IsVisible = false;//делаем оружие невидимым
			}

			FlashLight = Object.FindObjectOfType<FlashLightModel>();//кэшируем фонарик находя его на сцене
			FlashLight.Switch(false);//выключем фонарик
		}

		/// <summary>
		/// Выбор оружия цифрами 
		/// </summary>
		/// <param name="weaponNumber">Индекс оружия</param>
		public Weapon SelectWeapon(int weaponNumber)
		{
			if (weaponNumber < 0 || weaponNumber >= Weapons.Length) return null;//если номер оружия меньше нуля или больше чем длинна массива оружия, то ничего не делаем

			var tempWeapon = Weapons[weaponNumber];//инициализируем оружие с выбраным индексом в массиве с оружием
			return tempWeapon;//возвращаем выбраное оружие
		}

		/// <summary>
		/// Прокрутки оружия колесом мыши
		/// </summary>
		/// <param name="scrollWheel">Инкремент или декремент индекса</param>
		public Weapon SelectWeapon(MouseScrollWheel scrollWheel)
		{
			if (scrollWheel == MouseScrollWheel.Up)//если крутим колесико мышки вверх
			{
				if (_selectIndexWeapon < Weapons.Length - 1)//если текущее выбраное оружие меньше чем размер массива
				{
					_selectIndexWeapon++;//выбраное оружие увеличивается на единицу
				}
				else
				{
					_selectIndexWeapon = -1;//иначе выбраное оружие равна значеню вне массива
				}
				return SelectWeapon(_selectIndexWeapon);//возвращаем из выбора оружия выбраное оружие
			}

			if (_selectIndexWeapon <= 0)//если текущее выбраное оружие меньше или равно нулю
            {
				_selectIndexWeapon = Weapons.Length;// выбраное оружие равно значению размера массива оружия

            }
			else
			{
				_selectIndexWeapon--;// иначе выбраное оружие уменьшается на единицу
            }
			return SelectWeapon(_selectIndexWeapon);//возвращаем из выбора оружия выбраное оружие
        }

        /// <summary>
        /// Добавляем подбираемое оружие
        /// </summary>
        /// <param name="weapon">экземпляр оружия</param>
		public void AdddWeapon(Weapon weapon)
		{
			
		}

		// Добавить функционал
	}
}