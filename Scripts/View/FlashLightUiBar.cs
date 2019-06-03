using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Графический интерфейс для вывода графической информации о фонарике
    /// </summary>
    public class FlashLightUiBar : MonoBehaviour
	{
        /// <summary>
        /// Полоска интерфейса
        /// </summary>
		private Image _bar;

        /// <summary>
        /// действия при старте программы
        /// </summary>
        private void Awake()
		{
			_bar = GetComponent<Image>();//инициализируем полоску
		}

        /// <summary>
        /// Заполнение полоски
        /// </summary>
		public float Fill
		{
			set => _bar.fillAmount = value;//передаем в полоску значение для вывода
        }

        /// <summary>
        /// Флаг активирования полоски
        /// </summary>
        /// <param name="value">Параметр флага</param>
        public void SetActive(bool value)
		{
			_bar.gameObject.SetActive(value);// Включение или отключение видимости полоски
        }
		
        /// <summary>
        /// Изменение цвета полоски
        /// </summary>
        /// <param name="col">Цвет</param>
		public void SetColor(Color col)
		{
			_bar.color = col;
		}

	}
}