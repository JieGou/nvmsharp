﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVMSharp.Common
{
    public enum AppMode : int
    {
        None = 0,
        User,
        System,
        Import,
        Export,
        About
    }

    public enum InitResultType : int
    {
        None = 0,
        InitOk,
        AccessDenied,
        OtherError
    }

    public enum ModificationModeType : int
    {
        None = 0,
        NewKey,
        EditKey,
        NewValue,
        EditValue
    }

    public static class Constants
    {
        public const string VERSION = "2.0";
        public const string USER_ENV_SUBKEY = @"Environment";
        public const string SYSTEM_ENV_SUBKEY = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
        public const string SEPARATOR = ";";
        public const string ENUM_SEPARATOR = "|";
        public const string CONFIRM_DELETE_TITLE = "Confirm Delete";
        public const string CONFIRM_DELETE_KEY = "Deleting an Environment Variable can't be undone.\n\nAre you sure you want to permanently delete this environment variable and its values?";
        public const string CONFIRM_DELETE_VALUE = "Deleting a value can't be undone.\n\nAre you sure you want to permanently delete this value?";
        public const string CONFIRM_DELETE_VALUE_AND_KEY = "Deleting a value can't be undone.\n\nDeleting this value will delete the Environment Variable too!\n\nAre you sure you want to permanently delete this Environment Variable?";
        public const string MODE_NEW_USER_KEY = "New User Variable";
        public const string MODE_EDIT_USER_KEY = "Edit User Variable";
        public const string MODE_NEW_SYSTEM_KEY = "New System Variable";
        public const string MODE_EDIT_SYSTEM_KEY = "New System Variable";
        public const string MODE_NEW_VALUE = "New Value";
        public const string MODE_EDIT_VALUE = "Edit Value";
        public const string VALIDATION_USER_KEY_ERROR = "User Variable already exists!";
        public const string VALIDATION_SYSTEM_KEY_ERROR = "System Variable already exists!";
        public const string VALIDATION_VALUE_ERROR = "Value already exists!";
        public const string SELECT_ENVAR_IMPORT = "Select the Environment Variable(s) to import";
        public const string SELECT_ENVAR_EXPORT = "Select the Environment Variable(s) to export";
        public const string NO_ENVAR_AVAILABLE_FOR_IMPORT = "No Environment Variables are available for importing!";
        public const string NO_ENVAR_AVAILABLE_FOR_EXPORT = "No Environment Variables are available!";

        public const string X_ROOT = "nvm";
        public const string X_VERSION = "version";
        public const string X_USER = "user";
        public const string X_SYSTEM = "system";
        public const string X_VARIABLE = "variable";
        public const string X_NAME = "name";
        public const string X_VALUE = "value";

        public const string INIT_IMPORT_ERROR = "Error encountered while parsing the file!\n\nPlease check Event Log for details.";
        public const string IMPORT_ERROR = "Unable to import the Environment variable(s)!\n\nPlease check Event Log for details.";
        public const string EXPORT_ERROR = "Unable to export the Environment variable(s)!\n\nPlease check Event Log for details.";
    }

}
