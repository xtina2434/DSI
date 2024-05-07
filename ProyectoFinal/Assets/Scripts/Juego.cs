using ProyectoFinal;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.VisualElement;

namespace ProyectoFinal
{
    public class Juego
    {
        VisualElement miJuegoRoot;
        Label text;
        Label numMonedasText;
        VisualElement banderaImg;
        VisualElement cor1;
        VisualElement cor2;
        VisualElement cor3;
        VisualElement cor4;
        VisualElement cor5;
        const int numTotal = 5;
        VisualElement[] items = new VisualElement[numTotal];

        const string spriteName = "Images/iconos/corazon";
        const string spriteEmptyName = "Images/iconos/corazonVacio";

        Sprite spriteHeart = Resources.Load<Sprite>(spriteName);
        Sprite spriteHeartEnpty = Resources.Load<Sprite>(spriteEmptyName);

        public Juego(VisualElement juegoRoot)
        {
            this.miJuegoRoot = juegoRoot;

            text = miJuegoRoot.Q<Label>("DificultadText");
            numMonedasText = miJuegoRoot.Q<Label>("NumMonedas");
            banderaImg = miJuegoRoot.Q<VisualElement>("BanderaJuego");
            cor1 = miJuegoRoot.Q<VisualElement>("cor1");
            cor2 = miJuegoRoot.Q<VisualElement>("cor2");
            cor3 = miJuegoRoot.Q<VisualElement>("cor3");
            cor4 = miJuegoRoot.Q<VisualElement>("cor4");
            cor5 = miJuegoRoot.Q<VisualElement>("cor5");

            items[0] = cor1;
            items[1] = cor2;
            items[2] = cor3;
            items[3] = cor4;
            items[4] = cor5;
        }
        public void UpdateJuego(Dificultad d, Idiomas i, int coins, int vidas)
        {
            text.text = d.ToString();
            numMonedasText.text = coins.ToString();
            Sprite sprite;
            switch (i)
            {
                case Idiomas.INGLES:
                     sprite = Resources.Load<Sprite>("Images/banderas/inglaterra");
                    banderaImg.style.backgroundImage = new StyleBackground(sprite);
                    break;
                case Idiomas.FRANCES:
                     sprite = Resources.Load<Sprite>("Images/banderas/francia");
                    banderaImg.style.backgroundImage = new StyleBackground(sprite);
                    break;
                case Idiomas.CATALAN:
                     sprite = Resources.Load<Sprite>("Images/banderas/catalana");
                    banderaImg.style.backgroundImage = new StyleBackground(sprite);
                    break;
                default:
                    break;
            }
            updateHearts(vidas);
        }
        public void updateHearts(int n)
        {
            for (int i = 0; i < n; i++)
            {
                items[i].style.backgroundImage = new StyleBackground(spriteHeart);
            }
            for (int i = n; i < numTotal; i++)
            {
                items[i].style.backgroundImage = new StyleBackground(spriteHeartEnpty);
            }
        }
        public void updateCoins(int c)
        {
            numMonedasText.text = c.ToString();
        }
    }
}
