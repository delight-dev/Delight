#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Delight
{
    /// <summary>
    /// Class for subscribing to and passing messages across the application. 
    /// </summary>
    public static class Messenger
    {
        #region Fields

        private static Dictionary<Type, List<WeakActionAndToken>> _recipients = new Dictionary<Type, List<WeakActionAndToken>>();
        private class WeakActionAndToken
        {
            public WeakAction Action;
            public object Token;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers a recipient of messages of specified type.
        /// </summary>
        public static void Register<TMessage>(object recipient, Action<TMessage> action,
            bool keepTargetAlive = false)
        {
            Register(recipient, null, action, keepTargetAlive);
        }

        /// <summary>
        /// Registers a recipient of messages of specified type.
        /// </summary>
        public static void Register<TMessage>(object recipient, object token, Action<TMessage> action,
            bool keepTargetAlive = false)
        {
            lock (_recipients)
            {
                var messageType = typeof(TMessage);
                if (!_recipients.TryGetValue(messageType, out var actions))
                {
                    actions = new List<WeakActionAndToken>();
                    _recipients.Add(messageType, actions);
                }

                var weakAction = new WeakAction<TMessage>(recipient, action, keepTargetAlive);
                var actionAndToken = new WeakActionAndToken { Action = weakAction, Token = token };
                actions.Add(actionAndToken);
            }
        }

        /// <summary>
        /// Sends message to recipients.
        /// </summary>
        public static void Send<TMessage>(TMessage message)
        {
            SendToTargetOrType(message, null, null);
        }

        /// <summary>
        /// Sends message to recipients that registered with the specified token.
        /// </summary>
        public static void Send<TMessage>(TMessage message, object token)
        {
            SendToTargetOrType(message, null, token);
        }

        /// <summary>
        /// Sends message to recipients of specified type.
        /// </summary>
        public static void Send<TMessage, TTarget>(TMessage message)
        {
            SendToTargetOrType(message, typeof(TTarget), null);
        }

        /// <summary>
        /// Unregisters messsage recipient completely.
        /// </summary>
        public static void Unregister(object recipient)
        {
            lock (_recipients)
            {
                foreach (var messageType in _recipients.Keys)
                {
                    var actionsAndTokens = _recipients[messageType];
                    foreach (var actionAndToken in actionsAndTokens.ToList())
                    {
                        var weakAction = actionAndToken.Action;
                        if (weakAction != null && recipient == weakAction.Owner)
                        {
                            actionsAndTokens.Remove(actionAndToken);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Unregisters recipient for messsages of specified type.
        /// </summary>
        public static void Unregister<TMessage>(object recipient)
        {
            Unregister<TMessage>(recipient, null);
        }

        /// <summary>
        /// Unregisters recipient for messsages of specified type and token.
        /// </summary>
        public static void Unregister<TMessage>(object recipient, object token)
        {            
            lock (_recipients)
            {
                var messageType = typeof(TMessage);
                if (!_recipients.TryGetValue(messageType, out var actionsAndTokens))
                {
                    return;
                }

                foreach (var actionAndToken in actionsAndTokens.ToList())
                {
                    var weakActionCasted = actionAndToken.Action as WeakAction<TMessage>;
                    
                    // does action belong to recipient?
                    if (weakActionCasted == null || recipient != weakActionCasted.Owner)
                        continue; // no

                    // do tokens match?
                    if (token != null && !token.Equals(actionAndToken.Token))
                        continue; // no.

                    actionsAndTokens.Remove(actionAndToken);
                }
            }
        }

        /// <summary>
        /// Sends messages to target.
        /// </summary>
        private static void SendToTargetOrType<TMessage>(TMessage message, Type messageTargetType, object token)
        {
            lock (_recipients)
            {
                var messageType = typeof(TMessage);
                if (!_recipients.TryGetValue(messageType, out var actionsAndTokens))
                {
                    return;
                }

                var actionsAndTokensClone = actionsAndTokens.ToList();
                foreach (var actionAndToken in actionsAndTokensClone)
                {
                    var action = actionAndToken.Action;
                    if (action == null || !action.IsAlive ||
                        action.Owner == null)
                        continue;

                    // is the message to be sent to recipients of specific types?
                    if (messageTargetType != null)
                    {
                        // yes. check to see if recipients is of specified type
                        var actionOwnerType = action.Owner.GetType();
                        if (actionOwnerType != messageTargetType &&
                            !messageTargetType.IsAssignableFrom(actionOwnerType))
                        {
                            continue; // wrong type
                        }
                    }

                    // does the tokens match? 
                    if ((token == null && actionAndToken.Token == null) ||
                        (token != null && actionAndToken.Token.Equals(token)))
                    {
                        // yes.
                        (action as IInvokeWithObject).InvokeWithObject(message);
                    }
                }
            }
        }

        #endregion
    }
}
