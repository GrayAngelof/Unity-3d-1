using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Базовый класс для всех видов оружия
    /// </summary>
	public abstract class Weapon : BaseObjectScene
	{
        /// <summary>
        /// Максимальное количество патронов в обойме(для рандома)
        /// </summary>
		private int _maxCountAmmunition = 20;
        /// <summary>
        /// Маинимальное количество патронов в обойме(для рандома)
        /// </summary>
		private int _minCountAmmunition = 40;
        /// <summary>
        /// Количество обойм
        /// </summary>
		private int _countClip = 5;
        /// <summary>
        /// Патроны
        /// </summary>
		public Ammunition Ammunition;
        /// <summary>
        /// Обоймы
        /// </summary>
		public Clip Clip;

        /// <summary>
        /// Количество обойм
        /// </summary>
        public int CountClip => _clips.Count;

        /// <summary>
        /// Массив с различными типами патронов
        /// </summary>
		protected AmmunitionType[] _ammunitionType = {AmmunitionType.Bullet};
        /// <summary>
        /// Точка из которой будут вылетать пули
        /// </summary>
		[SerializeField] protected Transform _barrel;
        /// <summary>
        /// Сила с которой будут вылетать пули
        /// </summary>
		[SerializeField] protected float _force = 999;
        /// <summary>
        /// Задержка между выстрелами
        /// </summary>
		[SerializeField] protected float _rechergeTime = 0.2f;
        /// <summary>
        /// Очередь с обоймами
        /// </summary>
		private Queue<Clip> _clips = new Queue<Clip>();
        /// <summary>
        /// Флаг готовности оружия
        /// </summary>
		protected bool _isReady = true;
		//protected Timer _timer = new Timer();
        
		/// <summary>
        /// Действия при старте объекта
        /// </summary>
		private void Start()
		{
			for (var i = 0; i <= _countClip; i++)//перебор всех обойм до максимального количества
			{
				AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });//добавление обоймы со случайным количеством патроно от мин до макс
			}

			ReloadClip();// перезарядка обоймы
		}

        /// <summary>
        /// Медот для стрельбы
        /// </summary>
		public abstract void Fire();

		//protected virtual void Update()
		//{
		//	_timer.Update();
		//	if (_timer.IsEvent())
		//	{
		//		ReadyShoot();
		//	}
		//}

        /// <summary>
        /// Выставление флага готовности к стрельбе
        /// </summary>
		protected void ReadyShoot()
		{
			_isReady = true;
		}

        /// <summary>
        /// Метод для заряжания патронов в обойму
        /// </summary>
        /// <param name="clip">количество патронов в текущем экземляре обоймы</param>
		protected void AddClip(Clip clip)
		{
			_clips.Enqueue(clip);//Добавление текущего экземляра обоймы в очередь
		}

        /// <summary>
        /// Перезарядка обоймы
        /// </summary>
		public void ReloadClip()
		{
			if (CountClip <= 0) return;//если количество обойм =0 то ничего не делаем
			Clip = _clips.Dequeue();//получение экземляра обоймы из очереди
		}
	}
}