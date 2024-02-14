using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace TwistyTrails.Assets.scrips
{
   [System.Serializable]
    public class Item
    {
        public string nombre;
        public string descripcion;
        public Sprite imagen; // Si quieres guardar una imagen asociada al objeto
        public int score;
    }


}