using System.Collections.Generic;
using TutanDev.Core.Types;
using UnityEngine;

namespace TutanDev.Core
{
    [CreateAssetMenu(menuName ="Core/AppConfiguration")]
    public class AppConfiguration : ScriptableObject
    {
        public List<BallType> ballTypes;
        public FloatReference ballRadius;
        public ColorReference ballColor;

        public List<string> GetAllTypesNames()
        {
            List<string> result = new List<string>();
            foreach (var type in ballTypes)
            {
                result.Add(type.name);
            }
            return result;
        }

        public BallType GetTypeByName(string name)
        {
            return ballTypes.Find(x => x.name.CompareTo(name) == 0);
        }

        public List<ColorReference> GetAllColors()
        {
            List<ColorReference> result = new List<ColorReference>();
            foreach (var ballType in ballTypes)
            {
                foreach (var color in ballType.colorPallete)
                {
                    if (result.Contains(color)) continue;
                    result.Add(color);
                }            
            }
            return result;
            
        }

        public ColorReference GetColorByName(string name)
        {
            return GetAllColors().Find(x => x.name.CompareTo(name) == 0);
        }
    }
}