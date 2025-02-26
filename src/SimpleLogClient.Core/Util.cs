using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace SimpleLogClient.Core
{
    public class Util
    {

        /// <summary>
        /// Reads a value from configuration file. Better performance than using AppSettingsReader.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetConfigValueOrDefault(string key, string defaultValue)
        {
            
                return ConfigurationManager.AppSettings[key] ?? defaultValue;
            
        }


        /// <summary>
        /// Instantiates an object given a class name.
        /// 
        /// TODO: Move to common lib.
        /// </summary>
        /// <param name="className">The fully qualified class name of the object to instantiate.</param>
        /// <param name="superClass">The class to which the new object should belong.</param>
        /// <param name="defaultValue">The object to return in case of non-fulfillment.</param>
        /// <returns>
        /// An instance of the <paramref name="className"/> or <paramref name="defaultValue"/>
        /// if the object could not be instantiated.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Checks that the <paramref name="className"/> is a subclass of
        /// <paramref name="superClass"/>. If that test fails or the object could
        /// not be instantiated, then <paramref name="defaultValue"/> is returned.
        /// </para>
        /// </remarks>
        public static object InstantiateByClassName(string className, Type superClass, object defaultValue)
        {
            if (className != null)
            {
                try
                {
                    Type classObj = GetTypeFromString(className, true, true);
                    if (!superClass.IsAssignableFrom(classObj))
                    {
                        //LogLog.Error("OptionConverter: A [" + className + "] object is not assignable to a [" + superClass.FullName + "] variable.");
                        return defaultValue;
                    }
                    return Activator.CreateInstance(classObj);
                }
                catch (Exception e)
                {
                    //LogLog.Error("OptionConverter: Could not instantiate class [" + className + "].", e);
                }
            }
            return defaultValue;
        }
        /// <summary>
        /// Loads the type specified in the type string.
        /// </summary>
        /// <param name="relativeType">A sibling type to use to load the type.</param>
        /// <param name="typeName">The name of the type to load.</param>
        /// <param name="throwOnError">Flag set to <c>true</c> to throw an exception if the type cannot be loaded.</param>
        /// <param name="ignoreCase"><c>true</c> to ignore the case of the type name; otherwise, <c>false</c></param>
        /// <returns>The type loaded or <c>null</c> if it could not be loaded.</returns>
        /// <remarks>
        /// <para>
        /// If the type name is fully qualified, i.e. if contains an assembly name in 
        /// the type name, the type will be loaded from the system using 
        /// <see cref="Type.GetType(string,bool)"/>.
        /// </para>
        /// <para>
        /// If the type name is not fully qualified, it will be loaded from the assembly
        /// containing the specified relative type. If the type is not found in the assembly 
        /// then all the loaded assemblies will be searched for the type.
        /// </para>
        /// </remarks>
        public static Type GetTypeFromString(Type relativeType, string typeName, bool throwOnError, bool ignoreCase)
        {
            return GetTypeFromString(relativeType.Assembly, typeName, throwOnError, ignoreCase);
        }

        /// <summary>
        /// Loads the type specified in the type string.
        /// </summary>
        /// <param name="typeName">The name of the type to load.</param>
        /// <param name="throwOnError">Flag set to <c>true</c> to throw an exception if the type cannot be loaded.</param>
        /// <param name="ignoreCase"><c>true</c> to ignore the case of the type name; otherwise, <c>false</c></param>
        /// <returns>The type loaded or <c>null</c> if it could not be loaded.</returns>		
        /// <remarks>
        /// <para>
        /// If the type name is fully qualified, i.e. if contains an assembly name in 
        /// the type name, the type will be loaded from the system using 
        /// <see cref="Type.GetType(string,bool)"/>.
        /// </para>
        /// <para>
        /// If the type name is not fully qualified it will be loaded from the
        /// assembly that is directly calling this method. If the type is not found 
        /// in the assembly then all the loaded assemblies will be searched for the type.
        /// </para>
        /// </remarks>
        public static Type GetTypeFromString(string typeName, bool throwOnError, bool ignoreCase)
        {
            return GetTypeFromString(Assembly.GetCallingAssembly(), typeName, throwOnError, ignoreCase);
        }

        /// <summary>
        /// Loads the type specified in the type string.
        /// </summary>
        /// <param name="relativeAssembly">An assembly to load the type from.</param>
        /// <param name="typeName">The name of the type to load.</param>
        /// <param name="throwOnError">Flag set to <c>true</c> to throw an exception if the type cannot be loaded.</param>
        /// <param name="ignoreCase"><c>true</c> to ignore the case of the type name; otherwise, <c>false</c></param>
        /// <returns>The type loaded or <c>null</c> if it could not be loaded.</returns>
        /// <remarks>
        /// <para>
        /// If the type name is fully qualified, i.e. if contains an assembly name in 
        /// the type name, the type will be loaded from the system using 
        /// <see cref="Type.GetType(string,bool)"/>.
        /// </para>
        /// <para>
        /// If the type name is not fully qualified it will be loaded from the specified
        /// assembly. If the type is not found in the assembly then all the loaded assemblies 
        /// will be searched for the type.
        /// </para>
        /// </remarks>
        public static Type GetTypeFromString(Assembly relativeAssembly, string typeName, bool throwOnError, bool ignoreCase)
        {
            // Check if the type name specifies the assembly name
            if (typeName.IndexOf(',') == -1)
            {
                //LogLog.Debug("SystemInfo: Loading type ["+typeName+"] from assembly ["+relativeAssembly.FullName+"]");

                // Attempt to lookup the type from the relativeAssembly
                Type type = relativeAssembly.GetType(typeName, false, ignoreCase);
                if (type != null)
                {
                    // Found type in relative assembly
                    //LogLog.Debug("SystemInfo: Loaded type ["+typeName+"] from assembly ["+relativeAssembly.FullName+"]");
                    return type;
                }

                Assembly[] loadedAssemblies = null;
                try
                {
                    loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                }
                catch (System.Security.SecurityException)
                {
                    // Insufficient permissions to get the list of loaded assemblies
                }

                if (loadedAssemblies != null)
                {
                    // Search the loaded assemblies for the type
                    foreach (Assembly assembly in loadedAssemblies)
                    {
                        type = assembly.GetType(typeName, false, ignoreCase);
                        if (type != null)
                        {
                            // Found type in loaded assembly
                            // LogLog.Debug("SystemInfo: Loaded type [" + typeName + "] from assembly [" + assembly.FullName + "] by searching loaded assemblies.");
                            return type;
                        }
                    }
                }

                // Didn't find the type
                if (throwOnError)
                {
                    throw new TypeLoadException("Could not load type [" + typeName + "]. Tried assembly [" + relativeAssembly.FullName + "] and all loaded assemblies");
                }
                return null;
            }
            else
            {
                // Includes explicit assembly name
                //LogLog.Debug("SystemInfo: Loading type ["+typeName+"] from global Type");

                return Type.GetType(typeName, throwOnError, ignoreCase);

            }
        }

        /// <summary>
        /// Helper.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyString(object input)
        {
            return (input == null || input.ToString() == String.Empty);
        }

        public static IPAddress GetIpAddress(string hostName)
        {
            IPAddress retVal = null;
            IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);

            foreach (IPAddress address in hostAddresses)
            {
                try
                {

                    if ((address.AddressFamily == AddressFamily.InterNetwork))
                    {
                        retVal = address;
                        /*
                        socket2.Connect(address, port);
                        this.m_ClientSocket = socket2;
                        if (socket != null)
                        {
                            socket.Close();
                        }*/
                    }
                    /*
                else if (socket != null)
                {
                    socket.Connect(address, port);
                    this.m_ClientSocket = socket;
                    if (socket2 != null)
                    {
                        socket2.Close();
                    }
                }
                this.m_Family = address.AddressFamily;
                this.m_Active = true;
              */

                }
                catch (Exception exception2)
                {
                    /*
                    if (NclUtilities.IsFatal(exception2))
                    {
                        throw;
                    }
                    exception = exception2;*/
                }
            }


            return retVal;
        }


        /// <summary>
        /// Writes to windows event log.
        /// </summary>
        /// <param name="errorSource"></param>
        /// <param name="msgHeader"></param>
        /// <param name="msg"></param>
        public static void WriteErrorToEventLog(string errorSource, string msgHeader, string msg)
        {
            try
            {
                if (IsNullOrEmptyString(msgHeader))
                {
                    msgHeader = "GeneralError";
                }
                Debug.WriteLine(string.Format("Error Writing to Log: [{0}] {1}", msgHeader, msg));
                EventLog.WriteEntry(errorSource, string.Format("[{0}] {1}", msgHeader, msg), EventLogEntryType.Error);
            }
            catch { }
        }
        public static void WriteErrorToEventLog(string errorSource, string msgHeader, Exception ex)
        {
            WriteErrorToEventLog(errorSource, msgHeader, ex.ToString());
        }
      
        

       
        /*
        public struct ErrorSource
        {
            string WriteLog = "WriteLog";
            string GKLoggerNet = "GKLoggerNet";
        }
         */
    }
}
