namespace Geekbrains
{
    /// <summary>
    /// Контроллер управления персонажем игрока
    /// </summary>
	public class PlayerController : BaseController, IOnUpdate
	{
        /// <summary>
        /// движение персонажем
        /// </summary>
		private IMotor _motor;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="motor">Метод управления персонажем</param>
		public PlayerController(IMotor motor)
		{
			_motor = motor;
		}

        /// <summary>
        /// Метод для обновления в каждом кадре
        /// </summary>
        public void OnUpdate()
		{
			if (!IsActive) return;//если контроллер отключен, ничего не делаем
			_motor.Move();//передвигаемся с помощью двигателя персонажа
		}
	}
}