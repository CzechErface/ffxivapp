﻿// FFXIVAPP.Client
// LogPublisher.cs
// 
// © 2013 Ryan Wilson

using System.Collections.Generic;
using FFXIVAPP.Client.Memory;
using FFXIVAPP.Client.Plugins.Parse.Models;
using FFXIVAPP.Client.Plugins.Parse.Utilities;
using SmartAssembly.Attributes;

namespace FFXIVAPP.Client.Utilities
{
    [DoNotObfuscate]
    public static partial class LogPublisher
    {
        public static void Process()
        {
            
        }

        public static void HandleCommands(ChatEntry chatEntry)
        {
            // process commands
            if (chatEntry.Code == "0038")
            {
                var commandsRegEx = CommandBuilder.CommandsRegEx.Match(chatEntry.Line.Trim());
                if (commandsRegEx.Success)
                {
                    var plugin = commandsRegEx.Groups["plugin"].Success ? commandsRegEx.Groups["plugin"].Value : "";
                    var command = commandsRegEx.Groups["command"].Success ? commandsRegEx.Groups["command"].Value : "";
                    switch (plugin)
                    {
                        case "event":
                            switch (command)
                            {
                                case "on":
                                    Event.IsPaused = false;
                                    break;
                                case "off":
                                    Event.IsPaused = true;
                                    break;
                            }
                            break;
                        case "log":
                            switch (command)
                            {
                                case "on":
                                    Log.IsPaused = false;
                                    break;
                                case "off":
                                    Log.IsPaused = true;
                                    break;
                            }
                            break;
                        case "parse":
                            switch (command)
                            {
                                case "on":
                                    Parse.IsPaused = false;
                                    break;
                                case "off":
                                    Parse.IsPaused = true;
                                    break;
                                case "reset":
                                    ParseControl.Instance.Reset();
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}
