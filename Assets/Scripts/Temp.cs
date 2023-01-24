using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

namespace DefaultNamespace
{
    public class Temp : MonoBehaviour
    {
        private void Start()
        {
            var command = JsonUtility.FromJson<Command>("{\"Name\": \"SetColor\", \"Args\": \"blue\"}");
            Debug.Log($"Name: {command.Name}, Args: {command.Args}");
            switch (command.Args)
            {
                case "blue":
                    break;
                case "green":
                    break;
            }

                
        }
    }

    public class Command
    {
        public string Name;
        public string Args;
    }
}