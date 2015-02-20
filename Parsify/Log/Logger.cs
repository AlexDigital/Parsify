using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Parsify.Log
{
    /// <summary>
    /// A simple logger
    /// </summary>
    public class Logger
    {
        private static TextWriter stream;
        private static bool consolemode = true;

        /// <summary>
        /// The delegate for the OnLogText-Event
        /// </summary>
        /// <param name="msg">The message</param>
        public delegate void LogText(string msg);

        /// <summary>
        /// This event raises when a log message is written
        /// </summary>
        public static event LogText OnLogText;

        /// <summary>
        /// Initializes the logger with a stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public static void Init(TextWriter stream)
        {
            consolemode = false;
            Logger.stream = stream;
        }

        private static void Write(VerbosityLevel verbosity, string str)
        {
            if (Verbosity.Verb >= verbosity)
            {
                string verb = Enum.GetName(typeof(VerbosityLevel), Verbosity.Verb);
                if (consolemode)
                    Console.WriteLine("[{0}] {1}", verb, str);
                else
                    stream.WriteLine("[{0}] {1}", verb, str);

                if(OnLogText != null) OnLogText(str);
            }
        }

        private static void Write(VerbosityLevel verbosity, string format, params object[] args)
        {
            Write(verbosity, string.Format(format, args));
        }

        /// <summary>
        /// Writes an log message with the VerbosityLevel Basic
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments</param>
        public static void Write(string format, params object[] args)
        {
            Write(VerbosityLevel.Basic, format, args);
        }

        /// <summary>
        /// Writes an log message with the VerbosityLevel Debug
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments</param>
        public static void Debug(string format, params object[] args)
        {
            Write(VerbosityLevel.Debug, format, args);
        }

        /// <summary>
        /// Writes an log message with the VerbosityLevel Warning
        /// </summary>
        /// <param name="str">The message</param>
        public static void Warning(string str)
        {
            if (consolemode)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Write(VerbosityLevel.Warnings, str);
        }

        /// <summary>
        /// Writes an log message with the VerbosityLevel Warning
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments</param>
        public static void Warning(string format, params object[] args)
        {
            if (consolemode)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Write(VerbosityLevel.Warnings, format, args);
        }

        /// <summary>
        /// Writes an log message with the VerbosityLevel Error
        /// </summary>
        /// <param name="str">The message</param>
        public static void Error(string str)
        {
            ConsoleColor color = ConsoleColor.White;
            if (consolemode)
            {
                color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Write(VerbosityLevel.ErrorOnly, str);
            if (consolemode) Console.ForegroundColor = color;
        }

        /// <summary>
        /// Writes an log message with the VerbosityLevel Error
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments</param>
        public static void Error(string format, params object[] args)
        {
            ConsoleColor color = ConsoleColor.White;
            if (consolemode)
            {
                color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Write(VerbosityLevel.ErrorOnly, format, args);
            if (consolemode) Console.ForegroundColor = color;
        }

    }
}
