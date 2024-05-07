using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ProyectoFinal
{
    public static class JsonHelperPersonaje
    {
        public static List<Personaje> FromJson<Personaje>(string json)
        {
            ListaPersonaje<Personaje> listaPersonajes = JsonUtility.FromJson<ListaPersonaje<Personaje>>(json);
            return listaPersonajes.Personajes;
        }
        public static string ToJson<Personaje>(List<Personaje> lista)
        {
            ListaPersonaje<Personaje> listaPersonajes = new ListaPersonaje<Personaje>();
            listaPersonajes.Personajes = lista;
            return JsonUtility.ToJson(listaPersonajes);
        }
        public static string ToJson<Personaje>(List<Personaje> lista, bool prettyPrint)
        {
            ListaPersonaje<Personaje> listaPersonajes = new ListaPersonaje<Personaje>();
            listaPersonajes.Personajes = lista;
            return JsonUtility.ToJson(listaPersonajes, prettyPrint);
        }
        [Serializable]
        private class ListaPersonaje<Personaje>
        {
            public List<Personaje> Personajes;
        }
    }
}
