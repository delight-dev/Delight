#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Color value converter.
    /// </summary>
    public class ColorValueConverter : ValueConverter<Color>
    {
        #region Fields               

        public static Dictionary<string, Color> ColorCodes;

        #endregion

        #region Methods

        /// <summary>
        /// Gets initializer from string value.
        /// </summary>
        public override string GetInitializer(string stringValue)
        {
            var convertedValue = Convert(stringValue);
            return String.Format(CultureInfo.InvariantCulture, "new UnityEngine.Color({0}f, {1}f, {2}f, {3}f)", convertedValue.r, convertedValue.g, convertedValue.b, convertedValue.a);            
        }

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public override Color Convert(string stringValue)
        {
            // is it a hex value #aarrggbb | #rrggbb?
            Color? color = HexToColor(stringValue);
            if (color.HasValue)
            {
                // hex color
                return color.Value;
            }

            // is it a color name?
            string colorName = stringValue.Trim().ToLower();
            Color namedColor;
            if (ColorCodes.TryGetValue(colorName, out namedColor))
            {
                return namedColor;
            }

            // is it a r,g,b,a value?
            Color? rgbaColor = RgbaToColor(stringValue);
            if (rgbaColor.HasValue)
            {
                return rgbaColor.Value;
            }

            throw new Exception("Improperly formatted color string. Supported formats: #aarrggbb | #rrggbb | ColorName | r,g,b,a");
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public override UnityEngine.Color Convert(object objectValue)
        {
            if (objectValue == null)
                return default(UnityEngine.Color);

            Type objectType = objectValue.GetType();
            if (objectType == typeof(string))
            {
                return Convert(objectValue as string);
            }
            else if (objectType == typeof(Color))
            {
                return (Color)objectValue;
            }

            throw new Exception(String.Format("Can't convert object of type \"{0}\" to UnityEngine.Color", objectType.Name));
        }

        /// <summary>
        /// Gets color from hex value.
        /// </summary>
        public static Color? HexToColor(string hex)
        {
            var trimmedValue = hex.Trim();
            if (trimmedValue.StartsWith("#"))
            {
                if (trimmedValue.Length == 9)
                {
                    // #aarrggbb
                    return new Color(
                        int.Parse(trimmedValue.Substring(3, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                        int.Parse(trimmedValue.Substring(5, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                        int.Parse(trimmedValue.Substring(7, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                        int.Parse(trimmedValue.Substring(1, 2), System.Globalization.NumberStyles.HexNumber) / 255f
                        );
                }
                else if (trimmedValue.Length == 7)
                {
                    // #rrggbb
                    return new Color(
                        int.Parse(trimmedValue.Substring(1, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                        int.Parse(trimmedValue.Substring(3, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                        int.Parse(trimmedValue.Substring(5, 2), System.Globalization.NumberStyles.HexNumber) / 255f
                        );
                }
            }

            return null;
        }

        /// <summary>
        /// Gets color from float RGBA values (0-1)
        /// </summary>
        public static Color? RgbaToColor(string color)
        {
            string[] values = color.Split(new char[] { ',' });
            if (values.Length == 3)
            {
                return new Color(System.Convert.ToSingle(values[0], CultureInfo.InvariantCulture),
                    System.Convert.ToSingle(values[1], CultureInfo.InvariantCulture),
                    System.Convert.ToSingle(values[2], CultureInfo.InvariantCulture));
            }
            else if (values.Length == 4)
            {
                return new Color(System.Convert.ToSingle(values[0], CultureInfo.InvariantCulture),
                    System.Convert.ToSingle(values[1], CultureInfo.InvariantCulture),
                    System.Convert.ToSingle(values[2], CultureInfo.InvariantCulture),
                    System.Convert.ToSingle(values[3], CultureInfo.InvariantCulture));
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a static instance of the class.
        /// </summary>
        static ColorValueConverter()
        {
            ColorCodes = new Dictionary<string, Color>();
            ColorCodes.Add("clear", Color.clear);
            ColorCodes.Add("grey", Color.grey);
            ColorCodes.Add("red", Color.red);
            ColorCodes.Add("transparent", Color.clear);

            ColorCodes.Add("aliceblue", new Color(0.9411765f, 0.972549f, 1f));
            ColorCodes.Add("antiquewhite", new Color(0.9803922f, 0.9215686f, 0.8431373f));
            ColorCodes.Add("aquamarine", new Color(0.4980392f, 1f, 0.8313726f));
            ColorCodes.Add("azure", new Color(0.9411765f, 1f, 1f));
            ColorCodes.Add("beige", new Color(0.9607843f, 0.9607843f, 0.8627451f));
            ColorCodes.Add("black", new Color(0f, 0f, 0f));
            ColorCodes.Add("blue", new Color(0f, 0f, 1f));
            ColorCodes.Add("blueviolet", new Color(0.5411765f, 0.1686275f, 0.8862745f));
            ColorCodes.Add("brown", new Color(0.6470588f, 0.1647059f, 0.1647059f));
            ColorCodes.Add("burlywood", new Color(0.8705882f, 0.7215686f, 0.5294118f));
            ColorCodes.Add("chartreuse", new Color(0.4980392f, 1f, 0f));
            ColorCodes.Add("coral", new Color(1f, 0.4980392f, 0.3137255f));
            ColorCodes.Add("cornflowerblue", new Color(0.3921569f, 0.5843138f, 0.9294118f));
            ColorCodes.Add("cyan", new Color(0f, 1f, 1f));
            ColorCodes.Add("denim", new Color(0.08235294f, 0.3764706f, 0.7411765f));
            ColorCodes.Add("dimgray", new Color(0.4117647f, 0.4117647f, 0.4117647f));
            ColorCodes.Add("dodgerblue", new Color(0.1176471f, 0.5647059f, 1f));
            ColorCodes.Add("electricindigo", new Color(0.4352941f, 0f, 1f));
            ColorCodes.Add("firebrick", new Color(0.6980392f, 0.1333333f, 0.1333333f));
            ColorCodes.Add("floralwhite", new Color(1f, 0.9803922f, 0.9411765f));
            ColorCodes.Add("forestgreen", new Color(0.1333333f, 0.5450981f, 0.1333333f));
            ColorCodes.Add("gainsboro", new Color(0.8627451f, 0.8627451f, 0.8627451f));
            ColorCodes.Add("ghostwhite", new Color(0.972549f, 0.972549f, 1f));
            ColorCodes.Add("gold", new Color(1f, 0.8431373f, 0f));
            ColorCodes.Add("goldenrod", new Color(0.854902f, 0.6470588f, 0.1254902f));
            ColorCodes.Add("gray", new Color(0.7450981f, 0.7450981f, 0.7450981f));
            ColorCodes.Add("gray10", new Color(0.1019608f, 0.1019608f, 0.1019608f));
            ColorCodes.Add("gray15", new Color(0.1490196f, 0.1490196f, 0.1490196f));
            ColorCodes.Add("gray20", new Color(0.2f, 0.2f, 0.2f));
            ColorCodes.Add("gray25", new Color(0.2509804f, 0.2509804f, 0.2509804f));
            ColorCodes.Add("gray30", new Color(0.3019608f, 0.3019608f, 0.3019608f));
            ColorCodes.Add("gray35", new Color(0.3490196f, 0.3490196f, 0.3490196f));
            ColorCodes.Add("gray40", new Color(0.4f, 0.4f, 0.4f));
            ColorCodes.Add("gray45", new Color(0.4509804f, 0.4509804f, 0.4509804f));
            ColorCodes.Add("gray50", new Color(0.4980392f, 0.4980392f, 0.4980392f));
            ColorCodes.Add("gray55", new Color(0.5490196f, 0.5490196f, 0.5490196f));
            ColorCodes.Add("gray60", new Color(0.6f, 0.6f, 0.6f));
            ColorCodes.Add("gray65", new Color(0.6509804f, 0.6509804f, 0.6509804f));
            ColorCodes.Add("gray70", new Color(0.7019608f, 0.7019608f, 0.7019608f));
            ColorCodes.Add("gray75", new Color(0.7490196f, 0.7490196f, 0.7490196f));
            ColorCodes.Add("gray80", new Color(0.8f, 0.8f, 0.8f));
            ColorCodes.Add("gray85", new Color(0.8509804f, 0.8509804f, 0.8509804f));
            ColorCodes.Add("gray90", new Color(0.8980392f, 0.8980392f, 0.8980392f));
            ColorCodes.Add("gray95", new Color(0.9490196f, 0.9490196f, 0.9490196f));
            ColorCodes.Add("green", new Color(0f, 1f, 0f));
            ColorCodes.Add("greenyellow", new Color(0.6784314f, 1f, 0.1843137f));
            ColorCodes.Add("honeydew", new Color(0.9411765f, 1f, 0.9411765f));
            ColorCodes.Add("hotpink", new Color(1f, 0.4117647f, 0.7058824f));
            ColorCodes.Add("indianred", new Color(0.8039216f, 0.3607843f, 0.3607843f));
            ColorCodes.Add("indigo", new Color(0.2941177f, 0f, 0.509804f));
            ColorCodes.Add("ivory", new Color(1f, 1f, 0.9411765f));
            ColorCodes.Add("lavender", new Color(0.9019608f, 0.9019608f, 0.9803922f));
            ColorCodes.Add("lavenderblush", new Color(1f, 0.9411765f, 0.9607843f));
            ColorCodes.Add("lawngreen", new Color(0.4862745f, 0.9882353f, 0f));
            ColorCodes.Add("lemonchiffon", new Color(1f, 0.9803922f, 0.8039216f));
            ColorCodes.Add("lightblue", new Color(0.6784314f, 0.8470588f, 0.9019608f));
            ColorCodes.Add("lightcoral", new Color(0.9411765f, 0.5019608f, 0.5019608f));
            ColorCodes.Add("lightpink", new Color(1f, 0.7137255f, 0.7568628f));
            ColorCodes.Add("lightsalmon", new Color(1f, 0.627451f, 0.4784314f));
            ColorCodes.Add("lightseagreen", new Color(0.1254902f, 0.6980392f, 0.6666667f));
            ColorCodes.Add("lightskyblue", new Color(0.5294118f, 0.8078431f, 0.9803922f));
            ColorCodes.Add("lightslateblue", new Color(0.5176471f, 0.4392157f, 1f));
            ColorCodes.Add("lightslategray", new Color(0.4666667f, 0.5333334f, 0.6f));
            ColorCodes.Add("lightsteelblue", new Color(0.6901961f, 0.7686275f, 0.8705882f));
            ColorCodes.Add("lightyellow", new Color(1f, 1f, 0.8784314f));
            ColorCodes.Add("limegreen", new Color(0.1960784f, 0.8039216f, 0.1960784f));
            ColorCodes.Add("linen", new Color(0.9803922f, 0.9411765f, 0.9019608f));
            ColorCodes.Add("magenta", new Color(1f, 0f, 1f));
            ColorCodes.Add("maroon", new Color(0.6901961f, 0.1882353f, 0.3764706f));
            ColorCodes.Add("midnightblue", new Color(0.09803922f, 0.09803922f, 0.4392157f));
            ColorCodes.Add("mintcream", new Color(0.9607843f, 1f, 0.9803922f));
            ColorCodes.Add("mistyrose", new Color(1f, 0.8941177f, 0.8823529f));
            ColorCodes.Add("moccasin", new Color(1f, 0.8941177f, 0.7098039f));
            ColorCodes.Add("navyblue", new Color(0f, 0f, 0.5019608f));
            ColorCodes.Add("orange", new Color(1f, 0.6470588f, 0f));
            ColorCodes.Add("orangered", new Color(1f, 0.2705882f, 0f));
            ColorCodes.Add("orchid", new Color(0.854902f, 0.4392157f, 0.8392157f));
            ColorCodes.Add("papayawhip", new Color(1f, 0.9372549f, 0.8352941f));
            ColorCodes.Add("peachpuff", new Color(1f, 0.854902f, 0.7254902f));
            ColorCodes.Add("pink", new Color(1f, 0.7529412f, 0.7960784f));
            ColorCodes.Add("plum", new Color(0.8666667f, 0.627451f, 0.8666667f));
            ColorCodes.Add("powderblue", new Color(0.6901961f, 0.8784314f, 0.9019608f));
            ColorCodes.Add("purple", new Color(0.627451f, 0.1254902f, 0.9411765f));
            ColorCodes.Add("rebeccapurple", new Color(0.4f, 0.2f, 0.6f));
            ColorCodes.Add("rosybrown", new Color(0.7372549f, 0.5607843f, 0.5607843f));
            ColorCodes.Add("royalblue", new Color(0.254902f, 0.4117647f, 0.8823529f));
            ColorCodes.Add("saddlebrown", new Color(0.5450981f, 0.2705882f, 0.07450981f));
            ColorCodes.Add("salmon", new Color(0.9803922f, 0.5019608f, 0.4470588f));
            ColorCodes.Add("sandybrown", new Color(0.9568627f, 0.6431373f, 0.3764706f));
            ColorCodes.Add("seagreen", new Color(0.3294118f, 1f, 0.6235294f));
            ColorCodes.Add("seashell", new Color(1f, 0.9607843f, 0.9333333f));
            ColorCodes.Add("silver", new Color(0.7529412f, 0.7529412f, 0.7529412f));
            ColorCodes.Add("sienna", new Color(0.627451f, 0.3215686f, 0.1764706f));
            ColorCodes.Add("skyblue", new Color(0.5294118f, 0.8078431f, 0.9215686f));
            ColorCodes.Add("slategray", new Color(0.4392157f, 0.5019608f, 0.5647059f));
            ColorCodes.Add("snow", new Color(1f, 0.9803922f, 0.9803922f));
            ColorCodes.Add("springgreen", new Color(0f, 1f, 0.4980392f));
            ColorCodes.Add("steelblue", new Color(0.2745098f, 0.509804f, 0.7058824f));
            ColorCodes.Add("thistle", new Color(0.8470588f, 0.7490196f, 0.8470588f));
            ColorCodes.Add("tropicalindigo", new Color(0.5882353f, 0.5137255f, 0.9254902f));
            ColorCodes.Add("turquoise", new Color(0.2509804f, 0.8784314f, 0.8156863f));
            ColorCodes.Add("violet", new Color(0.9333333f, 0.509804f, 0.9333333f));
            ColorCodes.Add("violetred", new Color(0.8156863f, 0.1254902f, 0.5647059f));
            ColorCodes.Add("wheat", new Color(0.9607843f, 0.8705882f, 0.7019608f));
            ColorCodes.Add("white", new Color(1f, 1f, 1f));
            ColorCodes.Add("whitesmoke", new Color(0.9607843f, 0.9607843f, 0.9607843f));
            ColorCodes.Add("yellow", new Color(1f, 1f, 0f));
            ColorCodes.Add("yellowgreen", new Color(0.6039216f, 0.8039216f, 0.1960784f));
        }

        #endregion
    }
}
