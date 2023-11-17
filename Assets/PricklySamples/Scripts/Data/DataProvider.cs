public static class DataProvider
{
    public static PlayerData<T> SaveByKey<T>(Data.Key key, in T value)
    {
        PlayerData<T> savedData = new PlayerData<T>(key.SaveName);
        savedData.Save(value);

        return savedData;
    }

    public static PlayerData<T> LoadByKey<T>(Data.Key key, out T value, T defaultValue)
    {
        PlayerData<T> loadedData = new PlayerData<T>(key.SaveName, defaultValue);
        loadedData.Load(out value);

        return loadedData;
    }
}