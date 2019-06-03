using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Класс с моделью фонарика
    /// </summary>
	public sealed class FlashLightModel : BaseObjectScene
	{
        /// <summary>
        /// Источник света
        /// </summary>
		private Light _light;
        /// <summary>
        /// Камера в голове персонажа игрока
        /// </summary>
		private Transform _goFollow;
        /// <summary>
        /// Смещение перед головой персонажа, откуда будет идти свет
        /// </summary>
		private Vector3 _vecOffset;
        /// <summary>
        /// Текущий заряд батереи фонарика
        /// </summary>
		public float BatteryChargeCurrent { get; private set; }
        /// <summary>
        /// Скорость поворота фонарика вслед за головой персонажа
        /// </summary>
		[SerializeField] private float _speed = 10;
        /// <summary>
        /// Максимальный уровень заряда фонарика
        /// </summary>
		[SerializeField] private float _batteryChargeMax = 50;
        /// <summary>
        /// Интенсивность свечения фонарика
        /// </summary>
		[SerializeField] private float _intensity = 1.5f;
        /// <summary>
        /// Уровень заряда батареи при котором фонарик будет мигать
        /// </summary>
		private float _share;
        /// <summary>
        /// Уровень изменения интенсивности свечения
        /// </summary>
		private float _takeAwayTheIntensity;
        /// <summary>
        /// Степень зарядки батареи фонарика
        /// </summary>
		public float Charge => BatteryChargeCurrent / BatteryChargeMax;
        /// <summary>
        /// Максимальный уровень заряда батареи
        /// </summary>
		public float BatteryChargeMax => _batteryChargeMax;

        /// <summary>
        /// нициализация объекта при старте
        /// </summary>
		protected override void Awake()
		{
			base.Awake();//запуск базового Awake(BaseObjectScene)
            _light = GetComponent<Light>();//находим источник освещения

			_goFollow = Camera.main.transform;//находим камеру в голове персонажа
			transform.position = Camera.main.transform.position;//находим позицию трансформа камеры в голове персонажа
			_vecOffset = transform.position - _goFollow.position;//находим смещение перед головой персонажа, откуда будет идти свет
            BatteryChargeCurrent = BatteryChargeMax;//выставляем текущий заряд батареи как максимальный заряд батареи
			_light.intensity = _intensity;//выставляем интенсивность свечения фонарика
			_share = BatteryChargeMax / 4;//выставляем уровень при котором фонарик будет мигать
			_takeAwayTheIntensity = _intensity / (BatteryChargeMax * 100);//выставляем уровень измениения интенсивности свечения
        }

        /// <summary>
        /// Включение и выключение фонарика
        /// </summary>
        /// <param name="value">флаг включения фонарика</param>
		public void Switch(bool value)
		{
			_light.enabled = value;// выствление флага свечения фонарика
			if (!value) return;//если флаг опущен, то ничего не делаем
			transform.position = _goFollow.position + _vecOffset;//находим позицию трансформа фонарика
			transform.rotation = _goFollow.rotation;//вычисляем поворот трансформа фонарика
		}

        /// <summary>
        /// Поворот фонарика
        /// </summary>
		public void Rotation()
		{
			if (!_light) return;//если свет выключен, то ничего не делаем

			transform.position = _goFollow.position + _vecOffset;//находим позицию трансформа фонарика
            transform.rotation = Quaternion.Lerp(transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);//вычисляем поворот трансформа фонарика
        }

        /// <summary>
        /// Изменение заряда фонарика 
        /// </summary>
        /// <returns></returns>
		public bool EditBatteryCharge()
		{
			if (BatteryChargeCurrent > 0)//если заряд фонарика больше 0
			{
				BatteryChargeCurrent -= Time.deltaTime;//уменьшаем заряд фонарика с течением времени

				if (BatteryChargeCurrent < _share)//если заряд меньше уровня мигания
				{
					_light.enabled = Random.Range(0, 100) >= Random.Range(0, 10);//изменение свечения на случайную величину
				}
				else
				{
					_light.intensity -= _takeAwayTheIntensity;//уменьшаем свечения на уровень измениения интенсивности свечения
                }
				return true;//возвращаем флак, что фонарик светит
			}

			return false;//возвращаем флаг, что фонарик покас
		}

        /// <summary>
        /// Перезарядка батареи фонарика
        /// </summary>
        /// <returns></returns>
		public bool BatteryRecharge()
		{
			if (BatteryChargeCurrent < BatteryChargeMax)//если текущий уровень заряда меньше максимального
			{
				BatteryChargeCurrent += Time.deltaTime;//увеличиваем заряд фонарика с течением времени
                return true;//возвращаем флаг, что фонарик может заряжаться
			}
			return false;//возвращаем флаг, что фонарик полностью заряжен
		}
	}
}