namespace Geekbrains
{
    /// <summary>
    /// Базовый класс для всех типов боеприпасов
    /// </summary>
    public abstract class Ammunition : BaseObjectScene
    {
        /// <summary>
        /// Время жизни выпущеного боеприпаса
        /// </summary>
		[SerializeField] protected float _timeToDestruct = 10;
        /// <summary>
        /// базовое повреждение боеприпасов
        /// </summary>
        [SerializeField] protected float _baseDamage = 10;
        /// <summary>
        /// Текущее повреждение боеприпаса
        /// </summary>
        protected float _curDamage;
        /// <summary>
        /// Уровень уменьшения урона боеприпаса в зависимости от времени жизни
        /// </summary>
        protected float _lossOfDamageAtTime = 0.2f;
        /// <summary>
        /// типа боеприпаса - пуля
        /// </summary>
        public AmmunitionType Type = AmmunitionType.Bullet;

        /// <summary>
        /// Инициализация объекта при старте
        /// </summary>
        protected override void Awake()
        {
            base.Awake();//запуск базового Awake(BaseObjectScene)
            _curDamage = _baseDamage;//текущее повреждение = базовому повреждению
        }

        /// <summary>
        /// Действия при старте объекта
        /// </summary>
        private void Start()
        {
            Destroy(gameObject, _timeToDestruct);//утанавливается время, через которое объеккт будет уничтожен
            InvokeRepeating(nameof(LossOfDamage), 0, 1);// уменьшение повреждения взависимости от времени
        }

        /// <summary>
        /// Пинок физическому объекту
        /// </summary>
        /// <param name="dir">Направление пинка</param>
        public void AddForce(Vector3 dir)
        {
            if (!Rigidbody) return;//если у объекта нет физического компонента, то ничего не делаем
            Rigidbody.AddForce(dir);//пинаем объект в заданом направлении
        }

        /// <summary>
        /// Потеря урона от времени
        /// </summary>
        protected void LossOfDamage()
        {
            _curDamage -= _lossOfDamageAtTime;//уменьшение текущего урона на величину уровеня уменьшения урона
        }
    }
}