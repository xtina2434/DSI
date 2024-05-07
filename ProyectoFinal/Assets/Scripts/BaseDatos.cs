using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System.IO;
using System;
using ProyectoFinal;

namespace ProyectoFinal
{
    public class BaseDatos
    {
        public static List<Personaje> getData()
        {
            List<Personaje> datos = new List<Personaje>();

            //obtener la ruta del archivo JSON
            string filePath = Application.persistentDataPath + "listaPersonajes.json";
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    datos = JsonHelperPersonaje.FromJson<Personaje>(json);
                }
                else
                {
                    Debug.LogWarning("El archivo no existe en la ruta: " + filePath);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
            return datos;
        }
    }
}
