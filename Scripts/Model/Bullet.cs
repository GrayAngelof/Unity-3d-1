namespace Geekbrains
{
    /// <summary>
    /// Тип боеприпаса - пуля
    /// </summary>
	public sealed class Bullet : Ammunition
	{
        /// <summary>
        /// Проверка на то, может ли объект с которым столкнулась пуля получить урон
        /// </summary>
        /// <param name="collision">объект столкновения</param>
		private void OnCollisionEnter(UnityEngine.Collision collision)
		{
			// дописать доп урон
			var tempObj = collision.gameObject.GetComponent<ISetDamage>();//получение реализации интерфеса ISetDamage у объекта столкновения

            if (tempObj != null)//если объект реализует интерфейс ISetDamage
            { 
				tempObj.SetDamage(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
					Rigidbody.velocity));//объект столкновение вызывает SetDamage из ISetDamage 
            }

			Destroy(gameObject);//уничтожаем объект
			// Вернуть в пул
		}
	}
}