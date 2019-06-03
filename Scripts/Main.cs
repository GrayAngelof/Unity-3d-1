using System.Collections;

namespace Geekbrains
{
    /// <summary>
    /// Основной класс. Является точкой входа приложения и базовым загрузчиком всех компонентов в игре.
    /// </summary>
	public class Main : MonoBehaviour
    {
        /// <summary>
        /// Контроллер фонарика
        /// </summary>
		public FlashLightController FlashLightController { get; private set; }
        /// <summary>
        /// Контроллер перехвата нажатых клавиш
        /// </summary>
        public InputController InputController { get; private set; }
        /// <summary>
        /// Контроллер передвижения игрока
        /// </summary>
        public PlayerController PlayerController { get; private set; }
        /// <summary>
        /// Контроллер оружия
        /// </summary>
        public WeaponController WeaponController { get; private set; }
        /// <summary>
        /// Контроллер 
        /// </summary>
        public SelectionController SelectionController { get; private set; }
        /// <summary>
        /// Контроллер ботов
        /// </summary>
        public BotController BotController { get; private set; }
        /// <summary>
        /// Инветнарь игрока
        /// </summary>
        public Inventory Inventory { get; private set; }
        /// <summary>
        /// Трансформ игрока
        /// </summary>
        public Transform Player { get; private set; }
        /// <summary>
        /// Главная камера
        /// </summary>
        public Transform MainCamera { get; private set; }
        /// <summary>
        /// Массив для обновления контроллеров
        /// </summary>
        private IOnUpdate[] _controllers;

        /// <summary>
        /// Одиночка метода Main
        /// </summary>
		public static Main Instance { get; private set; }
        /// <summary>
        /// Префаб ботов
        /// </summary>
        public Bot RefBotPrefab;

        /// <summary>
        /// Инициализация компонентов при старте
        /// </summary>
		private void Awake()
        {
            /// <summary>
            /// Определяем одиночку для метода Main
            /// </summary>
            Instance = this;
            /// <summary>
            /// Находим камеру
            /// </summary>
			MainCamera = Camera.main.transform;
            /// <summary>
            /// Находим игрока
            /// </summary>
			Player = GameObject.FindGameObjectWithTag("Player").transform;
            /// <summary>
            /// Инициализируем инвентарь
            /// </summary>
			Inventory = new Inventory();
            /// <summary>
            /// Инициализируем контроллер передвижения игрока
            /// </summary>
			PlayerController = new PlayerController(new UnitMotor(
                GameObject.FindObjectOfType<CharacterController>().transform));
            /// <summary>
            /// Инициализируем контроллер фонарика
            /// </summary>
			FlashLightController = new FlashLightController();
            /// <summary>
            /// Инициализируем контроллер перехвата нажатия клавиш
            /// </summary>
			InputController = new InputController();
            /// <summary>
            /// Инициализируем контроллер оружия
            /// </summary>
			WeaponController = new WeaponController();
            /// <summary>
            /// Инициализируем контроллер
            /// </summary>
			SelectionController = new SelectionController();
            /// <summary>
            /// Инициализируем контроллер ботов
            /// </summary>
			BotController = new BotController();
            /// <summary>
            /// Инициализируем массив обновления контроллеров
            /// </summary>
			_controllers = new IOnUpdate[]{
            _controllers[0] = FlashLightController,
            _controllers[1] = InputController,
            _controllers[2] = PlayerController,
            _controllers[3] = WeaponController,
            _controllers[4] = SelectionController,
            _controllers[5] = BotController };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routine"></param>
        public void OnStartCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }

        /// <summary>
        /// Запуск объектов
        /// </summary>
        private void Start()
        {
            Inventory.OnStart();
            FlashLightController.OnStart();
            PlayerController.On();
            InputController.On();
            //BotController.OnStart();
            //BotController.On();
        }

        /// <summary>
        /// Изенение объектов каждый кадр
        /// </summary>
        private void Update()
        {
            for (var index = 0; index < _controllers.Length; index++)
            {
                var controller = _controllers[index];
                controller.OnUpdate();
            }
        }

        /// <summary>
        /// Графический интерфейс для отображения заряда фонарика
        /// </summary>
        private void OnGUI()
        {
            GUI.Label(new Rect(0, 0, 100, 100), $"{1 / Time.deltaTime:0.0}");
        }
    }
}