using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Контроллер оружия
    /// </summary>
	public class WeaponController : BaseController, IOnUpdate
	{
        /// <summary>
        /// Экземпляр оружия
        /// </summary>
		private Weapon _weapon;
        /// <summary>
        /// Левая кнопка мышки для стрельбы из оружия
        /// </summary>
		private int _mouseButton = (int)MouseButton.LeftButton;

        /// <summary>
        /// Метод для обновления в каждом кадре
        /// </summary>
		public void OnUpdate()
		{
			if (!IsActive) return;//если контроллер не включен, ничего не происходит
			if (Input.GetMouseButton(_mouseButton))//Если мышка стреляет
			{
				_weapon.Fire();//Происходит выстрел
				UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);//отображение в графическом интерфейсе патронов и обойм
			}
		}

        /// <summary>
        /// Включение объекта оружия
        /// </summary>
        /// <param name="weapon">Конкретный экземпляр оружия</param>
		public override void On(BaseObjectScene weapon)
		{
			if (IsActive) return;//если оружие уже включено ничего не происходит
			base.On(weapon);//Использует IsActive = true в базовом классе BaseController

            _weapon = weapon as Weapon;//попытка приведение конкретного экземляра оружия к классу Weapon
            if (_weapon == null) return;//если приведение не получилось, то ничего не происходит
			_weapon.IsVisible = true;//оружие становится видимым на экране
			UiInterface.WeaponUiText.SetActive(true);//включает графических интерфейс оружия
			UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);//вывод в графический интерфейс количество патронов и обойм
		}

        /// <summary>
        /// Выключение объекта оружия
        /// </summary>
		public override void Off()
		{
			if (!IsActive) return;//если оружие уже выключено ничего не происходит
            base.Off();//Использует IsActive = false; в базовом классе BaseController
            _weapon.IsVisible = false;//оружие становится невидимым на экране
            _weapon = null;//обнуление ссылки на экземпляр оружия
			UiInterface.WeaponUiText.SetActive(false);//отключение графического интерфейса оружия
		}
        /// <summary>
        /// Перезарядка оружия
        /// </summary>
		public void ReloadClip()
		{
			if (_weapon == null) return;//если оружие не выбрано, то ничего не происходит
			_weapon.ReloadClip();//выполнение метода перезарядки у конкретного экземпляра оружия
			UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);//вывод в графический интерфейс количество патронов и обойм
        }
	}
}