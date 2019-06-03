using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Контроллер ботов
    /// </summary>
	public class BotController : BaseController, IOnUpdate, IInitialization
	{
        /// <summary>
        /// Количество одновременных ботов
        /// </summary>
		public int CountBot = 5;
        /// <summary>
        /// Коллекция с ботами
        /// </summary>
		public List<Bot> GetBotList { get; } = new List<Bot>(5);

        /// <summary>
        /// Действия при старте объекта
        /// </summary>
        public void OnStart()
		{
			for (var index = 0; index < CountBot; index++)//пробегаемся по всем ботам
			{
				var tempBot = Object.Instantiate(Main.Instance.RefBotPrefab,
					Patrol.GenericPoint(Main.Instance.Player),
					Quaternion.identity);//создаем объект бота на основе префаба, инициализируем фунцию патрулирования из текущей точки,определяем сторону, в которую повернут бот

				tempBot.Agent.avoidancePriority = index;//выставляем приоритет предвижения по навмешу
				tempBot.Target = Main.Instance.Player;//выставляем игрока как цель бота
				// разных противников
				AddBotToList(tempBot);//добавляем бота в список ботов
			}
		}

        /// <summary>
        /// Добавление бота с список ботов
        /// </summary>
        /// <param name="bot">Конкретный экземпляр бота</param>
		private void AddBotToList(Bot bot)
		{
			if (!GetBotList.Contains(bot))//если текущий бот не добавлен в список
			{
				GetBotList.Add(bot);//добавляем бота в список
			}
		}

        /// <summary>
        /// Удаление бота из списка ботов
        /// </summary>
        /// <param name="bot"></param>
		public void RemoveBotToList(Bot bot)
		{
			if (GetBotList.Contains(bot))//если текущий бот добавлен в список
            {
				GetBotList.Remove(bot);//удаляем бота из списка
			}
		}

        /// <summary>
        /// Метод для обновления в каждом кадре
        /// </summary>
        public void OnUpdate()
		{
			if (!IsActive) return;//если бот не активен, то ничего не делаем
			foreach (var bot in GetBotList)//пробегаемся по списку всех ботов в коллекции
			{
				bot.Tick();//вызываем метод Tick
			}
		}
	}
}