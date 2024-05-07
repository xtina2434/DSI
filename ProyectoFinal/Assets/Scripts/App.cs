using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

namespace ProyectoFinal
{
    public enum Dificultad { FÁCIL, NORMAL, DIFICIL };
    public enum Menus { OPCIONES, TIENDA, IDIOMA, PERSONAJES, JUEGO, INVENTARIO };
    public enum Idiomas { INGLES, FRANCES, CATALAN };
    public enum Animales { OSO, LOBO, PERRO, GATO, KOALA, LEON, TIGRE, ERIZO, PANDA, UNICORNIO};
    public enum Tienda { LEON, TIGRE, ERIZO, PANDA, UNICORNIO };
    public enum Insgnias { BRING, PLING,OROING,BRFR, PLFR, OROFR, BRCAT, PLCAT, OROCAT};
    public class App : MonoBehaviour
    {
        #region
        //Menu principal
        Button boton_jugar;
        Button boton_opciones;
        Button boton_personajes;
        Button boton_idioma;
        Button boton_tienda;
        Button boton_inventario;
        Button boton_salir;
        VisualElement panelActivo = null;
        #endregion
        #region
        //Menu opciones
        VisualElement menuOpciones;
        Toggle facil_toggle;
        Toggle normal_toggle;
        Toggle dificil_toggle;
        ProgressBar barraDificultad;
        bool firstOpciones = true;
        #endregion
        #region
        //Menu Tienda
        VisualElement menuTienda;
        VisualElement corazonTienda;
        VisualElement leon;
        VisualElement tigre;
        VisualElement erizo;
        VisualElement panda;
        VisualElement unicornio;
        Label monedasTienda;
        #endregion
        #region
        //Menu Idioma
        VisualElement menuIdioma;
        VisualElement fondo;
        Button boton_ING;
        Button boton_FR;
        Button boton_CAT;
        Button botonSelec;
        #endregion
        #region
        //Menu Personajes
        VisualElement menuPersonajes;
        Button boton_crear;
        Button boton_guardar;
        VisualElement trash;
        VisualElement oso;
        VisualElement lobo;
        VisualElement perro;
        VisualElement gato;
        VisualElement koala;
        VisualElement animalSelec;
        VisualElement contenedorPersonajes;
        TextField inputNombre;
        Personaje personajeSeleccionado;
        List<Personaje> listaPersonajes = new List<Personaje>();
        bool firstTime = true;
        #endregion
        #region
        //Menu juego
        VisualElement menuJuego;
        VisualElement contenedorJuego;
        DropdownField dropdownManzana;
        DropdownField dropdownAgua;
        DropdownField dropdownVerde;
        DropdownField[] dropdowns = new DropdownField[3];
        VisualElement juegoFacil;
        VisualElement juegoNormal;
        VisualElement juegoDificil;
        VisualElement juegoActivo = null;
        Label textCerdo;
        Label textAvion;
        Label textLapiz;
        Label textMovil;
        Label textOjo;
        Label textZapatillas;
        TextField uvaInput;
        TextField enfermoInput;
        TextField moradoInput;
        TextField guitarraInput;
        TextField reyInput;
        TextField girasolInput;
        TextField escaladaInput;
        TextField miercolesInput;
        TextField pajaroInput;
        TextField[] inputs = new TextField[9];
        Juego miJuego = null;
        Button checkFacil;
        Button checkNormal;
        Button checkDificil;
        VisualElement BrIng;
        VisualElement PlIng;
        VisualElement OroIng;
        VisualElement BrFr;
        VisualElement PlFr;
        VisualElement OroFr;
        VisualElement BrCat;
        VisualElement PlCat;
        VisualElement OroCat;
        VisualElement insigniaActual = null;
        VisualElement resultado;
        VisualElement[] items = new VisualElement[6];
        VisualElement itemCerdo;
        VisualElement itemLapiz;
        VisualElement itemOjo;
        VisualElement itemMovil;
        VisualElement itemAvion;
        VisualElement itemZapatillas;
        public static VisualElement slotLapiz;
        public static VisualElement slotCerdo;
        public static VisualElement slotOjo;
        public static VisualElement slotMovil;
        public static VisualElement slotAvion;
        public static VisualElement slotZapatillas;
        #endregion
        #region
        //inventario
        VisualElement menuInventario;
        VisualElement contenedorInventario;
        VisualElement tarjetaActual = null;
        const int numAnimales = 10;
        VisualElement[] animales = new VisualElement[numAnimales];
        VisualElement flechaIzq;
        VisualElement flechaDer;
        VisualElement osoInv;
        VisualElement perroInv;
        VisualElement loboInv;
        VisualElement gatoInv;
        VisualElement koalaInv;
        VisualElement leonInv;
        VisualElement tigreInv;
        VisualElement erizoInv;
        VisualElement pandaInv;
        VisualElement unicornioInv;
        Button seleccionarButton;
        int animalActual = 0;
        Label monInvText;
        Label coraInvText;
        #endregion
        Dificultad dificultadActual = Dificultad.FÁCIL;
        Idiomas idiomaActual = Idiomas.INGLES;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            listaPersonajes = BaseDatos.getData();

            #region 
            //menu principal
            boton_jugar = root.Q<Button>("Jugar");
            boton_opciones = root.Q<Button>("Opciones");
            boton_personajes = root.Q<Button>("Personajes");
            boton_idioma = root.Q<Button>("Idioma");
            boton_tienda = root.Q<Button>("Tienda");
            boton_salir = root.Q<Button>("Salir");
            boton_inventario = root.Q<Button>("Inventario");
            #endregion
            #region
            //menu opciones
            menuOpciones = root.Q<VisualElement>("MenuOpciones");
            facil_toggle = root.Q<Toggle>("facil");
            normal_toggle = root.Q<Toggle>("normal");
            dificil_toggle = root.Q<Toggle>("dificil");
            barraDificultad = root.Q<ProgressBar>("barra");
            #endregion
            #region
            //tienda
            menuTienda = root.Q<VisualElement>("MenuTienda");
            corazonTienda = root.Q<VisualElement>("corazonTienda");
            leon = root.Q<VisualElement>("leon");
            tigre = root.Q<VisualElement>("tigre");
            erizo = root.Q<VisualElement>("erizo");
            panda = root.Q<VisualElement>("panda");
            unicornio = root.Q<VisualElement>("unicornio");
            monedasTienda = root.Q<Label>("monedasTienda");
            #endregion
            #region
            //idioma
            menuIdioma = root.Q<VisualElement>("MenuIdioma");
            boton_ING = root.Q<Button>("inglaterra_boton");
            boton_FR = root.Q<Button>("francia_boton");
            boton_CAT = root.Q<Button>("catalan_boton");
            botonSelec = boton_ING;
            fondo = root.Q<VisualElement>("fondoMenuIdiomas");
            #endregion
            #region
            //personajes
            menuPersonajes = root.Q<VisualElement>("MenuPersonajes");
            boton_crear = root.Q<Button>("botonCrear");
            boton_guardar = root.Q<Button>("botonGuardar");
            trash = root.Q<VisualElement>("trash");
            oso = root.Q<VisualElement>("oso");
            perro = root.Q<VisualElement>("perro");
            gato = root.Q<VisualElement>("gato");
            lobo = root.Q<VisualElement>("lobo");
            koala = root.Q<VisualElement>("koala");
            animalSelec = oso;
            contenedorPersonajes = root.Q<VisualElement>("derPersonajes");
            inputNombre = root.Q<TextField>("InputNombre");
            #endregion
            #region
            //jugar
            menuJuego = root.Q<VisualElement>("MenuJuego");
            contenedorJuego = root.Q<VisualElement>("ContenedorJuego");

            dropdownManzana = root.Q<DropdownField>("DropdownManzana");
            dropdownAgua = root.Q<DropdownField>("DropdownAgua");
            dropdownVerde = root.Q<DropdownField>("DropdownVerde");
            dropdowns[0] = dropdownManzana;
            dropdowns[1] = dropdownAgua;
            dropdowns[2] = dropdownVerde;

            juegoFacil = root.Q<VisualElement>("JuegoFacil");
            juegoNormal = root.Q<VisualElement>("JuegoNormal");
            juegoDificil = root.Q<VisualElement>("JuegoDificil");

            checkFacil = root.Q<Button>("checkFacil");
            checkNormal = root.Q<Button>("checkNormal");
            checkDificil = root.Q<Button>("checkDificil");

            uvaInput = root.Q<TextField>("uvaInput");
            enfermoInput = root.Q<TextField>("enfermoInput");
            moradoInput = root.Q<TextField>("moradoInput");
            guitarraInput = root.Q<TextField>("guitarraInput"); ;
            reyInput = root.Q<TextField>("reyInput");
            girasolInput = root.Q<TextField>("girasolInput"); ;
            escaladaInput = root.Q<TextField>("escaladaInput");
            miercolesInput = root.Q<TextField>("miercolesInput");
            pajaroInput = root.Q<TextField>("pajaroInput");
            inputs[0] = uvaInput;
            inputs[1] = enfermoInput;
            inputs[2] = moradoInput;
            inputs[3] = guitarraInput;
            inputs[4] = reyInput;
            inputs[5] = girasolInput;
            inputs[6] = escaladaInput;
            inputs[7] = miercolesInput;
            inputs[8] = pajaroInput;
            
            BrIng = root.Q<VisualElement>("BrIng");
            PlIng = root.Q<VisualElement>("PlIng");
            OroIng = root.Q<VisualElement>("OroIng");
            BrFr = root.Q<VisualElement>("BrFr");
            PlFr = root.Q<VisualElement>("PlFr");
            OroFr = root.Q<VisualElement>("OroFr");
            BrCat = root.Q<VisualElement>("BrCat");
            PlCat = root.Q<VisualElement>("PlCat");
            OroCat = root.Q<VisualElement>("OroCat");
            resultado = root.Q<VisualElement>("Resultado");

            textAvion = root.Q<Label>("PalabraAvion");
            textCerdo = root.Q<Label>("PalabraCerdo");
            textLapiz = root.Q<Label>("PalabraLapiz");
            textMovil = root.Q<Label>("PalabraMovil");
            textOjo = root.Q<Label>("PalabraOjo");
            textZapatillas = root.Q<Label>("PalabraZapatos");
            itemCerdo = root.Q<VisualElement>("itemCerdo");
            itemLapiz = root.Q<VisualElement>("itemLapiz");
            itemOjo = root.Q<VisualElement>("itemOjo");
            itemMovil = root.Q<VisualElement>("itemMovil");
            itemAvion = root.Q<VisualElement>("itemAvion");
            itemZapatillas = root.Q<VisualElement>("itemZapatillas");
            slotCerdo = root.Q<VisualElement>("slotCerdo");
            slotLapiz = root.Q<VisualElement>("slotLapiz");
            slotOjo = root.Q<VisualElement>("slotOjo");
            slotMovil = root.Q<VisualElement>("slotMovil");
            slotAvion = root.Q<VisualElement>("slotAvion");
            slotZapatillas = root.Q<VisualElement>("slotZapatillas");
            items[0] = itemCerdo;
            items[1] = itemLapiz;
            items[2] = itemOjo;
            items[3] = itemMovil;
            items[4] = itemAvion;
            items[5] = itemZapatillas;
            for (int i = 0; i < items.Length; i++) items[i].AddManipulator(new Drag());
            #endregion
            #region
            //menu inventario
            menuInventario = root.Q<VisualElement>("MenuInventario");
            contenedorInventario = root.Q<VisualElement>("ContenedorInventario");
            flechaDer = root.Q<VisualElement>("flechaDer");
            flechaIzq = root.Q<VisualElement>("flechaIzq");
            osoInv = root.Q<VisualElement>("osoInv");
            perroInv = root.Q<VisualElement>("perroInv");
            loboInv = root.Q<VisualElement>("loboInv");
            gatoInv = root.Q<VisualElement>("gatoInv");
            koalaInv = root.Q<VisualElement>("koalaInv");
            leonInv = root.Q<VisualElement>("leonInv");
            tigreInv = root.Q<VisualElement>("tigreInv");
            erizoInv = root.Q<VisualElement>("erizoInv");
            pandaInv = root.Q<VisualElement>("pandaInv");
            unicornioInv = root.Q<VisualElement>("unicornioInv");
            seleccionarButton = root.Q<Button>("botonSeleccionar");
            animales[0] = osoInv;
            animales[1] = perroInv;
            animales[2] = loboInv;
            animales[3] = gatoInv;
            animales[4] = koalaInv;
            animales[5] = leonInv;
            animales[6] = tigreInv;
            animales[7] = erizoInv;
            animales[8] = pandaInv;
            animales[9] = unicornioInv;
            monInvText = root.Q<Label>("monInvText");
            coraInvText = root.Q<Label>("coraInvText");
            #endregion
            #region
            //menu
            boton_opciones.RegisterCallback<ClickEvent>(evt => EnterMenu(Menus.OPCIONES));
            boton_tienda.RegisterCallback<ClickEvent>(evt => EnterMenu(Menus.TIENDA));
            boton_idioma.RegisterCallback<ClickEvent>(evt => EnterMenu(Menus.IDIOMA));
            boton_personajes.RegisterCallback<ClickEvent>(evt => EnterMenu(Menus.PERSONAJES));
            boton_jugar.RegisterCallback<ClickEvent>(evt => EnterMenu(Menus.JUEGO));
            boton_inventario.RegisterCallback<ClickEvent>(evt => EnterMenu(Menus.INVENTARIO));
            boton_salir.RegisterCallback<ClickEvent>(Exit);
            #endregion
            #region
            //menu opciones
            facil_toggle.RegisterCallback<ClickEvent, int>(SeleccionarDificultad, 20);
            normal_toggle.RegisterCallback<ClickEvent, int>(SeleccionarDificultad, 50);
            dificil_toggle.RegisterCallback<ClickEvent, int>(SeleccionarDificultad, 90);
            #endregion
            #region
            //menu idiomas
            boton_ING.RegisterCallback<ClickEvent>(evt => SeleccionarIdioma(Idiomas.INGLES));
            boton_FR.RegisterCallback<ClickEvent>(evt => SeleccionarIdioma(Idiomas.FRANCES));
            boton_CAT.RegisterCallback<ClickEvent>(evt => SeleccionarIdioma(Idiomas.CATALAN));
            boton_ING.RegisterCallback<MouseEnterEvent>(evt => CambiarFondo(Idiomas.INGLES));
            boton_FR.RegisterCallback<MouseEnterEvent>(evt => CambiarFondo(Idiomas.FRANCES));
            boton_CAT.RegisterCallback<MouseEnterEvent>(evt => CambiarFondo(Idiomas.CATALAN));
            #endregion
            #region
            //menu personajes
            boton_crear.RegisterCallback<ClickEvent>(CrearTarjeta);
            boton_guardar.RegisterCallback<ClickEvent>(Guardar);
            trash.RegisterCallback<ClickEvent>(evt => EliminarPersonaje(personajeSeleccionado));
            oso.RegisterCallback<ClickEvent>(evt => SeleccionarIcon(Animales.OSO));
            perro.RegisterCallback<ClickEvent>(evt => SeleccionarIcon(Animales.PERRO));
            gato.RegisterCallback<ClickEvent>(evt => SeleccionarIcon(Animales.GATO));
            lobo.RegisterCallback<ClickEvent>(evt => SeleccionarIcon(Animales.LOBO));
            koala.RegisterCallback<ClickEvent>(evt => SeleccionarIcon(Animales.KOALA));
            contenedorPersonajes.RegisterCallback<ClickEvent>(SeleccionarTarjeta);
            #endregion
            #region
            //menu juego
            checkFacil.RegisterCallback<ClickEvent>(CheckJuegoFacil);
            checkNormal.RegisterCallback<ClickEvent>(CheckJuegoNormal);
            checkDificil.RegisterCallback<ClickEvent>(CheckJuegoDificl);
            #endregion
            #region
            //tienda
            corazonTienda.RegisterCallback<ClickEvent>(ComprarCorazon);
            leon.RegisterCallback<ClickEvent>(evt => ComprarAnimal(Tienda.LEON));
            tigre.RegisterCallback<ClickEvent>(evt => ComprarAnimal(Tienda.TIGRE));
            erizo.RegisterCallback<ClickEvent>(evt => ComprarAnimal(Tienda.ERIZO));
            panda.RegisterCallback<ClickEvent>(evt => ComprarAnimal(Tienda.PANDA));
            unicornio.RegisterCallback<ClickEvent>(evt => ComprarAnimal(Tienda.UNICORNIO));
            #endregion
            #region
            //inventario
            flechaDer.RegisterCallback<ClickEvent>(DerAnimal);
            flechaIzq.RegisterCallback<ClickEvent>(IzqAnimal);
            seleccionarButton.RegisterCallback<ClickEvent>(evt => CambiarAnimalIcon(animalActual));
            #endregion
        }
        void ReadSaveJSON()
        {
            string listaPersonajesToJson = JsonHelperPersonaje.ToJson(listaPersonajes, true);

            for (int i = 0; i < listaPersonajes.Count; i++)
            {
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                VisualElement tarjetaPlantilla = plantilla.Instantiate();

                contenedorPersonajes.Add(tarjetaPlantilla);
                SetTarjetasNaranjas();
                SetColorTarjetaSeleccionada(tarjetaPlantilla);
                Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, listaPersonajes[i]);
                personajeSeleccionado = listaPersonajes[i];
                SetInsgniasTarjetas(tarjeta);
            }
        }
        void EnterMenu(Menus menu)
        {
            if (panelActivo != null)
            {
                panelActivo.style.display = DisplayStyle.None;
            }
            switch (menu)
            {
                case Menus.OPCIONES:
                    if (firstOpciones)
                    {
                        facil_toggle.value = true;
                        normal_toggle.value = false;
                        dificil_toggle.value = false;
                        firstOpciones = false;
                        barraDificultad.value = 20;
                    }
                    panelActivo = menuOpciones;
                    break;
                case Menus.TIENDA:
                    panelActivo = menuTienda;
                    monedasTienda.text = personajeSeleccionado.Monedas.ToString();
                    break;
                case Menus.IDIOMA:
                    panelActivo = menuIdioma;
                    botonSelec.AddToClassList("elementoSeleccionado");
                    break;
                case Menus.PERSONAJES:
                    panelActivo = menuPersonajes;
                    if (firstTime)
                    {
                        firstTime = false;
                        ReadSaveJSON();
                    }
                    break;
                case Menus.JUEGO:
                    if (personajeSeleccionado != null && personajeSeleccionado.Vidas > 0)
                    {
                        panelActivo = menuJuego;
                        CrearJuego();
                    }
                    break;
                case Menus.INVENTARIO:
                    
                    if (personajeSeleccionado != null)
                    {
                        panelActivo = menuInventario;
                        CrearInventario();
                        animales[animalActual].style.display = DisplayStyle.Flex;
                    }
                    break;
                default:
                    break;
            }
            if(panelActivo != null) panelActivo.style.display = DisplayStyle.Flex;
        }
        void SeleccionarDificultad(ClickEvent evento, int value)
        {
            switch (value) {

                case 20:
                    dificultadActual = Dificultad.FÁCIL;
                    facil_toggle.value = true;
                    normal_toggle.value = false;
                    dificil_toggle.value = false;
                    break;
                case 50:
                    dificultadActual = Dificultad.NORMAL;
                    facil_toggle.value = false;
                    normal_toggle.value = true;
                    dificil_toggle.value = false;
                    break;
                case 90:
                    dificultadActual = Dificultad.DIFICIL;
                    facil_toggle.value = false;
                    normal_toggle.value = false;
                    dificil_toggle.value = true;
                    break;
            }
            barraDificultad.value = value;
        }
        void SeleccionarIdioma(Idiomas idioma)
        {
            botonSelec.RemoveFromClassList("elementoSeleccionado");
            idiomaActual = idioma;
            switch (idioma)
            {
                case Idiomas.INGLES:
                    botonSelec = boton_ING;
                    break;
                case Idiomas.FRANCES:
                    botonSelec = boton_FR;
                    break;
                case Idiomas.CATALAN:
                    botonSelec = boton_CAT;
                    break;
                default:
                    break;
            }
            botonSelec.AddToClassList("elementoSeleccionado");
        }
        void CambiarFondo(Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.INGLES:
                    fondo.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Images/fondos/londres"));
                    break;
                case Idiomas.FRANCES:
                    fondo.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Images/fondos/paris"));
                    break;
                case Idiomas.CATALAN:
                    fondo.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Images/fondos/barcelona"));
                    break;
                default:
                    break;
            }
        }
        void CrearTarjeta(ClickEvent evento)
        {
            List<VisualElement> listaTarjetas = contenedorPersonajes.Children().ToList();
            if (listaTarjetas.Count < 9)
            {
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                VisualElement tarjetaPlantilla = plantilla.Instantiate();

                contenedorPersonajes.Add(tarjetaPlantilla);
                SetTarjetasNaranjas();
                SetColorTarjetaSeleccionada(tarjetaPlantilla);

                Personaje personaje = new Personaje(inputNombre.value, animalSelec.name);
                Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, personaje);

                personajeSeleccionado = personaje;

                listaPersonajes.Add(personaje);
                string listaToJson = JsonHelperPersonaje.ToJson(listaPersonajes, true);
            }
        }
        void SeleccionarTarjeta(ClickEvent evento)
        {
            VisualElement tarjetaSeleccionada = evento.target as VisualElement;
            personajeSeleccionado = tarjetaSeleccionada.userData as Personaje;

            SetTarjetasNaranjas();
            SetColorTarjetaSeleccionada(tarjetaSeleccionada);
        }
        void Guardar(ClickEvent evento)
        {
            //convertir a lista de personajes a JSON
            string listaPersonajesToJson = JsonHelperPersonaje.ToJson(listaPersonajes, true);
            //especificar la ruta donde guardara
            string filePath = Application.persistentDataPath + "listaPersonajes.json";
            try
            {
                System.IO.File.WriteAllText(filePath, listaPersonajesToJson);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        void EliminarPersonaje(Personaje p)
        {
            listaPersonajes.Remove(p);

            VisualElement t = contenedorPersonajes.Children().FirstOrDefault(t => t.userData == p);

            if (t != null)
            {
                contenedorPersonajes.Remove(t);
                Limpiar();
            }
        }
        void Limpiar()
        {
            //convertir a lista de personajes a JSON
            string listaPersonajesToJson = JsonHelperPersonaje.ToJson(listaPersonajes, true);
            //especificar la ruta donde guardara
            string filePath = Application.persistentDataPath + "listaPersonajes.json";
            try
            {
                System.IO.File.WriteAllText(filePath, listaPersonajesToJson);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        void SetTarjetasNaranjas()
        {
            Color miNaranja = new Color(164f / 255f, 51f / 255f, 0f, 1f);
            List<VisualElement> listaTarjetas = contenedorPersonajes.Children().ToList();
            listaTarjetas.ForEach(elem =>
            {
                VisualElement tarjeta = elem.Q("Tarjeta");
                SetColorBorder(tarjeta, miNaranja);
            });
        }
        void SetColorTarjetaSeleccionada(VisualElement tarjetaSeleccionada)
        {
            VisualElement tarjeta = tarjetaSeleccionada.Q("Tarjeta");
            SetColorBorder(tarjeta, Color.black);
        }
        void SeleccionarIcon(Animales animal)
        {
            animalSelec.RemoveFromClassList("elementoSeleccionado");
            switch (animal)
            {
                case Animales.OSO:
                    animalSelec = oso;
                    break;
                case Animales.PERRO:
                    animalSelec = perro;
                    break;
                case Animales.GATO:
                    animalSelec = gato;
                    break;
                case Animales.LOBO:
                    animalSelec = lobo;
                    break;
                case Animales.KOALA:
                    animalSelec = koala;
                    break;
                default:
                    break;
            }
            animalSelec.AddToClassList("elementoSeleccionado");
        }
        void Exit(ClickEvent evento)
        {
            Application.Quit();
        }
        void CrearJuego()
        {
            resultado.style.display = DisplayStyle.None;
            if(insigniaActual != null) insigniaActual.style.display = DisplayStyle.None;

            if (miJuego == null)
            {
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Juego");
                VisualElement juegoPlantilla = plantilla.Instantiate();

                contenedorJuego.Add(juegoPlantilla);
                miJuego = new Juego(juegoPlantilla);
            }
            miJuego.UpdateJuego(dificultadActual, idiomaActual, personajeSeleccionado.Monedas, personajeSeleccionado.Vidas);

            if (juegoActivo != null)
            {
                juegoActivo.style.display = DisplayStyle.None;
            }
            switch (dificultadActual)
            {
                case Dificultad.FÁCIL:
                    juegoActivo = juegoFacil;
                    JuegoFacil();
                    break;
                case Dificultad.NORMAL:
                    juegoActivo = juegoNormal;
                    JuegoNormal();
                    break;
                case Dificultad.DIFICIL:
                    juegoActivo = juegoDificil;
                    JuegoDificil();
                    break;
                default:
                    break;
            }
            juegoActivo.style.display = DisplayStyle.Flex;
        }
        void JuegoFacil()
        {
            for(int i=0; i<dropdowns.Length; i++)
            {
                dropdowns[i].choices.Clear();
                dropdowns[i].index = -1;
                dropdowns[i].style.backgroundColor = Color.clear;
            }
            switch (idiomaActual)
            {
                case Idiomas.INGLES:
                    dropdownManzana.choices.Add("Apple");
                    dropdownManzana.choices.Add("Watermelon");
                    dropdownManzana.choices.Add("Strawberry");

                    dropdownAgua.choices.Add("Milk");
                    dropdownAgua.choices.Add("Juice");
                    dropdownAgua.choices.Add("Water");

                    dropdownVerde.choices.Add("Blue");
                    dropdownVerde.choices.Add("Green");
                    dropdownVerde.choices.Add("Red");
                    break;
                case Idiomas.FRANCES:
                    dropdownManzana.choices.Add("Pomme");
                    dropdownManzana.choices.Add("Poire");
                    dropdownManzana.choices.Add("Fraise");

                    dropdownAgua.choices.Add("Lait");
                    dropdownAgua.choices.Add("Jus");
                    dropdownAgua.choices.Add("Eau");

                    dropdownVerde.choices.Add("Bleu");
                    dropdownVerde.choices.Add("Vert");
                    dropdownVerde.choices.Add("Rouge");
                    break;
                case Idiomas.CATALAN:
                    dropdownManzana.choices.Add("Poma");
                    dropdownManzana.choices.Add("Cirera");
                    dropdownManzana.choices.Add("Maduixa");

                    dropdownAgua.choices.Add("Llet");
                    dropdownAgua.choices.Add("Suc");
                    dropdownAgua.choices.Add("Aigua");

                    dropdownVerde.choices.Add("Blau");
                    dropdownVerde.choices.Add("Verd");
                    dropdownVerde.choices.Add("Vermell");
                    break;
                default:
                    break;
            }
        }
        void JuegoNormal()
        {
            for (int i = 0; i < items.Length; i++) items[i].RemoveFromClassList("botonRojoNormal");
            for (int i = 0; i < items.Length; i++) items[i].style.top = 300;
            items[0].style.left = 45;
            items[1].style.left = 215;
            items[2].style.left = 390;
            items[3].style.left = 555;
            items[4].style.left = 725;
            items[5].style.left = 895;

            switch (idiomaActual)
            {
                case Idiomas.INGLES:
                    textAvion.text = "PLANE";
                    textCerdo.text = "PIG";
                    textLapiz.text = "PENCIL";
                    textMovil.text = "PHONE";
                    textOjo.text = "EYE";
                    textZapatillas.text = "SHOES";
                    break;
                case Idiomas.FRANCES:
                    textAvion.text = "AVION";
                    textCerdo.text = "PORC";
                    textLapiz.text = "CRAYON";
                    textMovil.text = "MOBILE";
                    textOjo.text = "OEIL";
                    textZapatillas.text = "CHAUSSURES";
                    break;
                case Idiomas.CATALAN:
                    textAvion.text = "AVIO";
                    textCerdo.text = "PORC";
                    textLapiz.text = "LLAPIS";
                    textMovil.text = "MÒBIL";
                    textOjo.text = "ULL";
                    textZapatillas.text = "SABATES";
                    break;
                default:
                    break;
            }
        }
        void JuegoDificil()
        {
            for(int i=0; i <inputs.Length; i++) inputs[i].style.color = Color.black;
            uvaInput.value = "uvas";
            enfermoInput.value = "enfermo";
            moradoInput.value = "morado";
            guitarraInput.value = "guitarra";
            reyInput.value = "rey";
            girasolInput.value = "girasol";
            escaladaInput.value = "escalar";
            miercolesInput.value = "Miércoles";
            pajaroInput.value = "pájaro";
        }
        void CheckJuegoFacil(ClickEvent evento)
        {

            int cont = 0;
            if (dropdownManzana.index != 0)
            {
                dropdownManzana.style.backgroundColor = Color.red;
                cont++;
            }
            else
            {
                dropdownManzana.style.backgroundColor = Color.green;
            }
            if (dropdownAgua.index != 2)
            {
                dropdownAgua.style.backgroundColor = Color.red;
                cont++;
            }
            else
            {
                dropdownAgua.style.backgroundColor = Color.green;
            }
            if (dropdownVerde.index != 1)
            {
                dropdownVerde.style.backgroundColor = Color.red;
                cont++;
            }
            else
            {
                dropdownVerde.style.backgroundColor = Color.green;
            }
            if (cont == 0)
            {
                switch (idiomaActual)
                {
                    case Idiomas.INGLES:
                        insigniaActual = BrIng;
                        personajeSeleccionado.setInsignia(Insgnias.BRING);
                        break;
                    case Idiomas.FRANCES:
                        insigniaActual = BrFr;
                        personajeSeleccionado.setInsignia(Insgnias.BRFR);
                        break;
                    case Idiomas.CATALAN:
                        insigniaActual = BrCat;
                        personajeSeleccionado.setInsignia(Insgnias.BRCAT);
                        break;
                    default:
                        break;

                }
                insigniaActual.style.display = DisplayStyle.Flex;
                resultado.style.display = DisplayStyle.Flex;
                personajeSeleccionado.Monedas = 3;
                miJuego.updateCoins(personajeSeleccionado.Monedas);
            }
            else
            {
                personajeSeleccionado.Vidas = -1;
                miJuego.updateHearts(personajeSeleccionado.Vidas);
            }
        }
        void CheckJuegoNormal(ClickEvent evento)
        {
            int cont = 0;
            if(itemCerdo.layout.position != slotCerdo.layout.position)
            {
                itemCerdo.AddToClassList("botonRojoNormal");
                cont++;
            }
            if (itemAvion.layout.position != slotAvion.layout.position)
            {
                itemAvion.AddToClassList("botonRojoNormal");
                cont++;
            }
            if (itemLapiz.layout.position != slotLapiz.layout.position)
            {
                itemLapiz.AddToClassList("botonRojoNormal");
                cont++;
            }
            if (itemOjo.layout.position != slotOjo.layout.position)
            {
                itemOjo.AddToClassList("botonRojoNormal");
                cont++;
            }
            if (itemZapatillas.layout.position != slotZapatillas.layout.position)
            {
                itemZapatillas.AddToClassList("botonRojoNormal");
                cont++;
            }
            if (itemMovil.layout.position != slotMovil.layout.position)
            {
                itemMovil.AddToClassList("botonRojoNormal");
                cont++;
            }

            if(cont == 0)
            {
                resultado.style.display = DisplayStyle.Flex;
                switch (idiomaActual)
                {
                    case Idiomas.INGLES:
                        insigniaActual = PlIng;
                        personajeSeleccionado.setInsignia(Insgnias.PLING);
                        break;
                    case Idiomas.FRANCES:
                        insigniaActual = PlFr;
                        personajeSeleccionado.setInsignia(Insgnias.PLFR);
                        break;
                    case Idiomas.CATALAN:
                        insigniaActual = PlCat;
                        personajeSeleccionado.setInsignia(Insgnias.PLCAT);
                        break;
                    default: 
                        break;
                }
                insigniaActual.style.display = DisplayStyle.Flex;
                personajeSeleccionado.Monedas = 7;
                miJuego.updateCoins(personajeSeleccionado.Monedas);
            }
            else if (cont <= 3)
            {
                personajeSeleccionado.Vidas = -1;
                miJuego.updateHearts(personajeSeleccionado.Vidas);
            }
            else
            {
                personajeSeleccionado.Vidas = -2;
                miJuego.updateHearts(personajeSeleccionado.Vidas);
            }
        }
        void CheckJuegoDificl(ClickEvent evento)
        {
            int cont = 0;
            switch (idiomaActual)
            {
                case Idiomas.INGLES:
                    if (uvaInput.text != "grapes")
                    {
                        uvaInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        uvaInput.style.color = Color.green;
                    }
                    if (enfermoInput.text != "sick" && enfermoInput.text != "ill")
                    {
                        enfermoInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        enfermoInput.style.color = Color.green;
                    }
                    if (moradoInput.text != "purple")
                    {
                        moradoInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        moradoInput.style.color = Color.green;
                    }
                    if (guitarraInput.text != "guitar")
                    {
                        guitarraInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        guitarraInput.style.color = Color.green;
                    }
                    if (reyInput.text != "king")
                    {
                        reyInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        reyInput.style.color = Color.green;
                    }
                    if (girasolInput.text != "sunflower")
                    {
                        girasolInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        girasolInput.style.color = Color.green;
                    }
                    if (escaladaInput.text != "climb" && escaladaInput.text != "climbing" && escaladaInput.text != "to climb")
                    {
                        escaladaInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        escaladaInput.style.color = Color.green;
                    }
                    if (miercolesInput.text != "wednesday")
                    {
                        miercolesInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        miercolesInput.style.color = Color.green;
                    }
                    if (pajaroInput.text != "bird")
                    {
                        pajaroInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        pajaroInput.style.color = Color.green;
                    }
                    break;
                case Idiomas.FRANCES:
                    if (uvaInput.text != "raisins")
                    {
                        uvaInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        uvaInput.style.color = Color.green;
                    }
                    if (enfermoInput.text != "malade")
                    {
                        enfermoInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        enfermoInput.style.color = Color.green;
                    }
                    if (moradoInput.text != "violet")
                    {
                        moradoInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        moradoInput.style.color = Color.green;
                    }
                    if (guitarraInput.text != "guitare")
                    {
                        guitarraInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        guitarraInput.style.color = Color.green;
                    }
                    if (reyInput.text != "roi")
                    {
                        reyInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        reyInput.style.color = Color.green;
                    }
                    if (girasolInput.text != "tournesol")
                    {
                        girasolInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        girasolInput.style.color = Color.green;
                    }
                    if (escaladaInput.text != "escalader")
                    {
                        escaladaInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        escaladaInput.style.color = Color.green;
                    }
                    if (miercolesInput.text != "mercredi")
                    {
                        miercolesInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        miercolesInput.style.color = Color.green;
                    }
                    if (pajaroInput.text != "oiseau")
                    {
                        pajaroInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        pajaroInput.style.color = Color.green;
                    }
                    break;
                case Idiomas.CATALAN:
                    if (uvaInput.text != "raims")
                    {
                        uvaInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        uvaInput.style.color = Color.green;
                    }
                    if (enfermoInput.text != "malalt")
                    {
                        enfermoInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        enfermoInput.style.color = Color.green;
                    }
                    if (moradoInput.text != "morat")
                    {
                        moradoInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        moradoInput.style.color = Color.green;
                    }
                    if (guitarraInput.text != "guitarra")
                    {
                        guitarraInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        guitarraInput.style.color = Color.green;
                    }
                    if (reyInput.text != "rei")
                    {
                        reyInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        reyInput.style.color = Color.green;
                    }
                    if (girasolInput.text != "gira-sol")
                    {
                        girasolInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        girasolInput.style.color = Color.green;
                    }
                    if (escaladaInput.text != "escalar")
                    {
                        escaladaInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        escaladaInput.style.color = Color.green;
                    }
                    if (miercolesInput.text != "dimecres")
                    {
                        miercolesInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        miercolesInput.style.color = Color.green;
                    }
                    if (pajaroInput.text != "ocell")
                    {
                        pajaroInput.style.color = Color.red;
                        cont++;
                    }
                    else
                    {
                        pajaroInput.style.color = Color.green;
                    }
                    break;
                default:
                    break;
            }
            if (cont == 0)
            {
                resultado.style.display = DisplayStyle.Flex;
                switch (idiomaActual)
                {
                    case Idiomas.INGLES:
                        insigniaActual = OroIng;
                        personajeSeleccionado.setInsignia(Insgnias.OROING);
                        break;
                    case Idiomas.FRANCES:
                        insigniaActual = OroFr;
                        personajeSeleccionado.setInsignia(Insgnias.OROFR);
                        break;
                    case Idiomas.CATALAN:
                        insigniaActual = OroCat;
                        personajeSeleccionado.setInsignia(Insgnias.OROCAT);
                        break;
                    default:
                        break;
                }
                insigniaActual.style.display = DisplayStyle.Flex;
                personajeSeleccionado.Monedas = 10;
                miJuego.updateCoins(personajeSeleccionado.Monedas);
            }
            else if (cont <= 3)
            {
                personajeSeleccionado.Vidas = -1;
                miJuego.updateHearts(personajeSeleccionado.Vidas);
            }
            else if (cont <= 6)
            {
                personajeSeleccionado.Vidas = -2;
                miJuego.updateHearts(personajeSeleccionado.Vidas);
            }
            else if (cont > 6)
            {
                personajeSeleccionado.Vidas = -3;
                miJuego.updateHearts(personajeSeleccionado.Vidas);
            }
        }
        private void SetColorBorder(VisualElement vE, Color color)
        {
            if(vE != null)
            {
                vE.style.borderTopColor = color;
                vE.style.borderBottomColor = color;
                vE.style.borderRightColor = color;
                vE.style.borderLeftColor = color;
            }
        }
        void ComprarCorazon(ClickEvent evento)
        {
            if (personajeSeleccionado.Monedas >= 10 && personajeSeleccionado.Vidas < 5)
            {
                personajeSeleccionado.Monedas = -10;
                monedasTienda.text = personajeSeleccionado.Monedas.ToString();
                personajeSeleccionado.Vidas = 1;
            }
        }
        void ComprarAnimal(Tienda animalTienda)
        {
            switch (animalTienda)
            {
                case Tienda.LEON:
                    if (personajeSeleccionado.Monedas >= 15 && !personajeSeleccionado.getAnimal(animalTienda))
                    {
                        personajeSeleccionado.Monedas = -15;
                        personajeSeleccionado.setAnimal(animalTienda);
                        personajeSeleccionado.Icon = "leon";
                    }
                    break;
                case Tienda.TIGRE:
                    if (personajeSeleccionado.Monedas >= 15 && !personajeSeleccionado.getAnimal(animalTienda))
                    {
                        personajeSeleccionado.Monedas = -15;
                        personajeSeleccionado.setAnimal(animalTienda);
                        personajeSeleccionado.Icon = "tigre";
                    }
                    break;
                case Tienda.ERIZO:
                    if (personajeSeleccionado.Monedas >= 20 && !personajeSeleccionado.getAnimal(animalTienda))
                    {
                        personajeSeleccionado.Monedas = -20;
                        personajeSeleccionado.setAnimal(animalTienda);
                        personajeSeleccionado.Icon = "erizo";
                    }
                    break;
                case Tienda.PANDA:
                    if (personajeSeleccionado.Monedas >= 30 && !personajeSeleccionado.getAnimal(animalTienda))
                    {
                        personajeSeleccionado.Monedas = -30;
                        personajeSeleccionado.setAnimal(animalTienda);
                        personajeSeleccionado.Icon = "panda";
                    }
                    break;
                case Tienda.UNICORNIO:
                    if (personajeSeleccionado.Monedas >= 50 && !personajeSeleccionado.getAnimal(animalTienda))
                    {
                        personajeSeleccionado.Monedas = -50;
                        personajeSeleccionado.setAnimal(animalTienda);
                        personajeSeleccionado.Icon = "unicornio";
                    }
                    break;
                default:
                    break;
            }
            monedasTienda.text = personajeSeleccionado.Monedas.ToString();
        }
        void CrearInventario()
        {
            if (tarjetaActual != null) contenedorInventario.Remove(tarjetaActual);
            VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
            VisualElement tarjetaPlantilla = plantilla.Instantiate();
            tarjetaActual = tarjetaPlantilla;
            contenedorInventario.Add(tarjetaPlantilla);

            Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, personajeSeleccionado);
            SetInsgniasTarjetas(tarjeta);

            coraInvText.text = personajeSeleccionado.Vidas.ToString();
            monInvText.text = personajeSeleccionado.Monedas.ToString();
            animalActual = 0;
            EsconderAnimales();
            SetAnimalesDisponibles();
        }
        void SetInsgniasTarjetas(Tarjeta t)
        {
           foreach(Insgnias insgnia in Enum.GetValues(typeof(Insgnias)))
            {
                if (personajeSeleccionado.getInsignia(insgnia))
                {
                    t.setInsignia(insgnia);
                }
           }
        }
        void EsconderAnimales()
        {
            for(int i=0; i < numAnimales; i++)
            {
                animales[i].style.display = DisplayStyle.None;
            }
        }
        void DerAnimal(ClickEvent evento)
        {
            animales[animalActual].style.display = DisplayStyle.None;
            animalActual++;
            if(animalActual >= animales.Length)
            {
                animalActual = 0;
            }
            animales[animalActual].style.display = DisplayStyle.Flex;
        }
        void IzqAnimal(ClickEvent evento)
        {
            animales[animalActual].style.display = DisplayStyle.None;
            animalActual--;
            if (animalActual < 0)
            {
                animalActual = animales.Length - 1;
            }
            animales[animalActual].style.display = DisplayStyle.Flex;
        }
        void SetAnimalesDisponibles()
        {
            animales[5].AddToClassList("animalGris");
            animales[6].AddToClassList("animalGris");
            animales[7].AddToClassList("animalGris");
            animales[8].AddToClassList("animalGris");
            animales[9].AddToClassList("animalGris");
            foreach (Tienda a in Enum.GetValues(typeof(Tienda)))
            {
                if (personajeSeleccionado.getAnimal(a))
                {
                    AnimalDisponible(a);
                }
            }
        }
        void AnimalDisponible(Tienda a)
        {
            switch (a)
            {
                case Tienda.LEON:
                    animales[5].RemoveFromClassList("animalGris");
                    break;
                case Tienda.TIGRE:
                    animales[6].RemoveFromClassList("animalGris");
                    break;
                case Tienda.ERIZO:
                    animales[7].RemoveFromClassList("animalGris");
                    break;
                case Tienda.PANDA:
                    animales[8].RemoveFromClassList("animalGris");
                    break;
                case Tienda.UNICORNIO:
                    animales[9].RemoveFromClassList("animalGris");
                    break;
                default:
                    break;
            }
        }
        void CambiarAnimalIcon(int i)
        {
            switch(i) {
                case 0:
                    personajeSeleccionado.Icon = "oso";
                    break;
                case 1:
                    personajeSeleccionado.Icon = "perro" ;
                    break;
                case 2:
                    personajeSeleccionado.Icon = "lobo";
                    break;
                case 3:
                    personajeSeleccionado.Icon = "gato";
                    break;
                case 4:
                    personajeSeleccionado.Icon = "koala";
                    break;
                case 5:
                    if(personajeSeleccionado.getAnimal(Tienda.LEON))
                        personajeSeleccionado.Icon = "leon";
                    break;
                case 6:
                    if (personajeSeleccionado.getAnimal(Tienda.TIGRE))
                        personajeSeleccionado.Icon = "tigre";
                    break;
                case 7:
                    if (personajeSeleccionado.getAnimal(Tienda.ERIZO))
                        personajeSeleccionado.Icon = "erizo";
                    break;
                case 8:
                    if (personajeSeleccionado.getAnimal(Tienda.PANDA))
                        personajeSeleccionado.Icon = "panda";
                    break;
                case 9:
                    if (personajeSeleccionado.getAnimal(Tienda.UNICORNIO))
                        personajeSeleccionado.Icon = "unicornio";
                    break;
                default:
                    break;

            }
        }
    }
}