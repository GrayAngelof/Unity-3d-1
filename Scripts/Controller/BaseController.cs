
namespace Geekbrains
{
    /// <summary>
    /// Базовый контроллер, от которого будут наследоваться все другие контролеры.
    /// </summary>
	public abstract class BaseController
	{
        /// <summary>
        /// Графически пользовательский интерфейс
        /// </summary>
		protected UiInterface UiInterface;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
		protected BaseController()
		{
			UiInterface = new UiInterface();
		}

        /// <summary>
        /// Флаг контроллера Включен/Выключен 
        /// </summary>
		public bool IsActive { get; private set; }

        /// <summary>
        /// Включение контроллера
        /// </summary>
		public virtual void On()
		{
			On(null);
		}

        /// <summary>
        /// Включение контроллера определенного объекта на сцене
        /// </summary>
        /// <param name="obj">Конкретный объект на сцене</param>
		public virtual void On(BaseObjectScene obj)
		{
			IsActive = true;
		}

        /// <summary>
        /// Выключение контроллера
        /// </summary>
		public virtual void Off()
		{
			IsActive = false;
		}

        /// <summary>
        /// Переключение контроллера
        /// </summary>
		public void Switch()
		{
			if (IsActive)
			{
				Off();
			}
			else
			{
				On();
			}
		}
	}
}