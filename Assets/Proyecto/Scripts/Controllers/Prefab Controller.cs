using UnityEngine;
using System.Collections;

namespace Assets.Proyecto.Scripts.Controllers
{
	public class PrefabController : MonoBehaviour
	{
        public void Eliminar()
        {
            Destroy(this.gameObject);
        }
    }
}