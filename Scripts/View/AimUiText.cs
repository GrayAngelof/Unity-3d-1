using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Графический интерфейс для вывода графической информации о стрельбе по мишеням
    /// </summary>
    public class AimUiText : MonoBehaviour
	{
        /// <summary>
        /// Список мишеней
        /// </summary>
		private Aim[] _aims;
        /// <summary>
        /// Текстовое поле
        /// </summary>
		private Text _text;
        /// <summary>
        /// Количество набраных очков
        /// </summary>
		private int _countPoint;

        /// <summary>
        /// действия при старте программы
        /// </summary>
        private void Awake()
		{
			_aims = FindObjectsOfType<Aim>();//инициализируем масскив с мешенями
			_text = GetComponent<Text>();//инициализируем текствое поле
		}

        /// <summary>
        /// Действия при активации объекта
        /// </summary>
		private void OnEnable()
		{
			foreach (var aim in _aims)//пробегаемся по всему массиву с мишенями
			{
				aim.OnPointChange += UpdatePoint;//подписываемся на событие OnPointChange
            }
		}

        /// <summary>
        /// Действия при дезактивации объекта
        /// </summary>
        private void OnDisable()
		{
			foreach (var aim in _aims)//пробегаемся по всему массиву с мишенями
            {
				aim.OnPointChange -= UpdatePoint;//отписываемся от события OnPointChange
            }
		}

        /// <summary>
        /// Изменение количества очков
        /// </summary>
		private void UpdatePoint()
		{
			var pointTxt = "очков";
			++_countPoint;
			if (_countPoint >= 5) pointTxt = "очков";
			else if (_countPoint == 1) pointTxt = "очко";
			else if (_countPoint < 5) pointTxt = "очка";
			_text.text = $"Вы заработали {_countPoint} {pointTxt}";
		}
	}
}