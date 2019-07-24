#region Using Statements
#endregion

namespace Delight
{
    public enum XmlSyntaxElement
    {
        Undefined,
        BeginViewName,
        ViewName,
        EndViewName,
        EndView,
        BeginPropertyValue,
        PropertyValue,
        EndPropertyValue,
        PropertyName,
        Comment,
        EndComment
    }
}
