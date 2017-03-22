using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Arcan.AtHome.API.Infrastructure
{
    public enum MessageType
    {
        Error = 1,
        Warning = 2,
        Information = 4,
        Success = 8,
    }

    [DataContract]
    public class Message
    {
        [JsonConstructor()]
        public Message(MessageType type, string message)
        {
            Content = message;
            Type = type;
        }

        public Message(MessageType type, string format, params object[] args)
        {
            Content = args != null ? string.Format(new PluralFormatProvider(), format, args) : format;
            Type = type;
        }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        [Display(Description= "(Error:1,Warning:2,Information: 4,Success:8)")]
        public MessageType Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Content);
        }

        public class PluralFormatProvider : IFormatProvider, ICustomFormatter
        {
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                if (format == null || format.StartsWith("#") == false)
                {
                    var formattableArg = arg as IFormattable;


                    if (formattableArg != null)
                    {
                        return formattableArg.ToString(format, formatProvider);
                    }


                    return arg != null ? arg.ToString() : null;
                }

                string[] forms = format.Remove(0,1).Split(';');
                var value = (int) arg;
                int form = value == 1 ? 0 : 1;

                return forms[form];
            }

            public object GetFormat(Type formatType)
            {
                return this;
            }
        }
    }
}