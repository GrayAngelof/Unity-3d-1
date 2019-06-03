using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Обнаружение ботом игрока 
    /// </summary>
	[System.Serializable]
	public class Vision
	{
        /// <summary>
        /// Дальность обнаружения
        /// </summary>
		public float ActiveDis = 10;
        /// <summary>
        /// угол обнаружения
        /// </summary>
		public float ActiveAng = 35;

        /// <summary>
        /// Флаг видимости игрока
        /// </summary>
        /// <param name="player">Трансформ игрока</param>
        /// <param name="target"></param>
        /// <returns></returns>
		public bool VisionM(Transform player, Transform target)
		{
			return Dist(player, target) && Angle(player, target) && !CheckBloked(player, target);
		}

		private bool CheckBloked(Transform player, Transform target)
		{
			if (!Physics.Linecast(player.position, target.position, out var hit)) return true;
			return hit.transform != target;
		}

		private bool Angle(Transform player, Transform target)
		{
			var angle = Vector3.Angle(player.forward, target.position - player.position);
			return angle <= ActiveAng;
		}

		private bool Dist(Transform player, Transform target)
		{ 
			var dist = Vector3.Distance(player.position, target.position); // оптимизация
			return dist <= ActiveDis;
		}
	}
}