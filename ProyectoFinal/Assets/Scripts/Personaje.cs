using UnityEngine;
using System;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine.UIElements;

namespace ProyectoFinal
{
    [Serializable]
    public class Personaje
    {
        public int vidas = 5;
        public int monedas = 0;
        public bool bIng = false;
        public bool pIng = false;
        public bool oIng = false;
        public bool bFr = false;
        public bool pFr = false;
        public bool oFr = false;
        public bool bCat = false;
        public bool pCat = false;
        public bool oCat = false;
        public bool leon = false;
        public bool tigre = false;
        public bool panda = false;
        public bool erizo = false;
        public bool unicornio = false;
        public event Action Cambio;
        public event Action<Insgnias> CambioInsginia;
        public string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value != nombre)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }
        public string icon;
        public string Icon
        {
            get { return icon; }
            set { 
                icon = value;
                Cambio?.Invoke();
            }
        }

        public int Monedas { get { return monedas; } set { monedas += value; } }
        public int Vidas { get { return vidas; } set { vidas += value; } }
        public bool BIng { get { return bIng; } set { bIng = value; } }
        public bool PIng { get { return pIng; } set { pIng = value; } }
        public bool OIng { get { return oIng; } set { oIng = value; } }
        public bool BFr { get { return bFr; } set { bFr = value; } }
        public bool PFr { get { return pFr; } set { pFr = value; } }
        public bool Ofr { get { return oFr; } set { oFr = value; } }
        public bool BCat { get { return bCat; } set { bCat = value; } }
        public bool PCat { get { return pCat; } set { pCat = value; } }
        public bool OCat { get { return oCat; } set { oCat = value; } }
        public bool Leon { get { return leon; } set { leon = value; } }
        public bool Tigre { get { return tigre; } set { tigre = value; } }
        public bool Erizo { get { return erizo; } set { erizo = value; } }
        public bool Panda { get { return panda; } set { panda = value; } }
        public bool Unicornio { get { return unicornio; } set { unicornio = value; } }
        public Personaje(string nombre, string icon)
        {
            this.nombre = nombre;
            this.icon = icon;
        }
        public void setInsignia(Insgnias i)
        {
            switch (i)
            {
                case Insgnias.BRING:
                    bIng = true;
                    break;
                case Insgnias.PLING:
                    pIng = true;
                    break;
                case Insgnias.OROING:
                    oIng = true;
                    break;
                case Insgnias.BRFR:
                    bFr = true;
                    break;
                case Insgnias.PLFR:
                    pFr = true;
                    break;
                case Insgnias.OROFR:
                    oFr = true;
                    break;
                case Insgnias.BRCAT:
                    bCat = true;
                    break;
                case Insgnias.PLCAT:
                    pCat = true;
                    break;
                case Insgnias.OROCAT:
                    oCat = true;
                    break;
                default:
                    break;
            }
            CambioInsginia?.Invoke(i);
        }
        public bool getInsignia(Insgnias i)
        {
            switch (i)
            {
                case Insgnias.BRING:
                    return bIng;
                    break;
                case Insgnias.PLING:
                    return pIng ;
                    break;
                case Insgnias.OROING:
                    return oIng;
                    break;
                case Insgnias.BRFR:
                    return bFr ;
                    break;
                case Insgnias.PLFR:
                    return pFr ;
                    break;
                case Insgnias.OROFR:
                    return oFr ;
                    break;
                case Insgnias.BRCAT:
                    return bCat ;
                    break;
                case Insgnias.PLCAT:
                    return pCat ;
                    break;
                case Insgnias.OROCAT:
                    return oCat ;
                    break;
                default:
                    throw new ArgumentException("Insignia no reconocida: " + i);
                    break;
            }
        }
        public void setAnimal(Tienda a)
        {
            switch (a)
            {
                case Tienda.PANDA:
                    panda = true;
                    break;
                case Tienda.LEON:
                    leon = true;
                    break;
                case Tienda.TIGRE:
                    tigre = true;
                    break;
                case Tienda.ERIZO:
                    erizo = true;
                    break;
                case Tienda.UNICORNIO:
                    unicornio = true;
                    break;
                default:
                    break;
            }
        }
        public bool getAnimal(Tienda a)
        {
            switch (a)
            {
                case Tienda.PANDA:
                    return panda;
                    break;
                case Tienda.LEON:
                    return leon;
                    break;
                case Tienda.TIGRE:
                    return tigre;
                    break;
                case Tienda.ERIZO:
                    return erizo;
                    break;
                case Tienda.UNICORNIO:
                    return unicornio;
                    break;
                default:
                    throw new ArgumentException("Animal no reconocida: " + a);
                    break;
            }
        }
    }
}
