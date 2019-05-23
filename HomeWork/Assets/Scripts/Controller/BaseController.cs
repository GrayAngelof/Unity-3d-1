using UnityEngine;

namespace My3dGame
{
    /// <summary>
    /// Базовый класс всех контроллеров
    /// </summary>
	public abstract class BaseController : MonoBehaviour
	{
		public bool IsActive { get; private set; }

		public virtual void On()
		{
			On(null);
		}

		public virtual void On(BaseObjectScene obj)
		{
			IsActive = true;
		}

		public virtual void Off()
		{
			IsActive = false;
		}

		public void Switch()
		{
			if (!IsActive)
			{
				On();
			}
			else
			{
				Off();
			}
		}
	}
}