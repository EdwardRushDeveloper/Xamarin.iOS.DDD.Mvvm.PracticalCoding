using System;
using System.Collections.Generic;
using System.Threading;
using Domain.SimpleIoC;

namespace ApplicationServices.SimpleIoC
{

    /// <summary>
    /// Simple Dependency Injection Class to manage single registration objects
    /// This Instance is Thread Safe.
    /// 
    /// Using this SimpleIoC Container allows you to construct your instance before registration.
    /// </summary>
    public class SimpleIocContainer : IContainer
    {
        #region Single Instance of the IOC Container
        private static object lockObject = new object();

        private static IContainer _container;

        /// <summary>
        /// Get an instance or our current IoC Simple Container
        /// This is singleton instance.
        /// 
        /// </summary>
        /// <value>The current.</value>
        public static IContainer Current
        {
            get
            {
                IContainer returnValue = null;
                if (_container == null)
                {
                    lock (lockObject)
                    {
                        if (_container == null)
                        {
                            _container = new SimpleIocContainer();
                        }
                    }
                }

                returnValue = _container;

                return returnValue;
            }

        }

        #endregion

        /// <summary>
        /// Internal Dictionary for manging the dependency requests
        /// </summary>
        private IDictionary<Type, object> _internalDictionary;

        /// <summary>
        /// Constructor for the IOC container
        /// </summary>
        public SimpleIocContainer()
        {
            _internalDictionary = new Dictionary<Type, object>();
        }



        /// <summary>
        /// The Reader and Writer Lock to control reads and updates
        /// </summary>
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();


        /// <summary>
        /// Internal Enum to control code flow in the Update Dictionary Method.
        /// </summary>
        private enum RegisterType { Add = 0, Retrieve = 1 };


        /// <summary>
        /// Thread Safe Method to control access to the internal dictionary for Retrievals and Updates.
        /// </summary>
        /// <returns>A Resolved Type if the request is RegisterType.Retrieve, othewise if the request is RegisterType.Add the instance is added to the internal dictionary, null is then returned.</returns>
        /// <param name="instance">Instance to add to the internal dictionary if the operation is RegisterType.Add.</param>
        /// <param name="registerType">The Enum to control the Locking mechanism and code flow in the Method.</param>
        /// <typeparam name="T">Generic Type</typeparam>
        private T UpdateDictionary<T>(object instance, RegisterType registerType)
        {

            _lock.EnterUpgradeableReadLock();

            //our default return value.
            T returnValue = default(T);
            Type currentType = typeof(T);

            try
            {

                //if wea re retrieving a value follow this path
                if (registerType == RegisterType.Retrieve)
                {

                    object currentObject = null;

                    if (_internalDictionary.TryGetValue(currentType, out currentObject))
                    {
                        returnValue = (T)currentObject;
                    }


                }
                //if we are adding a value follow this path.
                else
                {
                    try
                    {
                        _lock.EnterWriteLock();
                        //first check to see if type T is an interface, if not throw an error.
                        if (!currentType.IsInterface)
                        {
                            throw new InvalidCastException(string.Format("{0} is not an interface.", currentType.Name));
                        }

                        ///since we know that  T is an interface, get the interface name.
                        string interfaceName = currentType.Name;
                        //get a list of interfaces from the instance to save.
                        Type[] interfaceList = instance.GetType().GetInterfaces();

                        //variable to set if the 
                        bool isImplemented = false;

                        //if the interface list is not null, then iterate through list item and see if this instance implements this interface.
                        if (interfaceList != null)
                        {
                            foreach (Type current in interfaceList)
                            {
                                if (current.Name == interfaceName)
                                { isImplemented = true; break; }

                            }
                        }

                        //if not implemented, then throw a NotImplementedException.
                        if (!isImplemented)
                        {
                            throw new NotImplementedException(
                             string.Format("{0} does not implement the interface {1}."
                            , instance.GetType().Name
                            , (typeof(T)).Name));

                        }
                        //add then remove the insance of the current type.
                        _internalDictionary.Remove(currentType);
                        _internalDictionary.Add(currentType, instance);


                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }

            return returnValue;

        }




        /// <summary>
        /// Registers the specified type to the interal register.
        /// Only one instance of a type can be registered at a time.
        /// </summary>
        /// <param name="instance">The instance to save.</param>
        /// <typeparam name="T">The Interface to register the object as</typeparam>
        public void Register<T>(object instance)
        {
            UpdateDictionary<T>(instance, RegisterType.Add);
        }

        /// <summary>
        /// Using the specified Interface type search the dictionary and if it is found return it.
        /// Otherwise Default of the specified is returned.
        /// </summary>
        /// <returns>The resolve.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T Resolve<T>()
        {
            return UpdateDictionary<T>(null, RegisterType.Retrieve);
        }




    }
}
