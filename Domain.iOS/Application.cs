using System;
using System.IO;
using UIKit;
using Domain.Application;

namespace Domain.iOS
{
    public class Application : IApplication
    {

        string _sessionId;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Application()
        {
            _sessionId = Guid.NewGuid().ToString("N").ToUpper();
        }
        /// <summary>
        /// Registers our Platform specific Application to the IoCContainer.
        /// </summary>
        public static void IoCRegister()
        {
            Application app = new Application();


            ApplicationServices.SimpleIoC.SimpleIocContainer.Current.Register<IApplication>(app);
        }

        /// <summary>
        /// Returns the Current Platform for the specific device the code is running in.
        /// </summary>
        /// <returns>The current platform.</returns>
        public string GetCurrentPlatform()
        {
            return UIDevice.CurrentDevice.Name;
        }

        /// <summary>
        /// Returns the location where the Repository Files are to be stored in the iOS environment.
        /// </summary>
        /// <returns>The repository storage.</returns>
        public string GetRepositoryStorage()
        {
            string returnValue = string.Empty;

            string documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(documentFolder, "..", "Library", "Repository");

            if (!Directory.Exists(libraryFolder))
            {
                Directory.CreateDirectory(libraryFolder);
            }


            return libraryFolder;

        }

        /// <summary>
        /// Returns the current application iteration Session Id.
        /// </summary>
        /// <value>The current application session identifier.</value>
        public string CurrentApplicationSessionId { get => _sessionId; }

    }
}
