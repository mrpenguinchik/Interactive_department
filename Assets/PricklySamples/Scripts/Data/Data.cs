public static class Data
{
    public static Key LEVEL = new Key("LEVEL");
    public static Key UPGRADE = new Key("UPGRADE");

    public class Key
    {
        private string _saveName;
        public string SaveName => _saveName;

        public Key(string key)
        {
            _saveName = key;
        }
    }
}
