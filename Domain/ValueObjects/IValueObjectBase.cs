using System;
namespace Domain.ValueObjects
{

    /// <summary>
    /// Interface defined for the Value Object Instances to help when these instances may be used in
    /// IoC containers.
    /// </summary>
    public interface IValueObjectBase<T>
    {
        T Value { get; }
    }

}
