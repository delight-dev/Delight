// These extensions methods fixes compatibility issues with UPW (WinRT)

// Just if you change / add anything and have Intelli-Sense / highlighting in the editor
// remember to uncomment for testing in unity
//#define ENABLE_CHANGES

#if ENABLE_CHANGES
#define UNITY_WINRT
#undef UNITY_EDITOR
#endif

using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Reflection;

#if UNITY_WINRT && !UNITY_EDITOR

using Windows.ApplicationModel;

public static class AssemblyExtensions
{
   public static Type[] GetTypes(this Assembly assembly)
   {
      var typeInfoArray = Enumerable.ToArray<TypeInfo>(assembly.DefinedTypes);
      var typeArray = new Type[typeInfoArray.Length];
      for (int index = 0; index < typeInfoArray.Length; ++index)
         typeArray[index] = typeInfoArray[index].AsType();
      return typeArray;
   }

   public static Type GetType(this Assembly assembly, string name, bool throwOnError)
   {
      Type[] types = AssemblyExtensions.GetTypes(assembly);
      for (int index = 0; index < types.Length; ++index)
      {
         if (types[index].Name == name)
            return types[index];
      }
      if (throwOnError)
         throw new Exception("Type " + name + " was not found");
      else
         return (Type) null;
   }
}

public static class ListExtensions
{
   public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> source)
   {
      return new ReadOnlyCollection<T>(source.ToList());
   }

   public static void ForEach<T>(this IEnumerable<T> l, Action<T> a)
   {
      var list = l.ToList();

      foreach(var i in list)
      {
         a(i);
      }
   }

   public static List<TOutput> ConvertAll<T, TOutput>(this IEnumerable<T> source, Converter<T, TOutput> converter)
   {
      return source.Select(o => converter(o)).ToList();
   }
}


namespace System.Reflection
{
   public static class ReflectionExtensions
   {
#if !UNITY_WINRT_10_0
      public static FieldInfo GetField(this Type type, string name)
      {
         return type.GetRuntimeField(name);
      }
      public static FieldInfo GetField(this Type type, string name, BindingFlags flags)
      {
         return type.GetRuntimeField(name);
      }
      public static IEnumerable<FieldInfo> GetFields(this Type type)
      {
         return type.GetRuntimeFields();
      }
      public static MethodInfo GetMethod(this Type type, string name)
      {
         return type.GetRuntimeMethod(name, new Type[]{});
      }

      public static MethodInfo GetMethod(this Type type, string name, BindingFlags flags)
      {
         return type.GetRuntimeMethod(name, new Type[]{});
      }

      public static PropertyInfo GetProperty(this Type type, string name)
      {
         return type.GetRuntimeProperty(name);
      }   

      public static PropertyInfo GetProperty(this Type type, string name, BindingFlags flags)
      {
         return type.GetRuntimeProperty(name);
      }   

      public static IEnumerable<PropertyInfo> GetProperties(this Type type)
      {
         return type.GetRuntimeProperties();
      }   

      public static bool IsAssignableFrom(this Type type, Type otherType){
         return type.GetTypeInfo().IsAssignableFrom(otherType.GetTypeInfo());
      }
#endif

      public static bool IsSubclassOf(this Type type, Type otherType){
         return type.GetTypeInfo().IsSubclassOf(otherType);
      }
  
public static IEnumerable<Attribute> GetCustomAttributes(this Type type, Type otherType, bool inherit){
         return type.GetTypeInfo().GetCustomAttributes(otherType, inherit);
      }

  
      public static bool IsEnum(this Type type){
         return type.GetTypeInfo().IsEnum;
      }

   }

}



public sealed class AppDomain
{
   public static AppDomain CurrentDomain { get; private set; }

   static AppDomain()
   {
      CurrentDomain = new AppDomain();
   }

   public Assembly[] GetAssemblies()
   {
      return GetAssemblyListAsync().Result.ToArray();
   }

   private async System.Threading.Tasks.Task<IEnumerable<Assembly>> GetAssemblyListAsync()
   {
      var folder = Package.Current.InstalledLocation;

      var assemblies = new List<Assembly>();
      foreach (var file in await folder.GetFilesAsync())
      {
         if (file.FileType == ".dll" || file.FileType == ".exe")
         {
            try
            {
                var name = new AssemblyName() { Name = Path.GetFileNameWithoutExtension(file.Name) };
                Assembly asm = Assembly.Load(name);
                assemblies.Add(asm);
            }
            catch
            {
                Debug.LogError("Couldn't load Assembly: " + file.Name);
            }
         }
      }

      return assemblies;
   }
}

#else

namespace System.Reflection
{
    public static class ReflectionExtensions
    {
        public static bool IsEnum(this Type type)
        {
            return type.IsEnum;
        }
    }
}

#endif