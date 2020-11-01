using System.Linq;
using System.Runtime.Serialization;

namespace GraGadGet.Menv
{
    enum OutputFormat
    {
        /// <summary>
        /// Use StdOut string by Maya.
        /// </summary>
        [EnumMember(Value = "raw")]
        Raw = 0,

        /// <summary>
        /// Use list style.
        /// </summary>
        [EnumMember(Value = "plain")]
        Plain = 1,

        /// <summary>
        /// Use JSON format style.
        /// </summary>
        [EnumMember(Value = "json")]
        JSON = 2
    }

    static class OutputFormatExt
    {
        public static string GetText(this OutputFormat value)
        {
            EnumMemberAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;

            return attribute == null ? value.ToString() : attribute.Value;
        }
    }
}
