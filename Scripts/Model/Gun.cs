
namespace Geekbrains
{
    /// <summary>
    /// Экземляр оружия Gun
    /// </summary>
	public sealed class Gun : Weapon
	{
        /// <summary>
        /// Метд для стрельбы
        /// </summary>
		public override void Fire()
		{
			if (!_isReady) return;//если оружие не готово, то ничего не делаем
			if (Clip.CountAmmunition <= 0) return;//если обойм нет, то ничего не делаем
			if (!Ammunition) return;//если патронов нет, то ничего не делаем
			var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);//создаем вылетающую пулю, с определенным типом патронов, в точке из которой должны вылетать пути с направлением как у точки
			temAmmunition.AddForce(_barrel.forward * _force);//пинаем пулю по направлению вперед с силой конкретного типа пули
			Clip.CountAmmunition--;//уменьшаем количество патронов в обойме
			_isReady = false;// опускаем флаг готовности к стрельбе
			Invoke(nameof(ReadyShoot), _rechergeTime);//синхронный вызов делегата по имени метода ReadyShoot с передачей времени перезарядки
			//_timer.Start(_rechergeTime);
		}
	}
}