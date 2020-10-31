﻿using System;
using System.Globalization;

namespace MudBlazor
{
    
    /// <summary>
    /// A universal T to string binding converter
    /// </summary>
    public class DefaultConverter<T> : Converter<T>
    {
       
        public DefaultConverter()
        {
            SetFunc = OnSet;
            GetFunc = OnGet;
        }

        private T OnGet(string value)
        {
            try
            {
                // string
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)value;
                }
                // char
                else if (typeof(T) == typeof(char) || typeof(T) == typeof(char?))
                {
                    if (string.IsNullOrEmpty(value))
                        return default(T);
                    return (T)(object)value[0];
                }
                // bool
                else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                {
                    if (string.IsNullOrEmpty(value))
                        return default(T);
                    var lowerValue = value.ToLowerInvariant();
                    if ( lowerValue=="true")
                        return (T)(object)true;
                    if (lowerValue == "false")
                        return (T)(object)false;
                    OnError?.Invoke("Not a valid boolean");
                    return default(T);
                }
                // sbyte
                else if (typeof(T) == typeof(sbyte) || typeof(T) == typeof(sbyte?))
                {
                    if (sbyte.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // byte
                else if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
                {
                    if (byte.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // short
                else if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
                {
                    if (short.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // ushort
                else if (typeof(T) == typeof(ushort) || typeof(T) == typeof(ushort?))
                {
                    if (ushort.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // int
                else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                {
                    if (int.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // uint
                else if (typeof(T) == typeof(uint) || typeof(T) == typeof(uint?))
                {
                    if (uint.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // long
                else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                {
                    if (long.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // ulong
                else if (typeof(T) == typeof(ulong) || typeof(T) == typeof(ulong?))
                {
                    if (ulong.TryParse(value, NumberStyles.Integer, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // float
                else if (typeof(T) == typeof(float) || typeof(T) == typeof(float?))
                {
                    if (float.TryParse(value, NumberStyles.Any, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // double
                else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                {
                    if (double.TryParse(value, NumberStyles.Any, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // decimal
                else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
                {
                    if (decimal.TryParse(value, NumberStyles.Any, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid number");
                }
                // guid
                else if (typeof(T) == typeof(Guid))
                {
                    if (Guid.TryParse(value, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid GUID");
                }
                // enum
                else if (typeof(T).IsEnum)
                {
                    if (Enum.TryParse(typeof(T), value, out var parsedValue))
                        return (T)parsedValue;
                    OnError?.Invoke("Not a value of " + typeof(T).Name);
                }
                // datetime
                else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                {
                    if (DateTime.TryParse(value, Culture,  DateTimeStyles.None, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid date time");
                }
                // timespan
                else if (typeof(T) == typeof(TimeSpan) || typeof(T) == typeof(TimeSpan?))
                {
                    if (TimeSpan.TryParse(value, Culture, out var parsedValue))
                        return (T)(object)parsedValue;
                    OnError?.Invoke("Not a valid date time");
                }
            }
            catch (Exception e)
            {
                OnError?.Invoke("Conversion error: "+e.Message);
                return default(T);
            }
            OnError?.Invoke($"Conversion to type {typeof(T)} not implemented");
            return default(T);
        }

        private string OnSet(T arg)
        {
            if (arg == null)
                return null; // <-- this catches all nullable values which are null. no nullchecks necessary below!
            try
            {
                // string
                if (typeof(T) == typeof(string))
                    return (string)(object)arg;
                // char
                if (typeof(T) == typeof(char))
                    return ((char)(object)arg).ToString(Culture);
                if (typeof(T) == typeof(char?))
                    return ((char?)(object)arg).Value.ToString(Culture);
                // bool
                if (typeof(T) == typeof(bool))
                    return ((bool)(object)arg).ToString(CultureInfo.InvariantCulture);
                if (typeof(T) == typeof(bool?))
                    return ((bool?)(object)arg).Value.ToString(CultureInfo.InvariantCulture);
                // sbyte
                if (typeof(T) == typeof(sbyte))
                    return ((sbyte)(object)arg).ToString(Culture);
                if (typeof(T) == typeof(sbyte?))
                    return ((sbyte?)(object)arg).Value.ToString(Culture);
                // byte
                if (typeof(T) == typeof(byte))
                    return ((byte)(object)arg).ToString(Culture);
                if (typeof(T) == typeof(byte?))
                    return ((byte?)(object)arg).Value.ToString(Culture);
                // short
                if (typeof(T) == typeof(short))
                    return ((short)(object)arg).ToString(Culture);
                if (typeof(T) == typeof(short?))
                    return ((short?)(object)arg).Value.ToString(Culture);
                // ushort
                if (typeof(T) == typeof(ushort))
                    return ((ushort)(object)arg).ToString(Culture);
                if (typeof(T) == typeof(ushort?))
                    return ((ushort?)(object)arg).Value.ToString(Culture);
                // int
                else if (typeof(T) == typeof(int) )
                    return ((int)(object)arg).ToString(Culture);
                else if (typeof(T) == typeof(int?))
                    return ((int?)(object)arg).Value.ToString(Culture);
                // uint
                else if (typeof(T) == typeof(uint))
                    return ((uint)(object)arg).ToString(Culture);
                else if (typeof(T) == typeof(uint?))
                    return ((uint?)(object)arg).Value.ToString(Culture);
                // long
                else if (typeof(T) == typeof(long))
                    return ((long)(object)arg).ToString(Culture);
                else if (typeof(T) == typeof(long?))
                    return ((long?)(object)arg).Value.ToString(Culture);
                // ulong
                else if (typeof(T) == typeof(ulong))
                    return ((ulong)(object)arg).ToString(Culture);
                else if (typeof(T) == typeof(ulong?))
                    return ((ulong?)(object)arg).Value.ToString(Culture);
                // float
                else if (typeof(T) == typeof(float))
                    return ((float)(object)arg).ToString(Culture);
                else if (typeof(T) == typeof(float?))
                    return ((float?)(object)arg).Value.ToString(Culture);
                // double
                else if (typeof(T) == typeof(double))
                    return ((double)(object)arg).ToString(Culture);
                else if (typeof(T) == typeof(double?))
                    return ((double?)(object)arg).Value.ToString(Culture);
                // decimal
                else if (typeof(T) == typeof(decimal))
                    return ((decimal)(object)arg).ToString(Culture);
                else if (typeof(T) == typeof(decimal?))
                    return ((decimal?)(object)arg).Value.ToString(Culture);
                // guid
                else if (typeof(T) == typeof(Guid))
                {
                    var value = (Guid) (object) arg;
                    return value.ToString();
                }
                // enum
                else if (typeof(T).IsEnum)
                {
                    var value = (Enum) (object) arg;
                    return value.ToString();
                }
                // datetime
                else if (typeof(T) == typeof(DateTime))
                {
                    var value = (DateTime) (object) arg;
                    return value.ToString(Culture);
                }  
                else if (typeof(T) == typeof(DateTime?))
                {
                    var value = (DateTime?) (object) arg;
                    return value.Value.ToString(Culture);
                }      
                // timespan
                else if (typeof(T) == typeof(TimeSpan))
                {
                    var value = (TimeSpan) (object) arg;
                    return value.ToString();
                }  
                else if (typeof(T) == typeof(TimeSpan?))
                {
                    var value = (TimeSpan?) (object) arg;
                    return value.Value.ToString();
                }               
                return arg.ToString( );
            }
            catch (FormatException e)
            {
                OnError?.Invoke("Conversion error: "+e.Message);
                return null;
            }
        }
    }
}