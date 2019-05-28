using System;
namespace Domain.SimpleIoC
{
    public interface IContainer
    {
        void Register<T>(object instance);
        T Resolve<T>();
    }
}
