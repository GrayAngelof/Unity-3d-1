using UnityEngine;

namespace Tests
{
	public class TestA : MonoBehaviour
	{
		public Material Material;

		[Range(0,1)]
		public float A;

		private void OnValidate()
		{
			Material = GetComponent<Renderer>().material;
		}

		private void Update()
		{
			Material.color = new Color(Material.color.r, Material.color.g, Material.color.b, A);
		}
	}
}