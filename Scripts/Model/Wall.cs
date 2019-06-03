namespace Geekbrains
{
    /// <summary>
    /// Скрипт для получения имени с объекта стена
    /// </summary>
    public class Wall : Environment, ISelectObj
    {
        /// <summary>
        /// Метод для получения имени объекта
        /// </summary>
        /// <returns>Возвращает имя объекта на сцене</returns>
        public string GetMessage()
        {
            return Name;//возвращает имя объекта
        }
        /// <summary>
        /// одиночка для конкретного экземпляра объекта
        /// </summary>
        public GameObject Instance { get; private set; }

        /// <summary>
        /// действия при старте программы
        /// </summary>
        protected override void Awake()
        {
            base.Awake();// запуск базового Awake (Environment -> BaseObjectScene)
            Instance = gameObject;//одиночка это текущий объект
        }
    }
}