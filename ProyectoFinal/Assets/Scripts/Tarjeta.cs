using ProyectoFinal;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProyectoFinal
{
    public class Tarjeta
    {
        Personaje miPersonaje;
        VisualElement miTarjetaRoot;

        Label nombreText;
        VisualElement imgIcon;
        VisualElement brIng;
        VisualElement plIng;
        VisualElement oroIng;
        VisualElement brFr;
        VisualElement plFr;
        VisualElement oroFr;
        VisualElement brCat;
        VisualElement plCat;
        VisualElement oroCat;

        public Tarjeta(VisualElement tarjetaRoot, Personaje personaje)
        {
            this.miTarjetaRoot = tarjetaRoot;
            this.miPersonaje = personaje;


            nombreText = miTarjetaRoot.Q<Label>("NombreTexto");
            imgIcon = miTarjetaRoot.Q<VisualElement>("Icon");
            brIng = miTarjetaRoot.Q<VisualElement>("bIng");
            plIng = miTarjetaRoot.Q<VisualElement>("pIng");
            oroIng = miTarjetaRoot.Q<VisualElement>("oIng");
            brFr = miTarjetaRoot.Q<VisualElement>("bFr");
            plFr = miTarjetaRoot.Q<VisualElement>("pFr");
            oroFr = miTarjetaRoot.Q<VisualElement>("oFr");
            brCat = miTarjetaRoot.Q<VisualElement>("bCat");
            plCat = miTarjetaRoot.Q<VisualElement>("pCat");
            oroCat = miTarjetaRoot.Q<VisualElement>("oCat");

            miTarjetaRoot.userData = miPersonaje;

            UpdateTarjeta();

            miPersonaje.Cambio += UpdateTarjeta;
            miPersonaje.CambioInsginia += setInsignia;
        }
        void UpdateTarjeta()
        {
            nombreText.text = miPersonaje.Nombre;
            Sprite sprite = Resources.Load<Sprite>("Images/iconos/" + miPersonaje.icon);
            imgIcon.style.backgroundImage = new StyleBackground(sprite);

        }
        public void setInsignia(Insgnias i)
        {
            switch (i)
            {
                case Insgnias.BRING:
                    brIng.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.PLING:
                    plIng.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.OROING:
                    oroIng.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.BRFR:
                    brFr.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.PLFR:
                    plFr.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.OROFR:
                    oroFr.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.BRCAT:
                    brCat.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.PLCAT:
                    plCat.style.display = DisplayStyle.Flex;
                    break;
                case Insgnias.OROCAT:
                    oroCat.style.display = DisplayStyle.Flex;
                    break;
                default:
                    break;
            }
               
        }
    }
}
