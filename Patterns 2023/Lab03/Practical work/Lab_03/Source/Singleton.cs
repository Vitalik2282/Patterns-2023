namespace Lab_02
{
    public class Singleton<T> where T : class 
    {
        public static T Instance { get; protected set; }    
    }
}
