namespace Geekbrains
{
    /// <summary>
    /// Графический интерефейс игрока
    /// </summary>
	public class UiInterface
    {
        /// <summary>
        /// Тестовое поля для вывода текущего уровня заряда батарейки фонарика
        /// </summary>
		private FlashLightUiText _flashLightUiText;

        /// <summary>
        /// Тестовое поля для вывода текущего уровня заряда батарейки фонарика
        /// </summary>
		public FlashLightUiText LightUiText
        {
            get
            {
                if (!_flashLightUiText)//если текстовое поле не определено
                    _flashLightUiText = Object.FindObjectOfType<FlashLightUiText>();//находим необходимое текстовое поле
                return _flashLightUiText;//возвращаем тектовое поле
            }
        }

        /// <summary>
        /// графическое поля для вывода текущего уровня заряда батарейки фонарика
        /// </summary>
		private FlashLightUiBar _flashLightUiBar;

        /// <summary>
        /// графическое поля для вывода текущего уровня заряда батарейки фонарика
        /// </summary>
        public FlashLightUiBar FlashLightUiBar
        {
            get
            {
                if (!_flashLightUiBar)//если графическое поле не определено
                    _flashLightUiBar = Object.FindObjectOfType<FlashLightUiBar>();// находим необходимое графическое поле
                return _flashLightUiBar;//возвращаем графическое поле
            }
        }
    }

    /// <summary>
    /// Тестовое поля для вывода количества патронов и обойм
    /// </summary>
    private WeaponUiText _weaponUiText;

    /// <summary>
    /// Тестовое поля для вывода количества патронов и обойм
    /// </summary>
    public WeaponUiText WeaponUiText
    {
        get
        {
            if (!_weaponUiText)//если текстовое поле не определено
                _weaponUiText = Object.FindObjectOfType<WeaponUiText>();// находим необходимое текстовое поле
            return _weaponUiText;//возвращаем тектовое поле
        }
    }

    /// <summary>
    /// Тестовое поля для вывода информации о выделеном объекте
    /// </summary>
    private SelectionObjMessageUi _selectionObjMessageUi;

    /// <summary>
    /// Тестовое поля для вывода информации о выделеном объекте
    /// </summary>
    public SelectionObjMessageUi SelectionObjMessageUi
    {
        get
        {
            if (!_selectionObjMessageUi)//если текстовое поле не определено
                _selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();// находим необходимое текстовое поле
            return _selectionObjMessageUi;//возвращаем тектовое поле
        }
    }
}
}