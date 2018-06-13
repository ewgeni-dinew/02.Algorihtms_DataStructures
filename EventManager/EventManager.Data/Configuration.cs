namespace EventManager.Data
{
    //ToDo-change Server Name; change Db Name
    internal static class Configuration
    {
        internal static string ConnectionString => @"Server=.;Database=EventDB;Trusted_Connection=True";
    }
}
