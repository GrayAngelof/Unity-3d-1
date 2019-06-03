using System;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Выделение объектов на сцене
    /// </summary>
	public class SelectionController : BaseController, IOnUpdate
	{
        /// <summary>
        /// Основная камера - голова перснажа
        /// </summary>
		private readonly Camera _mainCamera;
        /// <summary>
        /// Центр экрана
        /// </summary>
		private readonly Vector2 _center;
        /// <summary>
        /// Дистанция обнаружения
        /// </summary>
		private readonly float _dedicateDistance = 20;
        /// <summary>
        /// Обнаруженый объект
        /// </summary>
		private GameObject _dedicatedObj;
        /// <summary>
        /// Выбраный объект
        /// </summary>
		private ISelectObj _selectedObj;
        /// <summary>
        /// Флаг для пустого сообщения
        /// </summary>
		private bool _nullString;
        /// <summary>
        /// флаг для выбраного объекта
        /// </summary>
		private bool _isSelectedObj;

        /// <summary>
        /// Конструктор класса
        /// </summary>
		public SelectionController()
		{
			_mainCamera = Camera.main;//находм основную камеру
			_center = new Vector2(Screen.width / 2, Screen.height / 2);//находим центр экрана
		}

        /// <summary>
        /// Метод для обновления в каждом кадре
        /// </summary>
		public void OnUpdate()
		{
			if (Physics.Raycast(_mainCamera.ScreenPointToRay(_center), out var hit, _dedicateDistance))//если выпущеный рейкаст из центра экрана на заданую дистанцию и возвращает объект в который попал
			{
				SelectObject(hit.collider.gameObject);//производим действие над подсвеченым объектом
                _nullString = false;// помечаем, что строка сообщений у нас не пустая
			}
			else if(!_nullString)//Если строка сообщений у нас пустая
			{
				UiInterface.SelectionObjMessageUi.Text = String.Empty;//в графическом интерфейсе обнулям строчку
                _nullString = true;//ставим флаг, что строка пустая
				_dedicatedObj = null;//обнуляем значение о выбраном объекте
				_isSelectedObj = false;//помечаем, что выделии объект
			}
			if (_isSelectedObj)//если выделили объект
			{
				// Действие над объектом

				var obj = _selectedObj.Instance.GetComponent<BaseObjectScene>();// в obj передается реализация BaseObjectSceneв в одиночке выделеного объекта
                if (obj == null) return;// если реализации BaseObjectSceneв нет, то выходим

				switch (obj)//перебор 
				{
					case Ammunition ammunition://если выделен магазин
						break;
					case FlashLightModel flashLightModel://если выделен фонарик
                        break;
					case Weapon weapon://если выделено оружие
                        break;
				}
			}
		}

        /// <summary>
        /// Действие над подсвеченым объектом. В данной реализации только выводит сообщение из объекта
        /// </summary>
        /// <param name="obj">Объект на сцене</param>
		private void SelectObject(GameObject obj)
		{
			if (obj == _dedicatedObj) return;//если подсвеченый объект тот же, что был выбран до этого, то ничего не происходит
			_selectedObj = obj.GetComponent<ISelectObj>();//в _selectedObj передается реализация ISelectObj в obj
            if (_selectedObj != null) // если в _selectedObj есть реализация ISelectObj
            {
				UiInterface.SelectionObjMessageUi.Text = _selectedObj.GetMessage();// вывод в графический интерфейс метода GetMessage
                _isSelectedObj = true;// помечаем объект выбранным
			}
			else
			{
				UiInterface.SelectionObjMessageUi.Text = String.Empty;// в графическом интерфейсе обнулям строчку
				_isSelectedObj = false;//помечаем объект не выбраным
			}
			_dedicatedObj = obj;// помечаем подсвеченый объект как выбраный
		}
	}
}