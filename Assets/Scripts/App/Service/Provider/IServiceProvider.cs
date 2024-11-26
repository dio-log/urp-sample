namespace App.Service.Provider
{
    public interface IServiceProvider
    {
        
        public T GetService<T>();

        public IServiceProvider AddService<T>(T service);

        public void Build();
    }
}