namespace WeatherForecastService.Models
{

    /// <summary>
    /// Объект на базе класса WeatherForecastHolder, будет хранить список показателей
    /// температуры
    /// </summary>
    public class WeatherForecastHolder
    {
        // Коллекция для хранения показателей температуры
        private List<WeatherForecast> _values;

        #region Конструкторы

        public WeatherForecastHolder()
        {
            // Инициализирую коллекцию для хранения показателей температуры
            _values = new List<WeatherForecast>();
        }

        #endregion

        /// <summary>
        /// Добавить новый показатель температуры
        /// </summary>
        /// <param name="date">Дата фиксации показателя температуры</param>
        /// <param name="temperatureC">Показатель температуры</param>
        public void Add(DateTime date, int temperatureC)
        {
            _values.Add(new WeatherForecast() { Date = date, TemperatureC = temperatureC });
        }

        /// <summary>
        /// Обновить показатель температуры
        /// </summary>
        /// <param name="date">Дата фиксации показания температуры</param>
        /// <param name="temperatureC">Новый показатель температуры</param>
        /// <returns>Результат выполнения операции</returns>
        public bool Update(DateTime date, int temperatureC)
        {
            foreach (WeatherForecast item in _values)
            {
                if (item.Date == date)
                {
                    item.TemperatureC = temperatureC;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Получить показатели температуры за временной период
        /// </summary>
        /// <param name="dateFrom">Начальная дата</param>
        /// <param name="dateTo">Конечная дата</param>
        /// <returns>Коллекция показателей температуры</returns>
        public List<WeatherForecast> Get(DateTime dateFrom, DateTime dateTo)
        {
            return _values.FindAll(x => x.Date >= dateFrom && x.Date <= dateTo);
        }

        /// <summary>
        /// Удалить показатель температуты на дату
        /// </summary>
        /// <param name="date">Дата фиксации показателя температуры</param>
        /// <returns>Результат выполнения операции</returns>
        public bool Delete(DateTime date)
        {
            if (_values.FirstOrDefault(x => x.Date == date) == null)
                return false;

            /* Логика метода Add допускает добавление нескольких значений за одну дату, 
             * по этому я решил, что т.к. в метод Delete мы передаём только одну дату, 
             * стоит удалять все элементы с этой датой через цикл.
             */

            List<WeatherForecast> datesToDelete = _values.Where(x => x.Date == date).ToList();

            foreach (WeatherForecast weather in datesToDelete)
            {
                _values.Remove(weather);
            }

            return true;
        }
    }
}
