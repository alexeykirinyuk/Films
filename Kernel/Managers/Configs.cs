namespace Films.Kernel.Managers
{
    public class Configs
    {
        public bool TurnDataBase { get; set; }
        public bool TurnLog { get; set; }
        public bool Debug { get; set; }

        public string LogFileName { get; set; }

        public Configs()
        {
            //TODO: Свойства должны инициализироваться из файла конфигов.
            TurnDataBase = true;
            TurnLog = true;
            Debug = true;

            LogFileName = "log.txt";
        }
    }
}
