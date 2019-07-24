#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Extension methods. Contains extension methods used by the framework.
    /// </summary>
    public static class ExtensionMethods
    {
        #region Fields

        public static Dictionary<string, string> PluralizeExceptions = new Dictionary<string, string>() {
                { "man", "men" },
                { "woman", "women" },
                { "child", "children" },
                { "tooth", "teeth" },
                { "foot", "feet" },
                { "mouse", "mice" },
                { "belief", "beliefs" } };

        #endregion

        #region Methods

        /// <summary>
        /// Makes sure initializer is called only once per type. 
        /// </summary>
        public static void AfterInitializeInternal<T>(this T view) where T : IInitialize
        {
            if (view.GetType() == typeof(T))
            {
                view.AfterInitialize();
            }
        }

        /// <summary>
        /// Gets readable string from exception.
        /// </summary>
        public static string Message(this Exception e)
        {
            var exception = e;
            if (e is TargetInvocationException)
            {
                if (e.InnerException != null)
                {
                    exception = e.InnerException;
                }
            }

            return String.Format("{0}{1}{2}", exception.Message, Environment.NewLine, exception.StackTrace);
        }

        /// <summary>
        /// Gets attribute value from XML element.
        /// </summary>
        public static string AttributeValue(this XElement element, XName attributeName)
        {
            var attribute = element.Attribute(attributeName);
            return attribute != null ? attribute.Value : null;
        }

        /// <summary>
        /// Gets line number from XElement.
        /// </summary>
        public static int GetLineNumber(this XElement element)
        {
            return (element as IXmlLineInfo).LineNumber;
        }

        /// <summary>
        /// Gets code printable name from field info.
        /// </summary>
        public static string FieldTypeName(this FieldInfo fieldInfo, bool xmlType = false)
        {
            return fieldInfo.FieldType.TypeName(xmlType);
        }

        /// <summary>
        /// Gets code printable name from property info.
        /// </summary>
        public static string FieldTypeName(this PropertyInfo propertyInfo, bool xmlType = false)
        {
            return propertyInfo.PropertyType.TypeName(xmlType);
        }

        /// <summary>
        /// Gets formatted name from type.
        /// </summary>
        public static string TypeName(this Type type, bool xmlType = false)
        {
            if (!type.IsGenericType)
                return type.FullName.Replace('+', '.');

            // if generic type we need to convert name to correct format
            string fieldTypeName = type.FullName.Split('`')[0];
            Type[] genericArguments = type.GetGenericArguments();

            var sb = new StringBuilder();
            foreach (var genericArgument in genericArguments)
            {
                var argumentName = genericArgument.TypeName();
                if (sb.Length > 0)
                {
                    sb.Append(", ").Append(argumentName);
                }
                else
                {
                    sb.Append(argumentName);
                }
            }

            if (sb.Length > 0)
            {
                fieldTypeName = String.Format("{0}<{1}>", fieldTypeName, sb.ToString());
            }

            if (xmlType)
            {
                fieldTypeName = fieldTypeName.Replace('<', '[').Replace('>', ']');
            }

            return fieldTypeName.Replace('+', '.');
        }

        /// <summary>
        /// Appends line using format string.
        /// </summary>
        public static StringBuilder AppendLine(this StringBuilder sb, string format, params object[] args)
        {
            return sb.AppendLine(String.Format(format, args));
        }

        /// <summary>
        /// Appends line using format with indendation.
        /// </summary>
        public static StringBuilder AppendLine(this StringBuilder sb, int indentationLevel, string format, params object[] args)
        {
            string indendation = new string(' ', indentationLevel * 4);
            return sb.AppendLine(indendation + String.Format(format, args));
        }

        /// <summary>
        /// Appends string with indendation.
        /// </summary>
        public static StringBuilder Append(this StringBuilder sb, int indentationLevel, string str)
        {
            string indendation = new string(' ', indentationLevel * 4);
            return sb.Append(indendation + str);
        }

        /// <summary>
        /// String.IndexOf ignoring case.
        /// </summary>
        public static int IIndexOf(this string str1, string str2)
        {
            return str1.IndexOf(str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// String.LastIndexOf ignoring case.
        /// </summary>
        public static int ILastIndexOf(this string str1, string str2)
        {
            return str1.LastIndexOf(str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// String.Equals ignoring case.
        /// </summary>
        public static bool IEquals(this string str1, string str2)
        {
            if (str1 == null) return (str1 == str2);
            return str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// String.StartsWith ignoring case.
        /// </summary>
        public static bool IStartsWith(this string str1, string str2)
        {
            return str1.StartsWith(str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// String.Contains ignoring case.
        /// </summary>
        public static bool IContains(this string str1, string str2)
        {
            return str1.IndexOf(str2, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// List.Contains ignoring case.
        /// </summary>
        public static bool IContains(this List<string> strList, string str)
        {
            if (strList == null) return false;
            return strList.Contains(str, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Removes comments from a line.
        /// </summary>
        public static string RemoveComments(this string line)
        {
            if (String.IsNullOrWhiteSpace(line)) return line;
            if (line.StartsWith("//") || line.StartsWith("#"))
                return String.Empty;
            return line;
        }

        /// <summary>
        /// Compares two lists of strings are the same ignoring case by default.
        /// </summary>
        public static bool Same(this List<string> first, List<string> second, IEqualityComparer<string> stringComparer = null)
        {
            var comparer = stringComparer ?? StringComparer.OrdinalIgnoreCase;
            if (first == second) return true;
            if (first == null) return second == null;
            if (second == null) return false;
            if (first.Count != second.Count) return false;

            var firstNotSecond = first.Except(second, stringComparer).ToList();
            var secondNotFirst = second.Except(first, stringComparer).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        /// <summary>
        /// Pluralizes a table name.
        /// </summary>
        public static string Pluralize(this string text, string pluralWhenEndsWithS = null)
        {
            if (PluralizeExceptions.ContainsKey(text.ToLowerInvariant()))
            {
                return PluralizeExceptions[text.ToLowerInvariant()];
            }
            else if (text.EndsWith("y", StringComparison.OrdinalIgnoreCase) &&
                !text.EndsWith("ay", StringComparison.OrdinalIgnoreCase) &&
                !text.EndsWith("ey", StringComparison.OrdinalIgnoreCase) &&
                !text.EndsWith("iy", StringComparison.OrdinalIgnoreCase) &&
                !text.EndsWith("oy", StringComparison.OrdinalIgnoreCase) &&
                !text.EndsWith("uy", StringComparison.OrdinalIgnoreCase))
            {
                return text.Substring(0, text.Length - 1) + "ies";
            }
            else if (text.EndsWith("us", StringComparison.InvariantCultureIgnoreCase))
            {
                return text + "es";
            }
            else if (text.EndsWith("ss", StringComparison.InvariantCultureIgnoreCase))
            {
                return text + "es";
            }
            else if (text.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
            {
                return pluralWhenEndsWithS == null ? text : text + pluralWhenEndsWithS;
            }
            else if (text.EndsWith("x", StringComparison.InvariantCultureIgnoreCase) ||
                text.EndsWith("ch", StringComparison.InvariantCultureIgnoreCase) ||
                text.EndsWith("sh", StringComparison.InvariantCultureIgnoreCase))
            {
                return text + "es";
            }
            else if (text.EndsWith("f", StringComparison.InvariantCultureIgnoreCase) && text.Length > 1)
            {
                return text.Substring(0, text.Length - 1) + "ves";
            }
            else if (text.EndsWith("fe", StringComparison.InvariantCultureIgnoreCase) && text.Length > 2)
            {
                return text.Substring(0, text.Length - 2) + "ves";
            }
            else
            {
                return text + "s";
            }
        }

        /// <summary>
        /// Converts name of variable/property to private member name.
        /// </summary>
        public static string ToPrivateMemberName(this string str)
        {
            if (String.IsNullOrEmpty(str)) return str;
            return "_" + char.ToLower(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Converts a variable/property to local variable name.
        /// </summary>
        public static string ToLocalVariableName(this string str)
        {
            if (String.IsNullOrEmpty(str)) return str;
            return char.ToLower(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Converts a name to property name.
        /// </summary>
        public static string ToPropertyName(this string str)
        {
            if (String.IsNullOrEmpty(str)) return str;

            // capitalize the first letter
            var str2 = char.ToUpper(str[0]) + str.Substring(1);

            // add prefix 'N' if starting with a digit
            if (char.IsDigit(str[0]))
            {
                str2 = "N" + str2;
            }

            // return string containing only letters, digits and underscore characters
            return new string((from c in str2
                               where char.IsLetterOrDigit(c) || c == '_'
                               select c).ToArray());
        }

        /// <summary>
        /// Gets member info (property or field) from a type.
        /// </summary>
        public static MemberInfo GetMemberInfo(this Type type, string field, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
        {
            var fieldInfo = type.GetField(field, bindingFlags);
            if (fieldInfo != null)
                return fieldInfo;

            var propertyInfo = type.GetProperty(field, bindingFlags);
            return propertyInfo;
        }

        /// <summary>
        /// Gets type from member info (property or field).
        /// </summary>
        public static Type GetMemberType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Adds event trigger callback.
        /// </summary>
        public static void AddEventTrigger(this GameObject gameObject, DependencyObject sender, ViewAction action, EventTriggerType eventTriggerType)
        {
            if (action == null || !action.IsEnabled)
                return;

            EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
            if (eventTrigger == null)
            {
                eventTrigger = gameObject.AddComponent<EventTrigger>();
            }

            // add unity event system trigger
            var entry = new EventTrigger.Entry();
            entry.eventID = eventTriggerType;
            entry.callback = new EventTrigger.TriggerEvent();
            eventTrigger.triggers.Add(entry);

            var unityAction = new UnityAction<BaseEventData>(eventData => { action?.Invoke(sender, eventData); });
            entry.callback.AddListener(unityAction);
        }

        /// <summary>
        /// Checks if a flag enum has a flag value set.
        /// </summary>
        public static bool HasFlag(this Enum variable, Enum value)
        {
            // check if from the same type
            if (variable.GetType() != value.GetType())
            {
                Debug.Log("#Delight# The checked flag is not from the same type as the checked variable.");
                return false;
            }

            Convert.ToUInt64(value);
            ulong num = Convert.ToUInt64(value);
            ulong num2 = Convert.ToUInt64(variable);
            return (num2 & num) == num;
        }

        /// <summary>
        /// Gets distinct elements from a list by some lambda expression.
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();
            return source.Where(element => knownKeys.Add(keySelector(element)));
        }

        /// <summary>
        /// Traverses the view layout tree and performs an action on each child until the action returns false.
        /// </summary>
        public static void ForEach<T>(this View view, Func<T, bool> action, bool recursive = true, DependencyObject parent = null, TraversalAlgorithm traversalAlgorithm = TraversalAlgorithm.DepthFirst) where T : View
        {
            switch (traversalAlgorithm)
            {
                default:
                case TraversalAlgorithm.DepthFirst:
                    foreach (View child in view.LayoutChildren)
                    {
                        bool skipChild = false;
                        if (parent != null)
                        {
                            if (child.Parent != parent)
                                skipChild = true;
                        }

                        if (!skipChild)
                        {
                            var matchedChild = child as T;
                            if (matchedChild != null)
                            {
                                var result = action(matchedChild);
                                if (!result)
                                {
                                    // done traversing
                                    return;
                                }
                            }
                        }

                        if (recursive)
                        {
                            child.ForEach<T>(action, recursive, parent, traversalAlgorithm);
                        }
                    }
                    break;

                case TraversalAlgorithm.BreadthFirst:
                    Queue<View> queue = new Queue<View>();
                    foreach (View child in view.LayoutChildren)
                    {
                        bool skipChild = false;
                        if (parent != null)
                        {
                            if (child.Parent != parent)
                                skipChild = true;
                        }

                        if (!skipChild)
                        {
                            var matchedChild = child as T;
                            if (matchedChild != null)
                            {
                                var result = action(matchedChild);
                                if (!result)
                                {
                                    // done traversing
                                    return;
                                }
                            }
                        }

                        if (recursive)
                        {
                            // add children to queue
                            queue.Enqueue(child);
                        }
                    }

                    foreach (var queuedView in queue)
                    {
                        queuedView.ForEach<T>(action, recursive, parent, traversalAlgorithm);
                    }
                    break;

                case TraversalAlgorithm.ReverseDepthFirst:
                    foreach (View child in view.LayoutChildren)
                    {
                        if (recursive)
                        {
                            child.ForEach<T>(action, recursive, parent, traversalAlgorithm);
                        }

                        if (parent != null)
                        {
                            if (child.Parent != parent)
                                continue;
                        }

                        var matchedChild = child as T;
                        if (matchedChild != null)
                        {
                            var result = action(matchedChild);
                            if (!result)
                            {
                                // done traversing
                                return;
                            }
                        }
                    }
                    break;

                case TraversalAlgorithm.ReverseBreadthFirst:
                    Stack<T> matchedChildStack = new Stack<T>();
                    Stack<View> childStack = new Stack<View>();
                    foreach (View child in view.LayoutChildren)
                    {
                        if (recursive)
                        {
                            childStack.Push(child);
                        }

                        if (parent != null)
                        {
                            if (child.Parent != parent)
                                continue;
                        }

                        var matchedChild = child as T;
                        if (matchedChild != null)
                        {
                            matchedChildStack.Push(matchedChild);
                        }
                    }

                    foreach (var childStackView in childStack)
                    {
                        childStackView.ForEach<T>(action, recursive, parent, traversalAlgorithm);
                    }

                    foreach (T matchedChild in matchedChildStack)
                    {
                        var result = action(matchedChild);
                        if (!result)
                        {
                            // done traversing
                            return;
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Traverses the view object tree and performs an action on each child.
        /// </summary>
        public static void ForEach<T>(this View view, Action<T> action, bool recursive = true, View parent = null, TraversalAlgorithm traversalAlgorithm = TraversalAlgorithm.DepthFirst) where T : View
        {
            view.ForEach<T>(x => { action(x); return true; }, recursive, parent, traversalAlgorithm);
        }

        /// <summary>
        /// Traverses the view object tree and performs an action on this view and its children until the action returns false.
        /// </summary>
        public static void ForThisAndEach<T>(this View view, Action<T> action, bool recursive = true, View parent = null, TraversalAlgorithm traversalAlgorithm = TraversalAlgorithm.DepthFirst) where T : View
        {
            var thisView = view as T;
            if (thisView != null)
            {
                action(thisView);
            }
            view.ForEach<T>(action, recursive, parent, traversalAlgorithm);
        }

        /// <summary>
        /// Performs an action on all ascendants of a view.
        /// </summary>
        public static void ForEachParent<T>(this View view, Action<T> action) where T : View
        {
            if (view.LayoutParent == null)
                return;

            var parent = view.LayoutParent as T;
            if (parent != null)
            {
                action(parent);
            }

            view.LayoutParent.ForEachParent(action);
        }

        /// <summary>
        /// Returns first ascendant of type T found that matches the predicate.
        /// </summary>
        public static T FindParent<T>(this View view, Predicate<T> predicate) where T : View
        {
            var parent = view.LayoutParent;
            if (parent == null)
            {
                return null;
            }

            var parentAsT = parent as T;
            if (parentAsT != null && predicate(parentAsT))
            {
                return parentAsT;
            }
            else
            {
                return parent.FindParent(predicate);
            }
        }

        /// <summary>
        /// Returns first ascendant of type T found.
        /// </summary>
        public static T FindParent<T>(this View view) where T : View
        {
            return view.FindParent<T>(x => true);
        }

        /// <summary>
        /// Traverses the view object tree and returns the first view that matches the predicate.
        /// </summary>
        public static T Find<T>(this View view, Predicate<T> predicate, bool recursive = true, View parent = null, TraversalAlgorithm traversalAlgorithm = TraversalAlgorithm.DepthFirst) where T : View
        {
            T result = null;
            view.ForEach<T>(x =>
            {
                if (predicate(x))
                {
                    result = x;
                    return false;
                }
                return true;
            }, recursive, parent, traversalAlgorithm);
            return result;
        }

        /// <summary>
        /// Returns first view of type T found.
        /// </summary>
        public static T Find<T>(this View view, bool recursive = true, View parent = null, TraversalAlgorithm traversalAlgorithm = TraversalAlgorithm.DepthFirst) where T : View
        {
            return view.Find<T>(x => true, recursive, parent, traversalAlgorithm);
        }

        /// <summary>
        /// Returns first view of type T with the specified ID.
        /// </summary>
        public static T Find<T>(this View view, string id, bool recursive = true, View parent = null, TraversalAlgorithm traversalAlgorithm = TraversalAlgorithm.DepthFirst) where T : View
        {
            return view.Find<T>(x => String.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase), recursive, parent, traversalAlgorithm);
        }

        /// <summary>
        /// Adds range of items to hash-set.
        /// </summary>
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                hashSet.Add(item);
            }
        }


        /// <summary>
        /// Clamps a value to specified range [min, max].
        /// </summary>
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        /// <summary>
        /// Converts enumerable to bindable collection.
        /// </summary>
        public static BindableCollection<TSource> ToBindableCollection<TSource>(this IEnumerable<TSource> source)
            where TSource : BindableObject
        {
            return new BindableCollection<TSource>(source);
        }

        /// <summary>
        /// Gets lines from string.
        /// </summary>
        public static IEnumerable<string> GetLines(this string str, bool removeEmptyLines = false)
        {
            return str.Split(new[] { "\r\n", "\r", "\n" },
                removeEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }

        /// <summary>
        /// Inserts item to list at index or adds if index is at the end.
        /// </summary>
        public static void InsertOrAdd<T>(this List<T> list, int index, T item) 
        {
            int count = list.Count();
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException(String.Format("Index: {0}, Collection Count: {1}", index, count));
            }

            if (index == count)
            {
                list.Add(item);
            }
            else
            {
                list.Insert(index, item);
            }
        }

        /// <summary>
        /// Inserts or adds character to string at index or adds if index is at the end.
        /// </summary>
        public static string InsertOrAdd(this string str, int index, string c)
        {
            int count = str.Length;
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException(String.Format("Index: {0}, String Length: {1}", index, count));
            }

            if (index == count)
            {
                str += c;
            }
            else
            {
                str = str.Insert(index, c);
            }
            return str;
        }

        /// <summary>
        /// Finds the index of the first item matching an expression in an enumerable.
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            int retVal = 0;
            foreach (var item in items)
            {
                if (predicate(item)) return retVal;
                retVal++;
            }
            return -1;
        }

        /// <summary>
        /// Finds the index of the first occurrence of an item in an enumerable.
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> items, T item)
        {
            return items.IndexOf(i => EqualityComparer<T>.Default.Equals(item, i));
        }

        #endregion
    }
}
