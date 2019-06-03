using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Графический интерфейс для вывода информации о подсвеченом объекте
    /// </summary>
	public class SelectionObjMessageUi : MonoBehaviour
	{
        /// <summary>
        /// Текстовое поле
        /// </summary>
        private Text _text;

        /// <summary>
        /// Действия при старте объекта
        /// </summary>
        private void Start()
		{
			_text = GetComponent<Text>();//инициализируем тектове поле
        }

        /// <summary>
        /// Текстовое поле
        /// </summary>
        public string Text
		{
			set => _text.text = $"{value}";//передаем в текстовое поле значение для вывода
		}

        /// <summary>
        /// Флаг активирования текстового поля
        /// </summary>
        /// <param name="value">Параметр флага</param>
        public void SetActive(bool value)
		{
			_text.gameObject.SetActive(value);// Включение или отключение видимости текстового поля

        }
	}
}