#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using UnityEditorInternal;
#endregion

namespace Delight
{
    /// <summary>
    /// Provides logic for navigating between child views.
    /// </summary>
    public partial class Navigator
    {
        #region Fields

        public Stack<View> ViewStack { get; set; } = new Stack<View>();
        public SceneObjectView ActiveView;

        #endregion

        #region Methods

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();
            Messenger.Register<NavigatorMessage>(this, Id, OnNavigatorMessage, false, true);

            ViewStack = new Stack<View>();
            foreach (var kv in Path.AttachedValues)
            {
                var child = kv.Key as SceneObjectView;
                var path = kv.Value;

                if (!String.IsNullOrEmpty(path) && path == StartPath)
                {
                    ActiveView = child;
                    continue;
                }

                var childLoadMode = child.LoadMode | ChildLoadMode;
                if (SwitchMode == SwitchMode.Load || SwitchMode == SwitchMode.LoadOnce)
                {
                    var loadMode = childLoadMode | LoadMode.Manual;
                    child.LoadMode = loadMode;
                }
                else
                {
                    childLoadMode &= ~LoadMode.Manual; // remove any manual flag to force automatic if we're activating them
                    child.LoadMode = childLoadMode;
                    if (SwitchMode == SwitchMode.Enable)
                    {
                        child.IsActive = false;
                    }
                }
            }
        }

        /// <summary>
        /// Called before the view is unloaded.
        /// </summary>
        protected override void BeforeUnload()
        {
            base.BeforeUnload();
            Messenger.Unregister<NavigatorMessage>(this);
        }

        /// <summary>
        /// Called when a navigator message is received.
        /// </summary>
        /// <param name="message"></param>
        public void OnNavigatorMessage(NavigatorMessage message)
        {
            if (IsDisabled)
            {
                return;
            }

            if (message.MessageType == NavigatorMessageType.Pop)
            {
                Pop();
                return;
            }
            else if (message.MessageType == NavigatorMessageType.Close)
            {
                Close();
                return;
            }

            var view = message.NavigateToView ?? GetViewAtPath(message.NavigateToPath);
            if (message.MessageType == NavigatorMessageType.Push)
            {
                Push(view, message.Data);
            }
            else
            {
                Open(view, message.Data);
            }
        }

        /// <summary>
        /// Gets view at path.
        /// </summary>
        public View GetViewAtPath(string path)
        {
            foreach (var kv in Path.AttachedValues)
            {
                if (kv.Value.IEquals(path))
                {
                    return kv.Key as View;
                }
            }

            return null;
        }

        /// <summary>
        /// Sends message to all navigators to navigate to the specified page.
        /// </summary>
        public static void Open(string path, object data = null, string navigatorId = null)
        {
            // navigates to the specified path
            var navigatorMessage = new NavigatorMessage { NavigateToPath = path, Data = data, MessageType = NavigatorMessageType.NavigateTo };
            if (navigatorId != null)
            {
                Messenger.Send(navigatorMessage, navigatorId);
            }
            else
            {
                Messenger.Send(navigatorMessage);
            }
        }

        /// <summary>
        /// Sends message to all navigators to navigate to the specified path.
        /// </summary>
        public static void Push(string path, object data = null, string navigatorId = null)
        {
            // navigates to the specified path
            var navigatorMessage = new NavigatorMessage { NavigateToPath = path, Data = data, MessageType = NavigatorMessageType.Push };
            if (navigatorId != null)
            {
                Messenger.Send(navigatorMessage, navigatorId);
            }
            else
            {
                Messenger.Send(navigatorMessage);
            }
        }

        /// <summary>
        /// Sends message to all navigators to return to previous view.
        /// </summary>
        public static void Pop(string navigatorId = null)
        {
            // pops view 
            var navigatorMessage = new NavigatorMessage { MessageType = NavigatorMessageType.Pop };
            if (navigatorId != null)
            {
                Messenger.Send(navigatorMessage, navigatorId);
            }
            else
            {
                Messenger.Send(navigatorMessage);
            }
        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            if (IgnoreObject)
                return;
            base.AfterLoad();

            // load active view if it hasn't been loaded
            if (ActiveView != null)
            {
                if (SwitchMode != SwitchMode.Manual)
                {
                    if (!ActiveView.IsLoaded)
                    {
                        ActiveView.Load();
                    }

                    if (!ActiveView.IsActive)
                    {
                        ActiveView.IsActive = true;
                    }
                }

                if (ActiveView.IsLoaded)
                {
                    ActiveView.Setup(null);
                }
            }
        }

        /// <summary>
        /// Opens the page specified.
        /// </summary>
        public void Open(string path, object data = null)
        {
            var view = GetViewAtPath(path);
            Open(view, data);
        }

        /// <summary>
        /// Opens the page specified.
        /// </summary>
        public void Open(View view, object data = null)
        {
            if (view == ActiveView)
                return;
            SetPageState(view, data, NavigationTransition.Open);
        }

        /// <summary>
        /// Opens the page specified.
        /// </summary>
        public async void SetPageState(View view, object data, NavigationTransition navigationTransition)
        {
            if (view == ActiveView)
                return;

            List<Task> transitionTasks = null;
            SceneObjectView transitionOutView = null;
            if (ActiveView != null)
            {
                transitionOutView = ActiveView;
                transitionTasks = new List<Task>();

                // add transition out task
                switch (navigationTransition)
                {
                    case NavigationTransition.Open:
                        transitionTasks.Add(ActiveView.SetState("Closed"));
                        break;
                    case NavigationTransition.Push:
                        transitionTasks.Add(ActiveView.SetState("Pushed"));
                        break;
                    case NavigationTransition.Pop:
                        transitionTasks.Add(ActiveView.SetState("Closed"));
                        break;
                    case NavigationTransition.Close:
                        transitionTasks.Add(ActiveView.SetState("Closed"));
                        break;
                }
            }

            ActiveView = view as SceneObjectView;
            if (ActiveView != null)
            {
                // load/activate view
                await ActiveView.LoadAsync();
                ActiveView.IsActive = true;
                ActiveView.Setup(data);

                if (transitionTasks == null)
                {
                    transitionTasks = new List<Task>();
                }

                // add transition in task
                switch (navigationTransition)
                {
                    case NavigationTransition.Push:
                    case NavigationTransition.Open:
                        await ActiveView.SetState("Closed", false);
                        transitionTasks.Add(ActiveView.SetState(DefaultStateName));
                        break;

                    case NavigationTransition.Pop:
                        await ActiveView.SetState("Pushed", false);
                        transitionTasks.Add(ActiveView.SetState(DefaultStateName));
                        break;

                    default:
                    case NavigationTransition.Close:
                        break;
                }
            }

            if (transitionTasks != null)
            {
                await Task.WhenAll(transitionTasks);
            }

            // unload/deactivate views that has transitioned out
            if (transitionOutView != null && SwitchMode != SwitchMode.Manual)
            {
                if (SwitchMode == SwitchMode.Load)
                {
                    transitionOutView.Unload();
                }
                else
                {
                    transitionOutView.IsActive = false;
                }
            }
        }

        /// <summary>
        /// Closes all pages.
        /// </summary>
        public void Close()
        {
            ViewStack.Clear();
            SetPageState(null, null, NavigationTransition.Close);
        }

        /// <summary>
        /// Pushes active view on the stack and opens specified view.
        /// </summary>
        public void Push(string path, object data = null)
        {
            var view = GetViewAtPath(path);
            Push(view, data);
        }

        /// <summary>
        /// Pushes active view on the stack and opens specified view.
        /// </summary>
        public void Push(View view, object data = null)
        {
            if (view == ActiveView)
                return;

            if (ActiveView != null)
            {
                ViewStack.Push(ActiveView);
            }
            SetPageState(view, data, NavigationTransition.Push);
        }

        /// <summary>
        /// Pops view on the stack and opens it.
        /// </summary>
        public void Pop()
        {
            if (ViewStack.Count > 0)
            {
                SetPageState(ViewStack.Pop(), null, NavigationTransition.Pop);
            }
            else
            {
                // TODO close or navigate to initial page not sure which behavior makes sense
                Close();
            }
        }

        #endregion
    }

    /// <summary>
    /// Specifies either view or path that the navigator should navigate to. 
    /// </summary>
    public class NavigatorMessage
    {
        public View NavigateToView; 
        public string NavigateToPath;
        public NavigatorMessageType MessageType = NavigatorMessageType.NavigateTo;
        public object Data;
    }

    public enum NavigatorMessageType
    {
        NavigateTo = 0,
        Push = 1,
        Pop = 2,
        Close = 3
    }

    public enum NavigationTransition
    {
        Open,
        Push,
        Pop,
        Close,
    }
}
