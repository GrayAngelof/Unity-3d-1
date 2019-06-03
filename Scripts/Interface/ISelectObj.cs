using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Интерфейс, для выделяемых объектов
    /// </summary>
	public interface ISelectObj
	{
		string GetMessage();
		GameObject Instance { get; }
	}
}