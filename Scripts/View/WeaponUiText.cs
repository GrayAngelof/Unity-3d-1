using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Текстовый интерфейс для отображения количества патронов и обойм
    /// </summary>
	public class WeaponUiText : MonoBehaviour
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
        /// отображение текущего количества патронов и обойм
        /// </summary>
        /// <param name="countAmmunition">текущее количество патронов</param>
        /// <param name="countClip">текущее количество обойм</param>
		public void ShowData(int countAmmunition, int countClip)
		{
			_text.text = $"{countAmmunition}/{countClip}";//вывод в тектовое поле
		}

        /// <summary>
        /// Флаг активирования текстового поля
        /// </summary>
        /// <param name="value">Параметр флага</param>
		public void SetActive(bool value)
		{
			_text.gameObject.SetActive(value);//Включение или отключение видимости тектсого поля
		}
	}
}