#region Using Statements
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Serializable project configuration used by the view processor.
    /// </summary>
    public class Configuration : ScriptableObject
    {
        #region Fields

        public List<string> ContentFolders;
        public string SchemaFile;
        public string ObjectModelFile;
        public string SourceFolder;
        private static Configuration _instance;
        public static string DefaultConfigurationAssetFolder = "Assets/Delight/Configuration/";
        public static string ConfigurationAssetName = "Configuration.asset";
        public static string DefaultConfigurationAssetPath = DefaultConfigurationAssetFolder + ConfigurationAssetName;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Configuration()
        {
            ContentFolders = new List<string>();
            ContentFolders.Add("Assets/Content/");
            ContentFolders.Add("Assets/Delight/Content/");

            SchemaFile = "Assets/Delight/Schemas/Delight.xsd";
            ObjectModelFile = "DelightContent.bin";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sanitize configuration.
        /// </summary>
        public void Sanitize()
        {
            var invalidPathChars = Path.GetInvalidPathChars();

            // make sure paths are consistantly formatted
            for (int i = ContentFolders.Count - 1; i >= 0; --i)
            {
                var path = ContentFolders[i];
                if (String.IsNullOrEmpty(path) || path.IndexOfAny(invalidPathChars) >= 0)
                {
                    Debug.LogWarning(String.Format("[Delight] Improperly formatted content folder path \"{0}\" removed from Configuration.asset", path));
                    ContentFolders.RemoveAt(i);
                    continue;
                }

                // make sure directory separators are uniform
                path = GetFormattedPath(path);

                // make sure path ends with a directory separator
                if (!path.EndsWith("/"))
                {
                    path += "/";
                }

                ContentFolders[i] = path;
            }

            SchemaFile = GetFormattedPath(SchemaFile);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets global configuration instance.
        /// </summary>
        public static Configuration GetInstance()
        {
            if (_instance != null)
                return _instance;

            // check default directory
            Configuration configuration = AssetDatabase.LoadAssetAtPath(DefaultConfigurationAssetPath, typeof(Configuration)) as Configuration;
            if (configuration != null)
            {
                _instance = configuration;
                return _instance;
            }

            // search for configuration asset
            var configFilePath = System.IO.Directory.GetFiles(Application.dataPath, ConfigurationAssetName, System.IO.SearchOption.AllDirectories).FirstOrDefault();
            if (!String.IsNullOrEmpty(configFilePath))
            {
                string localPath = "Assets/" + configFilePath.Substring(Application.dataPath.Length + 1);
                configuration = AssetDatabase.LoadAssetAtPath(localPath, typeof(Configuration)) as Configuration;
                if (configuration != null)
                {
                    _instance = configuration;
                    return _instance;
                }
            }

            // no configuration found. create new at default location                 
            System.IO.Directory.CreateDirectory(DefaultConfigurationAssetFolder);
            configuration = ScriptableObject.CreateInstance<Configuration>();
            AssetDatabase.CreateAsset(configuration, DefaultConfigurationAssetPath);
            AssetDatabase.Refresh();

            _instance = configuration;
            return _instance;
        }

        /// <summary>
        /// Gets object model file path.
        /// </summary>
        public string GetObjectModelFilePath()
        {
            // get application path minus "/Assets" folder
            var path = Application.dataPath.Substring(0, Application.dataPath.Length - 7);           
            return String.Format("{0}/{1}", path, ObjectModelFile);
        }

        /// <summary>
        /// Gets uniformally formatted path with forward slashes "/" as directory separators.
        /// </summary>
        public static string GetFormattedPath(string path)
        {
            if (String.IsNullOrEmpty(path))
                return path;
            return path.Replace("\\", "/");
        }

        #endregion
    }
}
