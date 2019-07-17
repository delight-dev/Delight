#region Using Statements
#if UNITY_EDITOR
#endif
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for data passed by view actions to handlers.
    /// </summary>
    public class ActionData
    {
        public virtual object RawData { get { return this; } }
    }
}
